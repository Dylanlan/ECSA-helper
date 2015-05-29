using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Xml;
using Newtonsoft.Json;

namespace ECSAHelper
{
    /// <summary>
    /// The main form that the user interacts with to update ECSA Executive contact info on the server which contains the
    /// ECSA website.
    /// </summary>
    public partial class Form1 : Form
    {
        // Used as a temporary variable to hold the path of the old Executive picture file
        private string oldFile = "oldfile";
        // Used as a temporary variable to hold the path of the new Executive picture file, which will overwrite the old image
        private string newFile = "newfile";
        // The name of the json file which contains the Executive info
        private string jsonFile = "executives.json";
		// The name of the file of the ECSA Constitution
		private string constitutionFile = "constitution.pdf";
        // A temporary string to hold status messages
        private string tempString = "";
        // The directory of the ECSA website server, this program assumes there will be subdirectories 'img', and 'json'
        private string serverDir = "//samba.srv.ualberta.ca/ecvhouse/public_html";

        /// <summary>
        /// Constructor for this form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.Text = "ECSA Website Contact Updater";

            // If we can't see the server directory, show a scary error
            if (!Directory.Exists(this.serverDir))
            {
                MessageBox.Show("Could not find server directory: " + this.serverDir +
                    "\n\nThis program will probably not work correctly unless it can find the server directory. Please make sure you have proper access to the ECSA website filesystem.",
                    "Can't Find Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Load what's currently on server, and display one of the positions
            this.LoadJson();
            this.SyncPositions();
            if (this.comboBoxPosition.Items.Count > 0)
            {
                this.comboBoxPosition.SelectedIndex = 0;
            }

            // Show any saved status message
            this.textBoxStatus.Text = this.tempString;
        }

        /// <summary>
        /// Gets the full path of the json file containing the Executive info
        /// </summary>
        public string JsonPath
        {
            get
            {
                return this.serverDir + "/json/" + this.jsonFile;
            }
        }

        /// <summary>
        /// Gets the directory where Executive images are stored
        /// </summary>
        public string ImgDir
        {
            get
            {
                return this.serverDir + "/img";
            }
        }

        /// <summary>
        /// A list of the current ECSA Executives
        /// </summary>
        public List<Executive> Executives { get; private set; }

        /// <summary>
        /// A list of the names of ECSA Executive Positions.
        /// </summary>
        /// <remarks>
        /// This is only useful to allow the user to edit the current positions in the collection editor.
        /// </remarks>
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        public List<ExecutivePosition> ExecutiveNames { get; private set; }

        /// <summary>
        /// Gets the current Executive given their position, or null if no Executive with the given position is found.
        /// </summary>
        /// <param name="position">
        /// The name of the position of the Executive to return.
        /// </param>
        /// <returns>
        /// The Executive with the given position, null if not found.
        /// </returns>
        private Executive GetExecutive(string position)
        {
            foreach (var exec in this.Executives)
            {
                if (exec.position == position)
                {
                    return exec;
                }
            }
            return null;
        }

        /// <summary>
        /// Loads the Executive json info file, and initializes the current list of Executives based on the file
        /// </summary>
        private void LoadJson()
        {
            this.Executives = new List<Executive>();
            this.ExecutiveNames = new List<ExecutivePosition>();
            StreamReader r = null;
            try
            {
                r = new StreamReader(this.JsonPath);
                string json = r.ReadToEnd();

                // Displays the json file in a textbox
                this.textBoxDebug.Text = json;
                JsonTextReader reader = new JsonTextReader(new StringReader(json));
                while (reader.Read())
                {
                    // Token is '{' representing an object
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        var exec = new Executive();
                        // Loop through all properties of current object
                        while (reader.Read() && reader.TokenType == JsonToken.PropertyName)
                        {
                            // Check the name of the property, and initialize the values of the Executive accordingly
                            switch ((String)reader.Value)
                            {
                                case "position":
                                    if (reader.Read() && reader.TokenType == JsonToken.String)
                                    {
                                        exec.position = reader.Value.ToString();
                                        this.ExecutiveNames.Add(new ExecutivePosition(exec.position));
                                    }
                                    break;

                                case "fullName":
                                    if (reader.Read() && reader.TokenType == JsonToken.String)
                                    {
                                        exec.fullName = reader.Value.ToString();
                                    }
                                    break;

                                case "email":
                                    if (reader.Read() && reader.TokenType == JsonToken.String)
                                    {
                                        exec.email = reader.Value.ToString();
                                    }
                                    break;

                                case "bio":
                                    if (reader.Read() && reader.TokenType == JsonToken.String)
                                    {
                                        exec.bio = reader.Value.ToString();
                                    }
                                    break;
                                case "imageUrl" :
                                    if (reader.Read() && reader.TokenType == JsonToken.String)
                                    {
                                        exec.imageUrl = reader.Value.ToString();
                                    }
                                    break;
                                default:
                                    // Found an irrelevant property, try to loop again to check next property
                                    reader.Read();
                                    break;
                            }
                        }
                        // Finished reading one Executive object
                        this.Executives.Add(exec);
                    }
                }
                // Successfully loaded the json file
                this.tempString = "Loaded file: " + this.JsonPath;
            }
            catch(Exception e)
            {
                // Could not load the json file, most likely couldn't find it on the server
                this.tempString = "Could not find file: " + this.JsonPath;
            }
            finally
            {
                if (r != null)
                {
                    r.Close();
                }
            }
        }

