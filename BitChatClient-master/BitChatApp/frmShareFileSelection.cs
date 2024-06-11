

using BitChatCore;
using BitChatCore.FileSharing;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BitChatApp
{
    public partial class frmShareFileSelection : Form
    {
        List<BitChat> _selectedChats;

        public frmShareFileSelection(BitChatNode node, SharedFile sharedFile)
        {
            InitializeComponent();

            BitChat[] sharedChats = sharedFile.GetChatList();

            foreach (BitChat chat in node.GetBitChatList())
            {
                bool found = false;

                foreach (BitChat sharedChat in sharedChats)
                {
                    if (sharedChat == chat)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                    checkedListBox1.Items.Add(chat);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _selectedChats = new List<BitChat>();

            foreach (BitChat item in checkedListBox1.CheckedItems)
                _selectedChats.Add(item);

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public List<BitChat> SelectedChats
        { get { return _selectedChats; } }

        private void frmShareFileSelection_Load(object sender, EventArgs e)
        {

        }
    }
}
