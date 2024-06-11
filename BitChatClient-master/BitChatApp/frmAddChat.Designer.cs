namespace BitChatApp
{
    partial class frmAddChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddChat));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNetworkNameOrPeerEmailAddress = new System.Windows.Forms.TextBox();
            this.txtSharedSecret = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkLANChat = new System.Windows.Forms.CheckBox();
            this.chkSendInvitation = new System.Windows.Forms.CheckBox();
            this.txtInvitationMessage = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkDhtOnlyTracking = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(57, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chat Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtNetworkNameOrPeerEmailAddress
            // 
            this.txtNetworkNameOrPeerEmailAddress.Location = new System.Drawing.Point(237, 18);
            this.txtNetworkNameOrPeerEmailAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNetworkNameOrPeerEmailAddress.MaxLength = 50;
            this.txtNetworkNameOrPeerEmailAddress.Name = "txtNetworkNameOrPeerEmailAddress";
            this.txtNetworkNameOrPeerEmailAddress.Size = new System.Drawing.Size(308, 26);
            this.txtNetworkNameOrPeerEmailAddress.TabIndex = 1;
            // 
            // txtSharedSecret
            // 
            this.txtSharedSecret.Location = new System.Drawing.Point(237, 86);
            this.txtSharedSecret.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSharedSecret.MaxLength = 50;
            this.txtSharedSecret.Name = "txtSharedSecret";
            this.txtSharedSecret.PasswordChar = '#';
            this.txtSharedSecret.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSharedSecret.Size = new System.Drawing.Size(308, 26);
            this.txtSharedSecret.TabIndex = 3;
            this.txtSharedSecret.TextChanged += new System.EventHandler(this.txtSharedSecret_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Shared Secret / Password";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(446, 342);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(112, 35);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "&Add";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(567, 342);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "(case insensitive, example: Friends)";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(18, 332);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(398, 40);
            this.label4.TabIndex = 7;
            this.label4.Text = "All chat participants must use same Chat Name and Shared Secret combination.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 122);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "(optional but, recommended)";
            // 
            // chkLANChat
            // 
            this.chkLANChat.AutoSize = true;
            this.chkLANChat.Location = new System.Drawing.Point(237, 154);
            this.chkLANChat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkLANChat.Name = "chkLANChat";
            this.chkLANChat.Size = new System.Drawing.Size(346, 24);
            this.chkLANChat.TabIndex = 4;
            this.chkLANChat.Text = "Enable only local network (LAN or WiFi) chat";
            this.chkLANChat.UseVisualStyleBackColor = true;
            this.chkLANChat.CheckedChanged += new System.EventHandler(this.chkLANChat_CheckedChanged);
            // 
            // chkSendInvitation
            // 
            this.chkSendInvitation.AutoSize = true;
            this.chkSendInvitation.Checked = true;
            this.chkSendInvitation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSendInvitation.Location = new System.Drawing.Point(237, 225);
            this.chkSendInvitation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkSendInvitation.Name = "chkSendInvitation";
            this.chkSendInvitation.Size = new System.Drawing.Size(141, 24);
            this.chkSendInvitation.TabIndex = 6;
            this.chkSendInvitation.Text = "Send Invitation";
            this.chkSendInvitation.UseVisualStyleBackColor = true;
            this.chkSendInvitation.CheckedChanged += new System.EventHandler(this.chkSendInvitation_CheckedChanged);
            // 
            // txtInvitationMessage
            // 
            this.txtInvitationMessage.Location = new System.Drawing.Point(237, 260);
            this.txtInvitationMessage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtInvitationMessage.MaxLength = 255;
            this.txtInvitationMessage.Name = "txtInvitationMessage";
            this.txtInvitationMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInvitationMessage.Size = new System.Drawing.Size(308, 26);
            this.txtInvitationMessage.TabIndex = 7;
            this.txtInvitationMessage.Text = "Hi! Please accept my chat invitation.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 265);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Invitation Message";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(232, 295);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(427, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "(Warning! Invitation messages are not securely transmitted)";
            // 
            // chkDhtOnlyTracking
            // 
            this.chkDhtOnlyTracking.AutoSize = true;
            this.chkDhtOnlyTracking.Location = new System.Drawing.Point(237, 189);
            this.chkDhtOnlyTracking.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDhtOnlyTracking.Name = "chkDhtOnlyTracking";
            this.chkDhtOnlyTracking.Size = new System.Drawing.Size(193, 24);
            this.chkDhtOnlyTracking.TabIndex = 5;
            this.chkDhtOnlyTracking.Text = "Use only DHT tracking";
            this.chkDhtOnlyTracking.UseVisualStyleBackColor = true;
            // 
            // frmAddChat
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(698, 386);
            this.Controls.Add(this.chkDhtOnlyTracking);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtInvitationMessage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkSendInvitation);
            this.Controls.Add(this.chkLANChat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtSharedSecret);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNetworkNameOrPeerEmailAddress);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddChat";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Chat";
            this.Load += new System.EventHandler(this.frmAddChat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNetworkNameOrPeerEmailAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSharedSecret;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkLANChat;
        private System.Windows.Forms.CheckBox chkSendInvitation;
        private System.Windows.Forms.TextBox txtInvitationMessage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkDhtOnlyTracking;
    }
}