		/// <summary>
		/// Will overwrite the old ECSA constitution with the newly picked one.
		/// </summary>
		/// <remarks>
		/// This method should only be called after the user has selected the new constitution. Currently only called
		/// from openFileDialog2_FileOk() so that this.newFile exists
		/// </remarks>
		private void overwriteConstitution()
		{
			// Source is the new constitution (probably from local computer)
			// Target is the old constitution (hopefully on the server)
			string sourceDir = Path.GetDirectoryName(this.newFile);
			string sourceFile = Path.GetFileName(this.newFile);
			string targetDir = this.serverDir;
			string targetFile = this.oldFile;

			if (!Directory.Exists(targetDir))
			{
				// Couldn't find correct directory on the server
				this.textBoxStatus.Text = "Couldn't find " + targetDir + " folder to save constitution";
			}
			else if (!string.Concat(sourceDir, sourceFile).Equals(string.Concat(targetDir, targetFile)))
			{
				string source = sourceDir + "/" + sourceFile;
				string target = targetDir + "/" + targetFile;
				// Overwrite the file if it exists
				File.Copy(source, target, true);
				this.textBoxStatus.Text = "Saved file: " + sourceFile + " to: " + target;
			}
			else
			{
				// In case the user accidentally selects the current constitution on the server, this caused an error
				this.textBoxStatus.Text = "Tried to update constitution with itself";
			}
		}

        /// <summary>
        /// Will overwrite the old Executive picture with the newly picked one.
        /// </summary>
        /// <remarks>
        /// This method should only be called after the user has selected the new picture. Currently only called
        /// from openFileDialog1_FileOk() so that this.newFile exists
        /// </remarks>
        private void overwritePicture()
        {
            // Source is the new picture (probably from local computer)
            // Target is the old picture (hopefully on the server)
            string sourceDir = Path.GetDirectoryName(this.newFile);
            string sourceFile = Path.GetFileName(this.newFile);
            string targetDir = this.ImgDir;
            string targetFile = this.oldFile;

            if (!Directory.Exists(targetDir))
            {
                // Couldn't find correct directory on the server
                this.textBoxStatus.Text = "Couldn't find " + targetDir + " folder to save picture";
            }
            else if (!string.Concat(sourceDir, sourceFile).Equals(string.Concat(targetDir, targetFile)))
            {
                string source = sourceDir + "/" + sourceFile;
                string target = targetDir + "/" + targetFile;
                // Overwrite the file if it exists
                File.Copy(source, target, true);
                this.textBoxStatus.Text = "Saved file: " + sourceFile + " to: " + target;
            }
            else
            {
                // In case the user accidentally selects the current picture on the server, this caused an error
                this.textBoxStatus.Text = "Tried to update picture with itself";
            }
        }

