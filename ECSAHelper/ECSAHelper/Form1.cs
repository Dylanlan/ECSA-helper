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
        private string presidentPictureFile = "President.jpg";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.InitialDirectory = Application.StartupPath;
            this.openFileDialog1.FileName = "President.jpg";
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
            this.presidentPictureFile = this.openFileDialog1.FileName;
            this.overwritePicture();
        }

        private void overwritePicture()
        {
            
            string sourceDir = Path.GetDirectoryName(this.presidentPictureFile);
            string sourceFile = Path.GetFileName(this.presidentPictureFile);
            string targetDir = Application.StartupPath;
            string targetFile = "President.jpg";
            MessageBox.Show("sourceDir: " + sourceDir + ", sourceFile: " + sourceFile + ", targetDir: " + targetDir + ", targetFile: " + targetFile);
            File.Copy(Path.Combine(sourceDir, sourceFile), Path.Combine(targetDir, targetFile), true);
        }
    }
}
