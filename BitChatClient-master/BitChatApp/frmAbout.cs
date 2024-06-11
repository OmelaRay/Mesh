

using System.Windows.Forms;

namespace BitChatApp
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();

            labVersion.Text = "version " + Application.ProductVersion + " (alpha)";
        }

        private void lnkTerms_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://go.technitium.com/?id=3");
        }

        private void lnkContactEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"mailto:support@bitchat.im");
        }

        private void lnkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://bitchat.im/");
        }

        private void label4_Click(object sender, System.EventArgs e)
        {

        }

        private void frmAbout_Load(object sender, System.EventArgs e)
        {

        }
    }
}