        /// <summary>
        /// Will disable the UI buttons, to be used while saving
        /// </summary>
        private void DisableButtons()
        {
            this.buttonSaveUpdate.Enabled = false;
            this.buttonPositions.Enabled = false;
            this.buttonAbout.Enabled = false;
            this.buttonUpdatePicture.Enabled = false;
            this.comboBoxPosition.Enabled = false;
        }

        /// <summary>
        /// Will enable the UI buttons, to be used after save completed
        /// </summary>
        private void EnableButtons()
        {
            this.buttonSaveUpdate.Enabled = true;
            this.buttonPositions.Enabled = true;
            this.buttonAbout.Enabled = true;
            this.buttonUpdatePicture.Enabled = true;
            this.comboBoxPosition.Enabled = true;
        }

        /// <summary>
        /// Will save the current Executive info to the json file on the server
        /// </summary>
        private void Save()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.DisableButtons();
            // Updates the info for the currently selected Executive
            this.UpdateCurrentExec();

            foreach (var exec in this.Executives)
            {
                // Sets each Executive image URL
                exec.SetImageUrl();
            }

            // Get the json file for list of Executives, display in textbox
            string output = JsonConvert.SerializeObject(this.Executives, Newtonsoft.Json.Formatting.Indented);
            this.textBoxDebug.Text = output;
            StreamWriter outfile = null;
            try
            {
                // Try to get a writer to the json file on the server
                outfile = new StreamWriter(this.JsonPath);
                // Try to write to that file
                outfile.Write(output.ToString());
                this.textBoxStatus.Text = "Saved to file: " + this.JsonPath;
            }
            catch(Exception e)
            {
                // An error occurred trying to save to file, probably either couldn't find it or permissions problem
                this.textBoxStatus.Text = "Could not save to file: " + this.JsonPath;
            }
            finally
            {
                this.EnableButtons();
                Cursor.Current = Cursors.Default;
                if (outfile != null)
                {
                    outfile.Close();
                }
            }
        }

