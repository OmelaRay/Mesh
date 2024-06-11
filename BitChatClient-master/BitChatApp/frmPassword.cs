

using BitChatCore;
using System;
using System.IO;
using System.Windows.Forms;

namespace BitChatApp
{
    public partial class frmPassword : Form
    {
        #region variables

        string _profileFilePath;
        bool _isPortableApp;
        string _profileFolder;

        BitChatProfile _profile;

        #endregion

        #region constructor

        public frmPassword(string profileFilePath, bool isPortableApp, string profileFolder)
        {
            InitializeComponent();

            _profileFilePath = profileFilePath;
            _isPortableApp = isPortableApp;
            _profileFolder = profileFolder;

            labProfileName.Text = Path.GetFileNameWithoutExtension(_profileFilePath);
        }

        #endregion

        #region private

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                using (FileStream fS = new FileStream(_profileFilePath, FileMode.Open, FileAccess.Read))
                {
                    _profile = new BitChatProfile(fS, txtPassword.Text, _isPortableApp, _profileFolder);
                }

                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch
            {
                try
                {
                    using (FileStream fS = new FileStream(_profileFilePath + ".bak", FileMode.Open, FileAccess.Read))
                    {
                        _profile = new BitChatProfile(fS, txtPassword.Text, _isPortableApp, _profileFolder);
                    }

                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Invalid password or file data tampered. Please try again.", "Invalid Password!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    txtPassword.Text = "";
                    txtPassword.Focus();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Since the profile password is used to encrypt the profile data, there is no method to recover the encryption password or the profile data.\r\n\r\nTo access Bit Chat, you will need to register a new profile and you can use the same email address for registration. You will lose all your settings and you will have to join all your chats again.\r\n\r\nDo you want to register a new profile now?", "Register New Profile?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                this.Close();
            }
        }

        #endregion

        #region properties

        public BitChatProfile Profile
        { get { return _profile; } }

        #endregion

        private void frmPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
