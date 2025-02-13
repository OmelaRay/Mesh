﻿namespace BitChatApp
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.chkAccept = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtProfilePassword = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAllowOnlyLocalInvitations = new System.Windows.Forms.CheckBox();
            this.chkAllowInvitations = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbProxy = new System.Windows.Forms.ComboBox();
            this.chkProxyAuth = new System.Windows.Forms.CheckBox();
            this.txtProxyPass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProxyUser = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProxyPort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProxyAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkUPnP = new System.Windows.Forms.CheckBox();
            this.chkUseCRL = new System.Windows.Forms.CheckBox();
            this.txtTrackers = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseDLFolder = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDownloadFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCheckProxy = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.linkLabel1.Location = new System.Drawing.Point(225, 198);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(191, 20);
            this.linkLabel1.TabIndex = 40;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Read terms and condition";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // chkAccept
            // 
            this.chkAccept.AutoSize = true;
            this.chkAccept.Location = new System.Drawing.Point(230, 168);
            this.chkAccept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkAccept.Name = "chkAccept";
            this.chkAccept.Size = new System.Drawing.Size(266, 24);
            this.chkAccept.TabIndex = 37;
            this.chkAccept.Text = "I accept all terms and conditions.";
            this.chkAccept.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(9, 25);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(644, 51);
            this.label14.TabIndex = 38;
            this.label14.Text = "To protect from unauthorized access to your profile, enter a strong encryption pa" +
    "ssword below to stored your profile securely on this computer.";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(230, 128);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '#';
            this.txtConfirmPassword.Size = new System.Drawing.Size(328, 26);
            this.txtConfirmPassword.TabIndex = 36;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(86, 132);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(136, 20);
            this.label13.TabIndex = 35;
            this.label13.Text = "Confirm password";
            // 
            // txtProfilePassword
            // 
            this.txtProfilePassword.Location = new System.Drawing.Point(230, 88);
            this.txtProfilePassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProfilePassword.Name = "txtProfilePassword";
            this.txtProfilePassword.PasswordChar = '#';
            this.txtProfilePassword.Size = new System.Drawing.Size(328, 26);
            this.txtProfilePassword.TabIndex = 34;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(94, 92);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 20);
            this.label12.TabIndex = 33;
            this.label12.Text = "Profile password";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.chkAccept);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtProfilePassword);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtConfirmPassword);
            this.groupBox1.Location = new System.Drawing.Point(18, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(660, 308);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profile Password";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(9, 235);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(644, 69);
            this.label15.TabIndex = 41;
            this.label15.Text = resources.GetString("label15.Text");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAllowOnlyLocalInvitations);
            this.groupBox2.Controls.Add(this.chkAllowInvitations);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cmbProxy);
            this.groupBox2.Controls.Add(this.chkProxyAuth);
            this.groupBox2.Controls.Add(this.txtProxyPass);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtProxyUser);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtProxyPort);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtProxyAddress);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.chkUPnP);
            this.groupBox2.Controls.Add(this.chkUseCRL);
            this.groupBox2.Controls.Add(this.txtTrackers);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnBrowseDLFolder);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtDownloadFolder);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtPort);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(18, 335);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(660, 488);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Profile Settings";
            // 
            // chkAllowOnlyLocalInvitations
            // 
            this.chkAllowOnlyLocalInvitations.AutoSize = true;
            this.chkAllowOnlyLocalInvitations.Location = new System.Drawing.Point(180, 286);
            this.chkAllowOnlyLocalInvitations.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkAllowOnlyLocalInvitations.Name = "chkAllowOnlyLocalInvitations";
            this.chkAllowOnlyLocalInvitations.Size = new System.Drawing.Size(413, 24);
            this.chkAllowOnlyLocalInvitations.TabIndex = 7;
            this.chkAllowOnlyLocalInvitations.Text = "Allow Only Local (LAN or WiFi) Private Chat Invitations";
            this.chkAllowOnlyLocalInvitations.UseVisualStyleBackColor = true;
            // 
            // chkAllowInvitations
            // 
            this.chkAllowInvitations.AutoSize = true;
            this.chkAllowInvitations.Location = new System.Drawing.Point(152, 251);
            this.chkAllowInvitations.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkAllowInvitations.Name = "chkAllowInvitations";
            this.chkAllowInvitations.Size = new System.Drawing.Size(301, 24);
            this.chkAllowInvitations.TabIndex = 6;
            this.chkAllowInvitations.Text = "Allow Inbound Private Chat Invitations";
            this.chkAllowInvitations.UseVisualStyleBackColor = true;
            this.chkAllowInvitations.CheckedChanged += new System.EventHandler(this.chkAllowInvitations_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(52, 362);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 20);
            this.label9.TabIndex = 51;
            this.label9.Text = "Proxy Type";
            // 
            // cmbProxy
            // 
            this.cmbProxy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProxy.FormattingEnabled = true;
            this.cmbProxy.Items.AddRange(new object[] {
            "Proxy Disabled",
            "Http Proxy",
            "Socks 5 Proxy",
            "Socks 5 (Tor Network)"});
            this.cmbProxy.Location = new System.Drawing.Point(152, 357);
            this.cmbProxy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbProxy.Name = "cmbProxy";
            this.cmbProxy.Size = new System.Drawing.Size(248, 28);
            this.cmbProxy.TabIndex = 9;
            this.cmbProxy.SelectedIndexChanged += new System.EventHandler(this.cmbProxy_SelectedIndexChanged);
            // 
            // chkProxyAuth
            // 
            this.chkProxyAuth.AutoSize = true;
            this.chkProxyAuth.Location = new System.Drawing.Point(418, 360);
            this.chkProxyAuth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkProxyAuth.Name = "chkProxyAuth";
            this.chkProxyAuth.Size = new System.Drawing.Size(234, 24);
            this.chkProxyAuth.TabIndex = 12;
            this.chkProxyAuth.Text = "Enable Proxy Authentication";
            this.chkProxyAuth.UseVisualStyleBackColor = true;
            this.chkProxyAuth.CheckedChanged += new System.EventHandler(this.chkProxyAuth_CheckedChanged);
            // 
            // txtProxyPass
            // 
            this.txtProxyPass.Location = new System.Drawing.Point(502, 438);
            this.txtProxyPass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProxyPass.MaxLength = 255;
            this.txtProxyPass.Name = "txtProxyPass";
            this.txtProxyPass.PasswordChar = '#';
            this.txtProxyPass.Size = new System.Drawing.Size(142, 26);
            this.txtProxyPass.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(414, 443);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 50;
            this.label7.Text = "Password";
            // 
            // txtProxyUser
            // 
            this.txtProxyUser.Location = new System.Drawing.Point(502, 398);
            this.txtProxyUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProxyUser.MaxLength = 255;
            this.txtProxyUser.Name = "txtProxyUser";
            this.txtProxyUser.Size = new System.Drawing.Size(142, 26);
            this.txtProxyUser.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(411, 403);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 20);
            this.label8.TabIndex = 48;
            this.label8.Text = "Username";
            // 
            // txtProxyPort
            // 
            this.txtProxyPort.Location = new System.Drawing.Point(267, 438);
            this.txtProxyPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProxyPort.MaxLength = 5;
            this.txtProxyPort.Name = "txtProxyPort";
            this.txtProxyPort.Size = new System.Drawing.Size(66, 26);
            this.txtProxyPort.TabIndex = 11;
            this.txtProxyPort.Text = "1080";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(176, 443);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 20);
            this.label6.TabIndex = 46;
            this.label6.Text = "Proxy Port";
            // 
            // txtProxyAddress
            // 
            this.txtProxyAddress.Location = new System.Drawing.Point(267, 398);
            this.txtProxyAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProxyAddress.MaxLength = 255;
            this.txtProxyAddress.Name = "txtProxyAddress";
            this.txtProxyAddress.Size = new System.Drawing.Size(133, 26);
            this.txtProxyAddress.TabIndex = 10;
            this.txtProxyAddress.Text = "127.0.0.1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 403);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 44;
            this.label5.Text = "Proxy Address";
            // 
            // chkUPnP
            // 
            this.chkUPnP.AutoSize = true;
            this.chkUPnP.Location = new System.Drawing.Point(152, 322);
            this.chkUPnP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkUPnP.Name = "chkUPnP";
            this.chkUPnP.Size = new System.Drawing.Size(130, 24);
            this.chkUPnP.TabIndex = 8;
            this.chkUPnP.Text = "Enable UPnP";
            this.chkUPnP.UseVisualStyleBackColor = true;
            // 
            // chkUseCRL
            // 
            this.chkUseCRL.AutoSize = true;
            this.chkUseCRL.Location = new System.Drawing.Point(152, 215);
            this.chkUseCRL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkUseCRL.Name = "chkUseCRL";
            this.chkUseCRL.Size = new System.Drawing.Size(263, 24);
            this.chkUseCRL.TabIndex = 5;
            this.chkUseCRL.Text = "Check for Certificate Revocation";
            this.chkUseCRL.UseVisualStyleBackColor = true;
            // 
            // txtTrackers
            // 
            this.txtTrackers.Location = new System.Drawing.Point(152, 71);
            this.txtTrackers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTrackers.Multiline = true;
            this.txtTrackers.Name = "txtTrackers";
            this.txtTrackers.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTrackers.Size = new System.Drawing.Size(493, 93);
            this.txtTrackers.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "Default Trackers";
            // 
            // btnBrowseDLFolder
            // 
            this.btnBrowseDLFolder.Location = new System.Drawing.Point(567, 28);
            this.btnBrowseDLFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBrowseDLFolder.Name = "btnBrowseDLFolder";
            this.btnBrowseDLFolder.Size = new System.Drawing.Size(80, 34);
            this.btnBrowseDLFolder.TabIndex = 2;
            this.btnBrowseDLFolder.Text = "Bro&wse";
            this.btnBrowseDLFolder.UseVisualStyleBackColor = true;
            this.btnBrowseDLFolder.Click += new System.EventHandler(this.btnBrowseDLFolder_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 180);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(330, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "(set 0 for random; requires application restart)";
            // 
            // txtDownloadFolder
            // 
            this.txtDownloadFolder.Location = new System.Drawing.Point(152, 29);
            this.txtDownloadFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDownloadFolder.MaxLength = 255;
            this.txtDownloadFolder.Name = "txtDownloadFolder";
            this.txtDownloadFolder.ReadOnly = true;
            this.txtDownloadFolder.Size = new System.Drawing.Size(404, 26);
            this.txtDownloadFolder.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Download Folder";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(152, 175);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPort.MaxLength = 5;
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(80, 26);
            this.txtPort.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 180);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Incoming Port";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(444, 832);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(112, 35);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(566, 832);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 35);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCheckProxy
            // 
            this.btnCheckProxy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCheckProxy.Location = new System.Drawing.Point(18, 832);
            this.btnCheckProxy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCheckProxy.Name = "btnCheckProxy";
            this.btnCheckProxy.Size = new System.Drawing.Size(112, 35);
            this.btnCheckProxy.TabIndex = 3;
            this.btnCheckProxy.Text = "Check Proxy";
            this.btnCheckProxy.UseVisualStyleBackColor = true;
            this.btnCheckProxy.Click += new System.EventHandler(this.btnCheckProxy_Click);
            // 
            // frmSettings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(696, 878);
            this.Controls.Add(this.btnCheckProxy);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Profile Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox chkAccept;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtProfilePassword;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDownloadFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBrowseDLFolder;
        private System.Windows.Forms.CheckBox chkUseCRL;
        private System.Windows.Forms.TextBox txtTrackers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkUPnP;
        private System.Windows.Forms.TextBox txtProxyPass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProxyUser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtProxyPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProxyAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkProxyAuth;
        private System.Windows.Forms.Button btnCheckProxy;
        private System.Windows.Forms.ComboBox cmbProxy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkAllowInvitations;
        private System.Windows.Forms.CheckBox chkAllowOnlyLocalInvitations;
    }
}