        /// <summary>
        /// Selects the combo box drop down item of the given position
        /// </summary>
        /// <param name="position">
        /// The name of the position to select
        /// </param>
        /// <remarks>
        /// This method will fire the comboBoxPosition_SelectedIndexChanged() event, which
        /// will update the information in the various textboxes according to this Executive info
        /// </remarks>
        private void SelectExec(string position)
        {
            // If more than one item
            if (this.comboBoxPosition.Items.Count > 0)
            {
                int index = this.comboBoxPosition.Items.IndexOf(position);
                if (index > 0)
                {
                    // If position exists, select it
                    this.comboBoxPosition.SelectedIndex = index;
                }
                else
                {
                    // Position doesn't exist, select first one instead
                    this.comboBoxPosition.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Synchronizes the Executives and ExecutiveNames lists based on names of positions in ExecutiveNames, and
        /// creates combo box items for these positions
        /// </summary>
        /// <remarks>
        /// Will remove any Executives with positions not in ExecutiveNames, and will create new Executives for any
        /// positions in ExecutiveNames that didn't exist
        /// </remarks>
        private void SyncPositions()
        {
            // Loop through all Executives, remove ones which don't have a position in ExecutiveNames
            for (int i = 0; i < this.Executives.Count; i++)
            {
                var exec = this.Executives[i];
                if (!this.ExecutiveNames.Exists(x => x.Name == exec.position))
                {
                    this.Executives.RemoveAt(i);
                    i--;
                }
            }

            // Loop through all ExecutiveNames, create a new Executive for each position that didn't exist
            foreach (var execName in this.ExecutiveNames)
            {
                string name = execName.Name;
                if (!this.Executives.Exists(x => x.position == name))
                {
                    var newExec = new Executive(name);
                    this.Executives.Add(newExec);
                }
            }

            // Update combo box items
            this.comboBoxPosition.Items.Clear();
            foreach (var exec in this.Executives)
            {
                this.comboBoxPosition.Items.Add(exec.position);
            }
        }

        /// <summary>
        /// Displays the given Executive info. Updates text in text boxes, and displays picture if found.
        /// </summary>
        /// <param name="exec">
        /// The executive to display info for.
        /// </param>
        private void DisplayExecInfo(Executive exec)
        {
            if (exec != null)
            {
                this.SetPicture(exec);
                this.textBoxFullName.Text = exec.fullName;
                this.textBoxEmail.Text = exec.email;
                this.textBoxBio.Text = exec.bio;
            }
            else
            {
                // Blank everything for null Executive
                this.pictureBox1.Image = null;
                this.textBoxFullName.Text = "";
                this.textBoxEmail.Text = "";
                this.textBoxBio.Text = "";
            }
        }

        /// <summary>
        /// Displays info for the currently selected Executive
        /// </summary>
        private void DisplaySelectedExecInfo()
        {
            // If there is at least one Executive
            if (this.comboBoxPosition.Items.Count > 0)
            {
                // Get the name of the Executive's position
                string position = this.comboBoxPosition.SelectedItem.ToString();
                // Try to find the Executive, will be null if not found
                var exec = this.Executives.FirstOrDefault(x => x.position == position);
                if (exec != null)
                {
                    // Display info for the existing Executive
                    this.DisplayExecInfo(exec);
                }
                else
                {
                    // Will blank the textboxes and picture box
                    this.DisplayExecInfo(null);
                }
            }
            else
            {
                // Zero Executive positions in combo box, so blank the info
                this.DisplayExecInfo(null);
            }
        }

        /// <summary>
        /// Displays the picture of the given Executive, or blank if picture not found
        /// </summary>
        /// <param name="exec">
        /// The Executive to display their picture
        /// </param>
        private void SetPicture(Executive exec)
        {
            // The expected full path of the picture file
            string imageFile = this.serverDir + "/" + exec.imageUrl;
            
            if (exec.imageUrl == "" || exec.imageUrl == null || exec.imageUrl.Length < 1)
            {
                // If the Executive is missing image file information
                this.textBoxStatus.Text = "Executive is missing image url";
                this.pictureBox1.Image = null;
            }
            else if (!File.Exists(imageFile))
            {
                // If the picture file could not be found - either doesn't exist or can't access server
                this.textBoxStatus.Text = "Could not find picture: " + imageFile;
                this.pictureBox1.Image = null;
            }
            else
            {
                // Read the picture file and update the picture box to display it
                this.pictureBox1.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(imageFile)));
            }
            
        }

        /// <summary>
        /// Updates the currently selected Executive based on the information in the text boxes
        /// </summary>
        private void UpdateCurrentExec()
        {
            // If we're on the correct tab, and there exists at least one Executive
            if (this.tabControl1.SelectedIndex == 0 && this.comboBoxPosition.Items.Count > 0)
            {
                // Get the currently selected Executive, and update its info based on text entered by user
                var currentExec = this.GetExecutive(this.comboBoxPosition.SelectedItem.ToString());
                currentExec.SetImageUrl();
                currentExec.fullName = this.textBoxFullName.Text;
                currentExec.email = this.textBoxEmail.Text;
                currentExec.bio = this.textBoxBio.Text;
            }
        }

        /// <summary>
        /// If the user clicks to update an Executive's picture, show a file picker, then display the new picture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// When the user selects a valid picture, openFileDialog1_FileOk() will call to overwrite the picture file,
        /// so it can then be displayed in this method after showing the file dialog
        /// </remarks>
        private void buttonUpdatePicture_Click(object sender, EventArgs e)
        {
            if (this.comboBoxPosition.Items.Count > 0)
            {
                // If we have at least one Executive, show a file picker
                var exec = this.GetExecutive(this.comboBoxPosition.SelectedItem.ToString());
                this.oldFile = Path.GetFileName(exec.imageUrl);
                this.openFileDialog1.InitialDirectory = Application.StartupPath;
                this.openFileDialog1.FileName = this.oldFile;
                this.openFileDialog1.ShowDialog();

                // Display the new picture
                this.SetPicture(exec);
            }
        }

		/// <summary>
		/// If the user clicks to update the constitution, display a file picker
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// When the user selects a valid constitution file, openFileDialog2_FileOk() will call to overwrite the constitution file
		/// </remarks>
		private void buttonConstitution_Click(object sender, EventArgs e)
		{
			this.oldFile = this.constitutionFile;
			this.openFileDialog2.InitialDirectory = Application.StartupPath;
			this.openFileDialog2.FileName = "Constitution.pdf";
			this.openFileDialog2.ShowDialog();
		}

        /// <summary>
        /// If the user selects a valid new picture file, overwrite the old picture on the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // The full path of picture selected by the user
            this.newFile = this.openFileDialog1.FileName;

            // Overwrite the old picture on the server with the new picture
            this.overwritePicture();
        }

