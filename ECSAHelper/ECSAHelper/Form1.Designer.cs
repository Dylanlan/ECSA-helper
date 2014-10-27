namespace ECSAHelper
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.tabControl1 = new ECSAHelper.TablessTab();
            this.UpdateTab = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelPicture = new System.Windows.Forms.Label();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.buttonPositions = new System.Windows.Forms.Button();
            this.textBoxDebug = new System.Windows.Forms.TextBox();
            this.buttonSaveUpdate = new System.Windows.Forms.Button();
            this.textBoxBio = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.labelBio = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelPosition = new System.Windows.Forms.Label();
            this.comboBoxPosition = new System.Windows.Forms.ComboBox();
            this.buttonUpdatePicture = new System.Windows.Forms.Button();
            this.AboutTab = new System.Windows.Forms.TabPage();
            this.buttonBack2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.UpdateTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.AboutTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "Choose New Picture";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxStatus.Location = new System.Drawing.Point(0, 388);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(892, 20);
            this.textBoxStatus.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.UpdateTab);
            this.tabControl1.Controls.Add(this.AboutTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(892, 382);
            this.tabControl1.TabIndex = 0;
            // 
            // UpdateTab
            // 
            this.UpdateTab.Controls.Add(this.pictureBox1);
            this.UpdateTab.Controls.Add(this.labelPicture);
            this.UpdateTab.Controls.Add(this.buttonAbout);
            this.UpdateTab.Controls.Add(this.buttonPositions);
            this.UpdateTab.Controls.Add(this.textBoxDebug);
            this.UpdateTab.Controls.Add(this.buttonSaveUpdate);
            this.UpdateTab.Controls.Add(this.textBoxBio);
            this.UpdateTab.Controls.Add(this.textBoxEmail);
            this.UpdateTab.Controls.Add(this.textBoxFullName);
            this.UpdateTab.Controls.Add(this.labelBio);
            this.UpdateTab.Controls.Add(this.labelEmail);
            this.UpdateTab.Controls.Add(this.labelName);
            this.UpdateTab.Controls.Add(this.labelPosition);
            this.UpdateTab.Controls.Add(this.comboBoxPosition);
            this.UpdateTab.Controls.Add(this.buttonUpdatePicture);
            this.UpdateTab.Location = new System.Drawing.Point(4, 22);
            this.UpdateTab.Name = "UpdateTab";
            this.UpdateTab.Padding = new System.Windows.Forms.Padding(3);
            this.UpdateTab.Size = new System.Drawing.Size(884, 356);
            this.UpdateTab.TabIndex = 0;
            this.UpdateTab.Text = "Update";
            this.UpdateTab.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(87, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // labelPicture
            // 
            this.labelPicture.AutoSize = true;
            this.labelPicture.Location = new System.Drawing.Point(8, 37);
            this.labelPicture.Name = "labelPicture";
            this.labelPicture.Size = new System.Drawing.Size(43, 13);
            this.labelPicture.TabIndex = 20;
            this.labelPicture.Text = "Picture:";
            // 
            // buttonAbout
            // 
            this.buttonAbout.Location = new System.Drawing.Point(168, 327);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(75, 23);
            this.buttonAbout.TabIndex = 19;
            this.buttonAbout.Text = "About";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // buttonPositions
            // 
            this.buttonPositions.Location = new System.Drawing.Point(382, 6);
            this.buttonPositions.Name = "buttonPositions";
            this.buttonPositions.Size = new System.Drawing.Size(99, 23);
            this.buttonPositions.TabIndex = 18;
            this.buttonPositions.Text = "Positions...";
            this.buttonPositions.UseVisualStyleBackColor = true;
            this.buttonPositions.Click += new System.EventHandler(this.buttonPositions_Click);
            // 
            // textBoxDebug
            // 
            this.textBoxDebug.Location = new System.Drawing.Point(382, 95);
            this.textBoxDebug.Multiline = true;
            this.textBoxDebug.Name = "textBoxDebug";
            this.textBoxDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDebug.Size = new System.Drawing.Size(496, 255);
            this.textBoxDebug.TabIndex = 17;
            // 
            // buttonSaveUpdate
            // 
            this.buttonSaveUpdate.Location = new System.Drawing.Point(87, 327);
            this.buttonSaveUpdate.Name = "buttonSaveUpdate";
            this.buttonSaveUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveUpdate.TabIndex = 16;
            this.buttonSaveUpdate.Text = "Save";
            this.buttonSaveUpdate.UseVisualStyleBackColor = true;
            this.buttonSaveUpdate.Click += new System.EventHandler(this.buttonSaveUpdate_Click);
            // 
            // textBoxBio
            // 
            this.textBoxBio.Location = new System.Drawing.Point(87, 191);
            this.textBoxBio.Multiline = true;
            this.textBoxBio.Name = "textBoxBio";
            this.textBoxBio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxBio.Size = new System.Drawing.Size(289, 130);
            this.textBoxBio.TabIndex = 9;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(87, 158);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(289, 20);
            this.textBoxEmail.TabIndex = 8;
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Location = new System.Drawing.Point(87, 127);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(289, 20);
            this.textBoxFullName.TabIndex = 7;
            // 
            // labelBio
            // 
            this.labelBio.AutoSize = true;
            this.labelBio.Location = new System.Drawing.Point(8, 191);
            this.labelBio.Name = "labelBio";
            this.labelBio.Size = new System.Drawing.Size(57, 13);
            this.labelBio.TabIndex = 5;
            this.labelBio.Text = "Biography:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(8, 165);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(35, 13);
            this.labelEmail.TabIndex = 4;
            this.labelEmail.Text = "Email:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(8, 134);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(57, 13);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "Full Name:";
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(8, 11);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(47, 13);
            this.labelPosition.TabIndex = 2;
            this.labelPosition.Text = "Position:";
            // 
            // comboBoxPosition
            // 
            this.comboBoxPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPosition.FormattingEnabled = true;
            this.comboBoxPosition.Items.AddRange(new object[] {
            "Vice President Communication",
            "Vice President Finance",
            "Vice President House",
            "President"});
            this.comboBoxPosition.Location = new System.Drawing.Point(87, 6);
            this.comboBoxPosition.Name = "comboBoxPosition";
            this.comboBoxPosition.Size = new System.Drawing.Size(289, 21);
            this.comboBoxPosition.TabIndex = 1;
            this.comboBoxPosition.SelectedIndexChanged += new System.EventHandler(this.comboBoxPosition_SelectedIndexChanged);
            this.comboBoxPosition.GotFocus += new System.EventHandler(this.comboBoxPosition_GotFocus);
            // 
            // buttonUpdatePicture
            // 
            this.buttonUpdatePicture.Location = new System.Drawing.Point(193, 62);
            this.buttonUpdatePicture.Name = "buttonUpdatePicture";
            this.buttonUpdatePicture.Size = new System.Drawing.Size(102, 23);
            this.buttonUpdatePicture.TabIndex = 0;
            this.buttonUpdatePicture.Text = "Update Picture...";
            this.buttonUpdatePicture.UseVisualStyleBackColor = true;
            this.buttonUpdatePicture.Click += new System.EventHandler(this.buttonUpdatePicture_Click);
            // 
            // AboutTab
            // 
            this.AboutTab.Controls.Add(this.buttonBack2);
            this.AboutTab.Controls.Add(this.textBox1);
            this.AboutTab.Location = new System.Drawing.Point(4, 22);
            this.AboutTab.Name = "AboutTab";
            this.AboutTab.Size = new System.Drawing.Size(884, 356);
            this.AboutTab.TabIndex = 3;
            this.AboutTab.Text = "About";
            this.AboutTab.UseVisualStyleBackColor = true;
            // 
            // buttonBack2
            // 
            this.buttonBack2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBack2.Location = new System.Drawing.Point(8, 300);
            this.buttonBack2.Name = "buttonBack2";
            this.buttonBack2.Size = new System.Drawing.Size(75, 23);
            this.buttonBack2.TabIndex = 0;
            this.buttonBack2.Text = "Back";
            this.buttonBack2.UseVisualStyleBackColor = true;
            this.buttonBack2.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(878, 236);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 408);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.UpdateTab.ResumeLayout(false);
            this.UpdateTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.AboutTab.ResumeLayout(false);
            this.AboutTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage UpdateTab;
        private TablessTab tabControl1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonUpdatePicture;
        private System.Windows.Forms.ComboBox comboBoxPosition;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.TextBox textBoxBio;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.Label labelBio;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonSaveUpdate;
        private System.Windows.Forms.TextBox textBoxDebug;
        private System.Windows.Forms.TabPage AboutTab;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonBack2;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Button buttonPositions;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelPicture;
    }
}

