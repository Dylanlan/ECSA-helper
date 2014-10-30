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
    public partial class Form1 : Form
    {
        private string oldFile = "oldfile";
        private string newFile = "newfile";
        private string jsonFile = "executives.json";
        private string tempString = "";
        private string serverDir = "//samba.srv.ualberta.ca/ecvhouse/public_html/Old Website/test";

        public Form1()
        {
            InitializeComponent();
            this.LoadJson();
            this.SyncPositions();
            if (this.comboBoxPosition.Items.Count > 0)
            {
                this.comboBoxPosition.SelectedIndex = 0;
            }

            this.textBoxStatus.Text = this.tempString;
            this.Text = "ECSA Website Contact Updater";
        }

        public string JsonPath
        {
            get
            {
                return this.serverDir + "/json/" + this.jsonFile;
            }
        }

        public string ImgDir
        {
            get
            {
                return this.serverDir + "/img";
            }
        }

        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        public List<Executive> Executives { get; private set; }

        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        public List<ExecutiveName> ExecutiveNames { get; private set; }

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

        private string GetImageFileName(string position)
        {
            return position.Replace(" ", string.Empty);
        }

        private void LoadJson()
        {
            this.Executives = new List<Executive>();
            this.ExecutiveNames = new List<ExecutiveName>();
            StreamReader r = null;
            try
            {
                r = new StreamReader(this.JsonPath);
                string json = r.ReadToEnd();
                this.textBoxDebug.Text = json;
                JsonTextReader reader = new JsonTextReader(new StringReader(json));
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        var exec = new Executive();
                        while (reader.Read() && reader.TokenType == JsonToken.PropertyName)
                        {
                            switch ((String)reader.Value)
                            {
                                case "position":
                                    if (reader.Read() && reader.TokenType == JsonToken.String)
                                    {
                                        exec.position = reader.Value.ToString();
                                        this.ExecutiveNames.Add(new ExecutiveName(exec.position));
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
                                    reader.Read();
                                    break;
                            }
                        }
                        this.Executives.Add(exec);
                    }
                }
                this.tempString = "Loaded file: " + this.JsonPath;
            }
            catch(Exception e)
            {
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

        private void buttonUpdatePicture_Click(object sender, EventArgs e)
        {
            if (this.comboBoxPosition.Items.Count > 0)
            {
                var exec = this.GetExecutive(this.comboBoxPosition.SelectedItem.ToString());
                this.oldFile = Path.GetFileName(exec.imageUrl);
                this.openFileDialog1.InitialDirectory = Application.StartupPath;
                this.openFileDialog1.FileName = this.oldFile;
                this.openFileDialog1.ShowDialog();
                this.SetPicture(exec);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.newFile = this.openFileDialog1.FileName;
            this.overwritePicture();
        }

        private void overwritePicture()
        {
            string sourceDir = Path.GetDirectoryName(this.newFile);
            string sourceFile = Path.GetFileName(this.newFile);
            string targetDir = this.ImgDir;
            string targetFile = this.oldFile;

            if (!Directory.Exists(targetDir))
            {
                this.textBoxStatus.Text = "Couldn't find " + targetDir + " folder to save picture";
            }
            else if (!string.Concat(sourceDir, sourceFile).Equals(string.Concat(targetDir, targetFile)))
            {
                string source = sourceDir + "/" + sourceFile;
                string target = targetDir + "/" + targetFile;
                File.Copy(source, target, true);
                this.textBoxStatus.Text = "Saved file: " + sourceFile + " to: " + target;
            }
            else
            {
                this.textBoxStatus.Text = "Tried to update picture with itself";
            }
        }

        void comboBoxPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBoxStatus.Text = "";
            if (comboBoxPosition.Items.Count > 0)
            {
                var currentExec = this.GetExecutive(this.comboBoxPosition.SelectedItem.ToString());
                this.DisplayExecInfo(currentExec);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.textBoxStatus.Text = "";
            this.tabControl1.SelectedIndex = 0;
        }

        private void buttonSaveUpdate_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void Save()
        {
            this.UpdateCurrentExec();

            foreach (var exec in this.Executives)
            {
                exec.imageUrl = "img/" + this.GetImageFileName(exec.position) + ".jpg";
            }

            string output = JsonConvert.SerializeObject(this.Executives, Newtonsoft.Json.Formatting.Indented);
            this.textBoxDebug.Text = output;
            StreamWriter outfile = null;
            try
            {
                outfile = new StreamWriter(this.JsonPath);
                outfile.Write(output.ToString());
                this.textBoxStatus.Text = "Saved to file: " + this.JsonPath;
            }
            catch(Exception e)
            {
                this.textBoxStatus.Text = "Could not save to file: " + this.JsonPath;
            }
            finally
            {
                outfile.Close();
            }
        }

        private void buttonPositions_Click(object sender, EventArgs e)
        {
            this.UpdateCurrentExec();
            this.textBoxStatus.Text = "";
            int oldNum = this.comboBoxPosition.Items.Count;
            string selectedExec = "";
            if (oldNum > 0)
            {
                selectedExec = this.comboBoxPosition.SelectedItem.ToString();
            }

            Editor.Edit(this, "ExecutiveNames");

            this.SyncPositions();
            int newNum = this.comboBoxPosition.Items.Count;

            if (oldNum == 0 && newNum > 0)
            {
                this.comboBoxPosition.SelectedIndex = 0;
            }
            else
            {
                this.SelectExec(selectedExec);
            }

            this.DisplaySelectedExecInfo();
        }

        private void SelectExec(string position)
        {
            if (this.comboBoxPosition.Items.Count > 0)
            {
                int index = this.comboBoxPosition.Items.IndexOf(position);
                if (index > 0)
                {
                    this.comboBoxPosition.SelectedIndex = index;
                }
                else
                {
                    this.comboBoxPosition.SelectedIndex = 0;
                }
            }
        }

        private void SyncPositions()
        {
            for (int i = 0; i < this.Executives.Count; i++)
            {
                var exec = this.Executives[i];
                if (!this.ExecutiveNames.Exists(x => x.Name == exec.position))
                {
                    this.Executives.RemoveAt(i);
                    i--;
                }
            }

            foreach (var execName in this.ExecutiveNames)
            {
                string name = execName.Name;
                if (!this.Executives.Exists(x => x.position == name))
                {
                    var newExec = new Executive(name);
                    this.Executives.Add(newExec);
                }
            }

            this.comboBoxPosition.Items.Clear();
            foreach (var exec in this.Executives)
            {
                this.comboBoxPosition.Items.Add(exec.position);
            }
        }

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
                this.pictureBox1.Image = null;
                this.textBoxFullName.Text = "";
                this.textBoxEmail.Text = "";
                this.textBoxBio.Text = "";
            }
        }

        private void DisplaySelectedExecInfo()
        {
            if (this.comboBoxPosition.Items.Count > 0)
            {
                string position = this.comboBoxPosition.SelectedItem.ToString();
                var exec = this.Executives.FirstOrDefault(x => x.position == position);
                if (exec != null)
                {
                    this.DisplayExecInfo(exec);
                }
                else
                {
                    this.DisplayExecInfo(null);
                }
            }
            else
            {
                this.DisplayExecInfo(null);
            }
        }

        private void SetPicture(Executive exec)
        {
            string imageFile = this.serverDir + "/" + exec.imageUrl;
            
            if (exec.imageUrl == "" || exec.imageUrl.Length < 1)
            {
                this.textBoxStatus.Text = "Executive is missing image url";
                this.pictureBox1.Image = null;
            }
            else if (!File.Exists(imageFile))
            {
                this.textBoxStatus.Text = "Could not find picture: " + imageFile;
                this.pictureBox1.Image = null;
            }
            else
            {
                this.pictureBox1.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(imageFile)));
            }
            
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            this.textBoxStatus.Text = "";
            this.tabControl1.SelectedIndex = 1;
        }

        private void comboBoxPosition_GotFocus(object sender, EventArgs e)
        {
            this.UpdateCurrentExec();
        }

        private void UpdateCurrentExec()
        {
            if (this.tabControl1.SelectedIndex == 0 && this.comboBoxPosition.Items.Count > 0)
            {
                var currentExec = this.GetExecutive(this.comboBoxPosition.SelectedItem.ToString());
                currentExec.imageUrl = "img/" + this.GetImageFileName(currentExec.position) + ".jpg";
                currentExec.fullName = this.textBoxFullName.Text;
                currentExec.email = this.textBoxEmail.Text;
                currentExec.bio = this.textBoxBio.Text;
            }
        }
    }
}
