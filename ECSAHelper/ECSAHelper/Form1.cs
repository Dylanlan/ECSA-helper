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

        public Form1()
        {
            InitializeComponent();
            this.LoadJson();
            this.Text = "ECSA Website Contact Updater";
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
                r = new StreamReader(this.jsonFile);
                string json = r.ReadToEnd();
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
                                        //string position = exec.position;
                                        //var nameNoSpaces = position.Replace(" ", string.Empty);
                                        //nameMap.Add(position, nameNoSpaces);
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
                this.textBoxStatus.Text = "Loaded file: " + this.jsonFile;
            }
            catch(Exception e)
            {
                this.textBoxStatus.Text = "Could not find file: " + this.jsonFile;
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
                this.oldFile = this.GetImageFileName(exec.position) + ".jpg";
                this.openFileDialog1.InitialDirectory = Application.StartupPath;
                this.openFileDialog1.FileName = this.oldFile;
                this.openFileDialog1.ShowDialog();
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
            string targetDir = Application.StartupPath;
            string targetFile = this.oldFile;
            
            if (!string.Concat(sourceDir, sourceFile).Equals(string.Concat(targetDir, targetFile)))
            {
                File.Copy(Path.Combine(sourceDir, sourceFile), Path.Combine(targetDir, targetFile), true);
                this.textBoxStatus.Text = "Saved file: " + sourceFile + " as: " + targetDir + "\\" + targetFile;
            }
            else
            {
                this.textBoxStatus.Text = "Trying to update file with itself";
            }
        }

        private void buttonEditAll_Click(object sender, EventArgs e)
        {
            this.textBoxStatus.Text = "";
            Editor.Edit(this, "Executives");
            this.ExecutiveNames.Clear();
            foreach(var exec in this.Executives)
            {
                this.ExecutiveNames.Add(new ExecutiveName(exec.position));
            }
        }

        private void buttonListPositions_Click(object sender, EventArgs e)
        {
            this.textBoxStatus.Text = "";
            Editor.Edit(this, "ExecutiveNames");

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
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.textBoxStatus.Text = "";
            this.tabControl1.SelectedIndex = 1;

            this.comboBoxPosition.Items.Clear();
            foreach (var exec in this.Executives)
            {
                this.comboBoxPosition.Items.Add(exec.position);
            }

            if (this.comboBoxPosition.Items.Count > 0)
            {
                this.comboBoxPosition.SelectedIndex = 0;
            }

            foreach (var exec in this.Executives)
            {
                if (exec.position == this.comboBoxPosition.SelectedItem.ToString())
                {
                        this.textBoxFullName.Text = exec.fullName;
                        this.textBoxEmail.Text = exec.email;
                        this.textBoxBio.Text = exec.bio;
                }
            }
        }

        void comboBoxPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var exec in this.Executives)
            {
                if (exec.position.Equals(this.comboBoxPosition.SelectedItem.ToString()))
                {
                    this.textBoxFullName.Text = exec.fullName;
                    this.textBoxEmail.Text = exec.email;
                    this.textBoxBio.Text = exec.bio;
                }
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
            if (this.tabControl1.SelectedIndex == 1 && this.comboBoxPosition.Items.Count > 0)
            {
                var currentExec = this.GetExecutive(this.comboBoxPosition.SelectedItem.ToString());
                currentExec.fullName = this.textBoxFullName.Text;
                currentExec.email = this.textBoxEmail.Text;
                currentExec.bio = this.textBoxBio.Text;
            }

            foreach (var exec in this.Executives)
            {
                exec.imageUrl = "img/" + this.GetImageFileName(exec.position) + ".jpg";
            }

            string output = JsonConvert.SerializeObject(this.Executives, Newtonsoft.Json.Formatting.Indented);
            this.textBoxDebug.Text = output;
            using (StreamWriter outfile = new StreamWriter("executives.json"))
            {
                outfile.Write(output.ToString());
                this.textBoxStatus.Text = "Saved to file: " + this.jsonFile;
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 2;
        }

        private void buttonSave2_Click(object sender, EventArgs e)
        {
            this.Save();
        }
    }
}
