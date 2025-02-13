﻿namespace BitChatApp
{
    partial class frmProfileManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProfileManager));
            this.label1 = new System.Windows.Forms.Label();
            this.lstProfiles = new System.Windows.Forms.ListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNewProfile = new System.Windows.Forms.Button();
            this.btnDeleteProfile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnImportProfile = new System.Windows.Forms.Button();
            this.btnExportProfile = new System.Windows.Forms.Button();
            this.btnReIssueProfile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.label1.Location = new System.Drawing.Point(18, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(554, 57);
            this.label1.TabIndex = 1;
            this.label1.Text = "Profile manager lets you access Mesh\r\nwith different profiles on the same compute" +
    "r.";
            // 
            // lstProfiles
            // 
            this.lstProfiles.FormattingEnabled = true;
            this.lstProfiles.IntegralHeight = false;
            this.lstProfiles.ItemHeight = 20;
            this.lstProfiles.Location = new System.Drawing.Point(22, 97);
            this.lstProfiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstProfiles.Name = "lstProfiles";
            this.lstProfiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstProfiles.Size = new System.Drawing.Size(426, 212);
            this.lstProfiles.Sorted = true;
            this.lstProfiles.TabIndex = 2;
            this.lstProfiles.SelectedIndexChanged += new System.EventHandler(this.lstProfiles_SelectedIndexChanged);
            this.lstProfiles.DoubleClick += new System.EventHandler(this.lstProfiles_DoubleClick);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(339, 354);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 35);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(460, 354);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 35);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.label2.Location = new System.Drawing.Point(18, 315);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(381, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select a profile from the list to access Bit Chat.";
            // 
            // btnNewProfile
            // 
            this.btnNewProfile.Location = new System.Drawing.Point(459, 97);
            this.btnNewProfile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNewProfile.Name = "btnNewProfile";
            this.btnNewProfile.Size = new System.Drawing.Size(112, 35);
            this.btnNewProfile.TabIndex = 6;
            this.btnNewProfile.Text = "&New";
            this.btnNewProfile.UseVisualStyleBackColor = true;
            this.btnNewProfile.Click += new System.EventHandler(this.btnNewProfile_Click);
            // 
            // btnDeleteProfile
            // 
            this.btnDeleteProfile.Enabled = false;
            this.btnDeleteProfile.Location = new System.Drawing.Point(459, 186);
            this.btnDeleteProfile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteProfile.Name = "btnDeleteProfile";
            this.btnDeleteProfile.Size = new System.Drawing.Size(112, 35);
            this.btnDeleteProfile.TabIndex = 8;
            this.btnDeleteProfile.Text = "&Delete";
            this.btnDeleteProfile.UseVisualStyleBackColor = true;
            this.btnDeleteProfile.Click += new System.EventHandler(this.btnDeleteProfile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Profiles";
            // 
            // btnImportProfile
            // 
            this.btnImportProfile.Location = new System.Drawing.Point(459, 231);
            this.btnImportProfile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImportProfile.Name = "btnImportProfile";
            this.btnImportProfile.Size = new System.Drawing.Size(112, 35);
            this.btnImportProfile.TabIndex = 9;
            this.btnImportProfile.Text = "&Import";
            this.btnImportProfile.UseVisualStyleBackColor = true;
            this.btnImportProfile.Click += new System.EventHandler(this.btnImportProfile_Click);
            // 
            // btnExportProfile
            // 
            this.btnExportProfile.Enabled = false;
            this.btnExportProfile.Location = new System.Drawing.Point(459, 275);
            this.btnExportProfile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExportProfile.Name = "btnExportProfile";
            this.btnExportProfile.Size = new System.Drawing.Size(112, 35);
            this.btnExportProfile.TabIndex = 10;
            this.btnExportProfile.Text = "&Export";
            this.btnExportProfile.UseVisualStyleBackColor = true;
            this.btnExportProfile.Click += new System.EventHandler(this.btnExportProfile_Click);
            // 
            // btnReIssueProfile
            // 
            this.btnReIssueProfile.Enabled = false;
            this.btnReIssueProfile.Location = new System.Drawing.Point(459, 142);
            this.btnReIssueProfile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReIssueProfile.Name = "btnReIssueProfile";
            this.btnReIssueProfile.Size = new System.Drawing.Size(112, 35);
            this.btnReIssueProfile.TabIndex = 7;
            this.btnReIssueProfile.Text = "&Reissue";
            this.btnReIssueProfile.UseVisualStyleBackColor = true;
            this.btnReIssueProfile.Click += new System.EventHandler(this.btnReIssueProfile_Click);
            // 
            // frmProfileManager
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(591, 402);
            this.Controls.Add(this.btnReIssueProfile);
            this.Controls.Add(this.btnExportProfile);
            this.Controls.Add(this.btnImportProfile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDeleteProfile);
            this.Controls.Add(this.btnNewProfile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lstProfiles);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProfileManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profile Manager - Technitium ";
            this.Load += new System.EventHandler(this.frmProfileManager_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProfileManager_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstProfiles;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNewProfile;
        private System.Windows.Forms.Button btnDeleteProfile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnImportProfile;
        private System.Windows.Forms.Button btnExportProfile;
        private System.Windows.Forms.Button btnReIssueProfile;
    }
}