		/// <summary>
		/// If the user selects a valid new constitution file, overwrite the old constitution on the server
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
		{
			// The full path of constitution selected by the user
			this.newFile = this.openFileDialog2.FileName;

			// Overwrite the old constitution on the server with the new constitution
			this.overwriteConstitution();
		}

        /// <summary>
        /// Called when the combo box selected index changes, either by the user or by code. Will display the
        /// info for the newly selected Executive
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Blank the status text
            this.textBoxStatus.Text = "";
            if (comboBoxPosition.Items.Count > 0)
            {
                // If we have at least one Executive, try to get it, and display its info
                var currentExec = this.GetExecutive(this.comboBoxPosition.SelectedItem.ToString());
                this.DisplayExecInfo(currentExec);
            }
        }

        /// <summary>
        /// If the user clicks back after viewing the About page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            // Blank the status text
            this.textBoxStatus.Text = "";

            // Go back to the main screen
            this.tabControl1.SelectedIndex = 0;
        }

        /// <summary>
        /// If the user clicks the Save button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveUpdate_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        /// <summary>
        /// If the user clicks to update the Executive Positions, will display a collection editor of all positions, then
        /// synch our list of Executives with this new list of positions, and try to display previously selected Executive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPositions_Click(object sender, EventArgs e)
        {
            // Update currently selected Executive in case the user had changed some textbox info
            this.UpdateCurrentExec();
            this.textBoxStatus.Text = "";

            // Number of Executives before updating Positions
            int oldNum = this.comboBoxPosition.Items.Count;
            string selectedExec = "";
            if (oldNum > 0)
            {
                // If there was at least one Executive, get its Position
                selectedExec = this.comboBoxPosition.SelectedItem.ToString();
            }

            // Displays a collection editor for the user to modify current Executive positions
            Editor.Edit(this, "ExecutiveNames");

            // Will update our list of Executives to remove outdated positions, and add new positions as required
            this.SyncPositions();

            // Number of Executives after updating
            int newNum = this.comboBoxPosition.Items.Count;

            if (oldNum == 0 && newNum > 0)
            {
                // If we used to have no positions, but now we have at least one, select the first one
                this.comboBoxPosition.SelectedIndex = 0;
            }
            else
            {
                // Otherwise try to select the previously selected Executive
                // If it no longer exists, it will select the first Executive instead
                this.SelectExec(selectedExec);
            }

            // Display info for the currently selected Executive
            this.DisplaySelectedExecInfo();
        }

        /// <summary>
        /// If the user clicks the About button, change to the page with About information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAbout_Click(object sender, EventArgs e)
        {
            // Blank the status text
            this.textBoxStatus.Text = "";

            // Display the About page
            this.tabControl1.SelectedIndex = 1;
        }

        /// <summary>
        /// If the combo box has acquired focus, the user has probably clicked it, and might be about to select a new Executive.
        /// This will update the currently selected Executive in case the user had made changes to the text boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxPosition_GotFocus(object sender, EventArgs e)
        {
            this.UpdateCurrentExec();
        }
    }
}
