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

namespace ECSAHelper
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> nameMap = new Dictionary<string, string>();
        private string oldFile = "oldfile";
        private string newFile = "newfile";

        public Form1()
        {
            InitializeComponent();
            this.Text = "ECSA Website Picture Updater";
            this.nameMap.Add("Vice President Communication", "VPComm");
            this.nameMap.Add("Vice President Finance", "VPFinance");
            this.nameMap.Add("Vice President House", "VPHouse");
            this.nameMap.Add("President", "President");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.oldFile = this.nameMap[this.comboBoxPosition.SelectedItem.ToString()] + ".jpg";
            this.openFileDialog1.InitialDirectory = Application.StartupPath;
            this.openFileDialog1.FileName = this.oldFile;
            this.openFileDialog1.ShowDialog();
        }

        /// <summary>
        /// Called when the user selects a word list file. It saves the file as the default
        /// word list, and then will load the words in the file.
        /// </summary>
        /// <param name="sender">
        /// The object calling this method
        /// </param>
        /// <param name="e">
        /// Arguments associated with this event
        /// </param>
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
            MessageBox.Show("sourceDir: " + sourceDir + ", sourceFile: " + sourceFile + ", targetDir: " + targetDir + ", targetFile: " + targetFile);
            File.Copy(Path.Combine(sourceDir, sourceFile), Path.Combine(targetDir, targetFile), true);
        }
    }
}
