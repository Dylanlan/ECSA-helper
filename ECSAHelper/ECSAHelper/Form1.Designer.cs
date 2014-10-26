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
            this.tabControl1 = new ECSAHelper.TablessTab();
            this.ListPositionsTab = new System.Windows.Forms.TabPage();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonEditAll = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonListPositions = new System.Windows.Forms.Button();
            this.UpdateTab = new System.Windows.Forms.TabPage();
            this.textBoxDebug = new System.Windows.Forms.TextBox();
            this.buttonSaveUpdate = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.textBoxBio = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.labelBio = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelPosition = new System.Windows.Forms.Label();
            this.comboBoxPosition = new System.Windows.Forms.ComboBox();
            this.buttonUpdatePicture = new System.Windows.Forms.Button();
            this.HelpTab = new System.Windows.Forms.TabPage();
            this.buttonBack2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.ListPositionsTab.SuspendLayout();
            this.UpdateTab.SuspendLayout();
            this.HelpTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ListPositionsTab);
            this.tabControl1.Controls.Add(this.UpdateTab);
            this.tabControl1.Controls.Add(this.HelpTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(892, 324);
            this.tabControl1.TabIndex = 0;
            // 
            // ListPositionsTab
            // 
            this.ListPositionsTab.Controls.Add(this.buttonHelp);
            this.ListPositionsTab.Controls.Add(this.buttonEditAll);
            this.ListPositionsTab.Controls.Add(this.buttonNext);
            this.ListPositionsTab.Controls.Add(this.label1);
            this.ListPositionsTab.Controls.Add(this.buttonListPositions);
            this.ListPositionsTab.Location = new System.Drawing.Point(4, 22);
            this.ListPositionsTab.Name = "ListPositionsTab";
            this.ListPositionsTab.Size = new System.Drawing.Size(884, 298);
            this.ListPositionsTab.TabIndex = 2;
            this.ListPositionsTab.Text = "List Positions";
            this.ListPositionsTab.UseVisualStyleBackColor = true;
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(233, 125);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(75, 23);
            this.buttonHelp.TabIndex = 5;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonEditAll
            // 
            this.buttonEditAll.Location = new System.Drawing.Point(233, 26);
            this.buttonEditAll.Name = "buttonEditAll";
            this.buttonEditAll.Size = new System.Drawing.Size(75, 23);
            this.buttonEditAll.TabIndex = 4;
            this.buttonEditAll.Text = "Edit All...";
            this.buttonEditAll.UseVisualStyleBackColor = true;
            this.buttonEditAll.Click += new System.EventHandler(this.buttonEditAll_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(353, 71);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please list the Executive positions:";
            // 
            // buttonListPositions
            // 
            this.buttonListPositions.Location = new System.Drawing.Point(233, 71);
            this.buttonListPositions.Name = "buttonListPositions";
            this.buttonListPositions.Size = new System.Drawing.Size(75, 23);
            this.buttonListPositions.TabIndex = 0;
            this.buttonListPositions.Text = "Positions...";
            this.buttonListPositions.UseVisualStyleBackColor = true;
            this.buttonListPositions.Click += new System.EventHandler(this.buttonListPositions_Click);
            // 
            // UpdateTab
            // 
            this.UpdateTab.Controls.Add(this.textBoxDebug);
            this.UpdateTab.Controls.Add(this.buttonSaveUpdate);
            this.UpdateTab.Controls.Add(this.buttonBack);
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
            this.UpdateTab.Size = new System.Drawing.Size(884, 298);
            this.UpdateTab.TabIndex = 0;
            this.UpdateTab.Text = "Update";
            this.UpdateTab.UseVisualStyleBackColor = true;
            // 
            // textBoxDebug
            // 
            this.textBoxDebug.Location = new System.Drawing.Point(283, 35);
            this.textBoxDebug.Multiline = true;
            this.textBoxDebug.Name = "textBoxDebug";
            this.textBoxDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDebug.Size = new System.Drawing.Size(595, 255);
            this.textBoxDebug.TabIndex = 17;
            // 
            // buttonSaveUpdate
            // 
            this.buttonSaveUpdate.Location = new System.Drawing.Point(193, 176);
            this.buttonSaveUpdate.Name = "buttonSaveUpdate";
            this.buttonSaveUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveUpdate.TabIndex = 16;
            this.buttonSaveUpdate.Text = "Save";
            this.buttonSaveUpdate.UseVisualStyleBackColor = true;
            this.buttonSaveUpdate.Click += new System.EventHandler(this.buttonSaveUpdate_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(87, 176);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 15;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // textBoxBio
            // 
            this.textBoxBio.Location = new System.Drawing.Point(87, 122);
            this.textBoxBio.Name = "textBoxBio";
            this.textBoxBio.Size = new System.Drawing.Size(181, 20);
            this.textBoxBio.TabIndex = 9;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(87, 82);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(181, 20);
            this.textBoxEmail.TabIndex = 8;
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Location = new System.Drawing.Point(87, 42);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(181, 20);
            this.textBoxFullName.TabIndex = 7;
            // 
            // labelBio
            // 
            this.labelBio.AutoSize = true;
            this.labelBio.Location = new System.Drawing.Point(8, 129);
            this.labelBio.Name = "labelBio";
            this.labelBio.Size = new System.Drawing.Size(25, 13);
            this.labelBio.TabIndex = 5;
            this.labelBio.Text = "Bio:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(8, 89);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(35, 13);
            this.labelEmail.TabIndex = 4;
            this.labelEmail.Text = "Email:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(8, 49);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(57, 13);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "Full Name:";
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(8, 12);
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
            this.comboBoxPosition.Size = new System.Drawing.Size(181, 21);
            this.comboBoxPosition.TabIndex = 1;
            this.comboBoxPosition.SelectedIndexChanged += new System.EventHandler(this.comboBoxPosition_SelectedIndexChanged);
            // 
            // buttonUpdatePicture
            // 
            this.buttonUpdatePicture.Location = new System.Drawing.Point(283, 6);
            this.buttonUpdatePicture.Name = "buttonUpdatePicture";
            this.buttonUpdatePicture.Size = new System.Drawing.Size(102, 23);
            this.buttonUpdatePicture.TabIndex = 0;
            this.buttonUpdatePicture.Text = "Update Picture...";
            this.buttonUpdatePicture.UseVisualStyleBackColor = true;
            this.buttonUpdatePicture.Click += new System.EventHandler(this.buttonUpdatePicture_Click);
            // 
            // HelpTab
            // 
            this.HelpTab.Controls.Add(this.buttonBack2);
            this.HelpTab.Controls.Add(this.textBox1);
            this.HelpTab.Location = new System.Drawing.Point(4, 22);
            this.HelpTab.Name = "HelpTab";
            this.HelpTab.Size = new System.Drawing.Size(884, 298);
            this.HelpTab.TabIndex = 3;
            this.HelpTab.Text = "Help";
            this.HelpTab.UseVisualStyleBackColor = true;
            // 
            // buttonBack2
            // 
            this.buttonBack2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBack2.Location = new System.Drawing.Point(349, 267);
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
            this.ClientSize = new System.Drawing.Size(892, 324);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.ListPositionsTab.ResumeLayout(false);
            this.ListPositionsTab.PerformLayout();
            this.UpdateTab.ResumeLayout(false);
            this.UpdateTab.PerformLayout();
            this.HelpTab.ResumeLayout(false);
            this.HelpTab.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TabPage ListPositionsTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonListPositions;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonEditAll;
        private System.Windows.Forms.Button buttonSaveUpdate;
        private System.Windows.Forms.TextBox textBoxDebug;
        private System.Windows.Forms.TabPage HelpTab;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonBack2;
    }
}

