
using BitChatApp.UserControls;
using BitChatCore;
using System;
using System.Windows.Forms;

namespace BitChatApp
{
    public partial class frmMessageInfo : Form
    {
        ChatMessageTextItem chatMessageDisplay;
        MessageItem _message;

        public frmMessageInfo(BitChat.Peer selfPeer, MessageItem message)
        {
            _message = message;

            this.SuspendLayout();

            InitializeComponent();

            chatMessageDisplay = new ChatMessageTextItem(selfPeer, _message);
            chatMessageDisplay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chatMessageDisplay.Width = chatMessagePanel.Width - 30;
            chatMessageDisplay.ContextMenuStrip = null;

            if (chatMessageDisplay.Height > 150)
            {
                chatMessagePanel.Height = 140;
            }
            else
            {
                chatMessagePanel.Height = chatMessageDisplay.Height + 10;

                int heightDiff = 150 - chatMessagePanel.Height;

                this.Height -= heightDiff;
                listView1.Top -= heightDiff;
                btnClose.Top -= heightDiff;
            }

            chatMessagePanel.Controls.Add(chatMessageDisplay);

            this.ResumeLayout();
        }

        private void frmMessageInfo_Load(object sender, EventArgs e)
        {
            foreach (MessageRecipient rcpt in _message.Recipients)
            {
                ListViewItem item = listView1.Items.Add(rcpt.Name);

                switch (rcpt.Status)
                {
                    case MessageRecipientStatus.Delivered:
                        item.SubItems.Add("Delivered on " + rcpt.DeliveredOn.ToLocalTime().ToString());
                        break;

                    case MessageRecipientStatus.Undelivered:
                        item.SubItems.Add("Undelivered");
                        break;
                }
            }
        }
    }
}
