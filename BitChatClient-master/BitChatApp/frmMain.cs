﻿

using AutomaticUpdate.Client;
using BitChatApp.UserControls;
using BitChatCore;
using BitChatCore.FileSharing;
using BitChatCore.Network.Connections;
using BitChatCore.Network.SecureChannel;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TechnitiumLibrary.IO;
using TechnitiumLibrary.Net;
using TechnitiumLibrary.Security.Cryptography;

namespace BitChatApp
{
    public partial class frmMain : Form, IDebug
    {
        #region variables

        BitChatProfile _profile;
        string _profileFilePath;

        FileStream _debugFile;
        StreamWriter _debugWriter;

        BitChatNode _node;

        AutomaticUpdateClient _updateClient;
        DateTime _lastUpdateCheckedOn;
        DateTime _lastModifiedGMT;

        SoundPlayer _sndMessageNotification = new SoundPlayer(Properties.Resources.MessageNotification);

        BitChatPanel _currentChatPanel;
        Timer _updateTimer;
        bool _upnpNoticeShown = false;

        #endregion

        #region constructor

        public frmMain(BitChatProfile profile, string profileFilePath, string cmdLine)
        {
            InitializeComponent();

            _profile = profile;
            _profileFilePath = profileFilePath;

            SecureChannelCryptoOptionFlags cryptoOptions;

            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                    if (Environment.OSVersion.Version.Major > 5)
                        cryptoOptions = SecureChannelCryptoOptionFlags.ECDHE256_RSA_WITH_AES256_CBC_HMAC_SHA256 | SecureChannelCryptoOptionFlags.DHE2048_RSA_WITH_AES256_CBC_HMAC_SHA256;
                    else
                        cryptoOptions = SecureChannelCryptoOptionFlags.DHE2048_RSA_WITH_AES256_CBC_HMAC_SHA256;

                    break;

                default:
                    cryptoOptions = SecureChannelCryptoOptionFlags.DHE2048_RSA_WITH_AES256_CBC_HMAC_SHA256;
                    break;
            }

            //start bitchat client
            _node = new BitChatNode(profile, Program.TRUSTED_CERTIFICATES, cryptoOptions);

            _node.InvalidCertificateDetected += BitChatNode_InvalidCertificateDetected;
            _node.BitChatInvitationReceived += BitChatNode_BitChatInvitationReceived;

            _node.Start();
        }

        #endregion

        #region form code

        private void frmMain_Load(object sender, EventArgs e)
        {
            //load chats and ui views
            lblUserName.Text = _profile.LocalCertificateStore.Certificate.IssuedTo.Name;

            foreach (BitChat chat in _node.GetBitChatList())
                AddChatView(chat);

            lstChats.SelectItem(lstChats.GetFirstItem());
            ShowSelectedChatView();

            //load settings
            bool loadDefaultSettings = true;

            if (_profile.ClientData != null)
            {
                try
                {
                    LoadProfileSettings(_profile.ClientData);
                    loadDefaultSettings = false;
                }
                catch
                { }
            }

            if (loadDefaultSettings)
            {
                this.Width = 960;
                this.Height = 540;

                Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

                this.Left = workingArea.Width - workingArea.Left - this.Width - 20;
                this.Top = 100;
            }

            //start automatic update client
            _updateClient = new AutomaticUpdateClient(Program.MUTEX_NAME, Application.ProductVersion, Program.UPDATE_URI, Program.UPDATE_CHECK_INTERVAL_DAYS, Program.TRUSTED_CERTIFICATES, _lastUpdateCheckedOn, _lastModifiedGMT);
            _updateClient.Proxy = _profile.Proxy;
            _updateClient.ExitApplication += _updateClient_ExitApplication;
            _updateClient.UpdateAvailable += _updateClient_UpdateAvailable;
            _updateClient.NoUpdateAvailable += _updateClient_NoUpdateAvailable;
            _updateClient.UpdateError += _updateClient_UpdateError;

            //show tray icon
            notifyIcon1.Visible = true;

            _updateTimer = new Timer();
            _updateTimer.Interval = 10000;
            _updateTimer.Tick += updateTimer_Tick;
            _updateTimer.Start();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && (e.KeyCode == Keys.D))
            {
                StartDebugging();
                e.Handled = true;
            }
            else if (e.Alt && (e.KeyCode == Keys.F))
            {
                btnPlusButton_Click(null, null);
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                SaveProfile();
            }
            catch
            { }

            if (_debugFile != null)
            {
                lock (_debugFile)
                {
                    _debugWriter.Flush();
                    _debugFile.Close();

                    _debugWriter = null;
                }
            }

            _updateTimer.Dispose();
            _updateClient.Dispose();
            _node.Dispose();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                switch (this.DialogResult)
                {
                    case DialogResult.Cancel:
                    case DialogResult.None:
                        e.Cancel = true;
                        this.Hide();
                        break;
                }
            }
        }

        private void btnPlusButton_Click(object sender, EventArgs e)
        {
            mnuPlus.Show(btnPlusButton, new Point(0, btnPlusButton.Height));
        }

        private void lblUserName_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(61, 78, 93);
            lblUserName.BackColor = panel1.BackColor;
        }

        private void lblUserName_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(51, 65, 78);
            lblUserName.BackColor = panel1.BackColor;
        }

        private void lstChats_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectedChatView();
        }

        private void lstChats_ItemClick(object sender, EventArgs e)
        {
            ShowSelectedChatView();
        }

        private void lstChats_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mnuMuteNotifications.Enabled = false;
                mnuMuteNotifications.Checked = false;
                mnuGoOffline.Enabled = false;
                mnuGoOffline.Checked = false;
                mnuLeaveChat.Enabled = false;
                mnuViewPeerProfile.Visible = false;
                mnuGroupPhoto.Visible = false;
                mnuProperties.Enabled = false;
                mnuChat.Show(lstChats, e.Location);
            }
        }

        private void lstChats_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ShowSelectedChatView();
                    e.Handled = true;
                    break;

                case Keys.Apps:
                    mnuMuteNotifications.Enabled = false;
                    mnuMuteNotifications.Checked = false;
                    mnuGoOffline.Enabled = false;
                    mnuGoOffline.Checked = false;
                    mnuLeaveChat.Enabled = false;
                    mnuViewPeerProfile.Visible = false;
                    mnuGroupPhoto.Visible = false;
                    mnuProperties.Enabled = false;
                    mnuChat.Show(lstChats, lstChats.Location);
                    e.Handled = true;
                    break;
            }
        }

        private void lstChats_ItemMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ChatListItem itm = lstChats.SelectedItem as ChatListItem;

                mnuMuteNotifications.Enabled = true;
                mnuMuteNotifications.Checked = itm.BitChat.Mute;
                mnuGoOffline.Enabled = true;
                mnuGoOffline.Checked = (itm.BitChat.NetworkStatus == BitChatCore.Network.BitChatNetworkStatus.Offline);
                mnuLeaveChat.Enabled = true;
                mnuViewPeerProfile.Visible = (itm.BitChat.NetworkType == BitChatCore.Network.BitChatNetworkType.PrivateChat);
                mnuViewPeerProfile.Enabled = (itm.Peer != null);
                mnuGroupPhoto.Visible = (itm.BitChat.NetworkType == BitChatCore.Network.BitChatNetworkType.GroupChat);
                mnuProperties.Enabled = true;
                mnuChat.Show(sender as Control, e.Location);
            }
        }

        private void lstChats_ItemKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ShowSelectedChatView();
                    e.Handled = true;
                    break;

                case Keys.Apps:
                    ChatListItem itm = lstChats.SelectedItem as ChatListItem;

                    mnuMuteNotifications.Enabled = true;
                    mnuMuteNotifications.Checked = itm.BitChat.Mute;
                    mnuGoOffline.Enabled = true;
                    mnuGoOffline.Checked = (itm.BitChat.NetworkStatus == BitChatCore.Network.BitChatNetworkStatus.Offline);
                    mnuLeaveChat.Enabled = true;
                    mnuViewPeerProfile.Visible = (itm.BitChat.NetworkType == BitChatCore.Network.BitChatNetworkType.PrivateChat);
                    mnuViewPeerProfile.Enabled = (itm.Peer != null);
                    mnuGroupPhoto.Visible = (itm.BitChat.NetworkType == BitChatCore.Network.BitChatNetworkType.GroupChat);
                    mnuProperties.Enabled = true;
                    mnuChat.Show(lstChats, lstChats.Location);
                    e.Handled = true;
                    break;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
        }

        private void mainContainer_Panel2_Resize(object sender, EventArgs e)
        {
            panelGetStarted.Location = new Point(mainContainer.Panel2.Width / 2 - panelGetStarted.Width / 2, mainContainer.Panel2.Height / 2 - panelGetStarted.Height / 2);
        }

        private void btnCreateChat_Click(object sender, EventArgs e)
        {
            mnuAddPrivateChat_Click(null, null);
        }

        private void chatPanel_SettingsModified(object sender, EventArgs e)
        {
            BitChatPanel senderPanel = sender as BitChatPanel;

            using (MemoryStream mS = new MemoryStream())
            {
                senderPanel.WriteSettingsTo(mS);

                foreach (Control ctrl in mainContainer.Panel2.Controls)
                {
                    BitChatPanel panel = ctrl as BitChatPanel;

                    if ((panel != null) && !panel.Equals(sender))
                    {
                        mS.Position = 0;
                        panel.ReadSettingsFrom(mS);
                    }
                }
            }
        }

        private void chatPanel_MessageNotification(BitChat chat, BitChat.Peer messageSender, string message)
        {
            if (!chat.Mute && (!this.Visible || !ApplicationIsActivated()))
            {
                if ((messageSender == null) || (chat.NetworkType == BitChatCore.Network.BitChatNetworkType.PrivateChat))
                    notifyIcon1.ShowBalloonTip(30000, chat.NetworkDisplayName + " - Bit Chat", message, ToolTipIcon.Info);
                else
                    notifyIcon1.ShowBalloonTip(30000, chat.NetworkDisplayName + " - Bit Chat", messageSender.PeerCertificate.IssuedTo.Name + ": " + message, ToolTipIcon.Info);

                _sndMessageNotification.Play();
            }
        }

        private void chatPanel_SwitchToPrivateChat(object sender, EventArgs e)
        {
            UserListItem userItem = sender as UserListItem;
            string peerEmail = userItem.Peer.PeerCertificate.IssuedTo.EmailAddress.Address;

            foreach (ChatListItem item in lstChats.Controls)
            {
                if ((item.BitChat.NetworkType == BitChatCore.Network.BitChatNetworkType.PrivateChat) && (item.BitChat.NetworkName == peerEmail))
                {
                    lstChats.SelectItem(item);
                    ShowSelectedChatView();
                    return;
                }
            }

            ShowAddPrivateChat(peerEmail);
        }

        private void chatPanel_ShareFile(object sender, EventArgs e)
        {
            SharedFile sharedFile = sender as SharedFile;

            using (frmShareFileSelection frm = new frmShareFileSelection(_node, sharedFile))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    foreach (BitChat chat in frm.SelectedChats)
                    {
                        chat.ShareFile(sharedFile);
                    }
                }
            }
        }

        private void ShowAddPrivateChat(string networkNameOrPeerEmailAddress = null)
        {
            using (frmAddChat frm = new frmAddChat(BitChatCore.Network.BitChatNetworkType.PrivateChat, networkNameOrPeerEmailAddress))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        BitChat chat = _node.CreatePrivateChat(new System.Net.Mail.MailAddress(frm.NetworkNameOrPeerEmailAddress.ToLower()), frm.SharedSecret, !frm.OnlyLanChat, frm.DhtOnlyTracking, frm.InvitationMessage);

                        lstChats.SelectItem(AddChatView(chat));
                        ShowSelectedChatView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            string title = "Technitium Bit Chat";

            switch (_node.IPv4InternetStatus)
            {
                case InternetConnectivityStatus.NoInternetConnection:
                case InternetConnectivityStatus.NoProxyInternetConnection:
                    switch (_node.IPv6InternetStatus)
                    {
                        case InternetConnectivityStatus.NoInternetConnection:
                        case InternetConnectivityStatus.NoProxyInternetConnection:
                            this.Text = title + " [No Internet]";
                            return;

                        case InternetConnectivityStatus.FirewalledInternetConnection:
                            this.Text = title + " [Firewalled IPv6 Only Internet]";
                            return;

                        case InternetConnectivityStatus.HttpProxyInternetConnection:
                            this.Text = title + " [IPv6 HTTP Proxy Internet]";
                            return;

                        case InternetConnectivityStatus.Socks5ProxyInternetConnection:
                            this.Text = title + " [IPv6 SOCKS5 Proxy Internet]";
                            return;

                        case InternetConnectivityStatus.ProxyConnectionFailed:
                            this.Text = title + " [IPv6 Proxy Failed]";
                            return;

                        default:
                            this.Text = title + " [IPv6 Only Internet]";
                            return;
                    }

                case InternetConnectivityStatus.NatInternetConnectionViaUPnPRouter:
                    switch (_node.UPnPStatus)
                    {
                        case UPnPDeviceStatus.ExternalIpPrivate:
                            this.Text = title + " [UPnP: No Public IP Detected]";
                            return;

                        case UPnPDeviceStatus.PortForwardedNotAccessible:
                            this.Text = title + " [UPnP: Port Not Accessible From Internet]";
                            return;

                        case UPnPDeviceStatus.PortForwardingFailed:
                            this.Text = title + " [UPnP: Port Forwarding Failed]";
                            return;
                    }

                    break;

                case InternetConnectivityStatus.NatOrFirewalledInternetConnection:
                case InternetConnectivityStatus.FirewalledInternetConnection:
                    if (_node.IPv4ExternalEndPoint == null)
                    {
                        this.Text = title + " [NAT or Firewalled Internet]";

                        if ((_node.UPnPStatus == UPnPDeviceStatus.DeviceNotFound) && !_upnpNoticeShown)
                        {
                            _upnpNoticeShown = true;

                            MessageBox.Show("Bit Chat has detected that your Internet access is either firewalled or you have a NAT enabled router or access point.\r\n\r\nSince, Bit Chat works using peer-to-peer (p2p) technology, NAT or firewall prevents other Bit Chat peers from directly connect to you over the Internet. This may affect your ability to chat with your peers and hence this should be fixed.\r\n\r\nTo fix this, you should either enable UPnP feature or configure port forwarding manually in your router or access point. If you are not sure, you can refer to the user manual that came with your device or search online for the user manual.", "Enable UPnP/Port Forwarding On Your Router", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        return;
                    }

                    break;

                case InternetConnectivityStatus.HttpProxyInternetConnection:
                    this.Text = title + " [HTTP Proxy Internet]";
                    return;

                case InternetConnectivityStatus.Socks5ProxyInternetConnection:
                    this.Text = title + " [SOCKS5 Proxy Internet]";
                    return;

                case InternetConnectivityStatus.ProxyConnectionFailed:
                    this.Text = title + " [Proxy Failed]";
                    return;
            }

            this.Text = title;
        }

        #region menus

        private void mnuAddPrivateChat_Click(object sender, EventArgs e)
        {
            ShowAddPrivateChat();
        }

        private void mnuAddGroupChat_Click(object sender, EventArgs e)
        {
            using (frmAddChat frm = new frmAddChat(BitChatCore.Network.BitChatNetworkType.GroupChat, null))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        BitChat chat = _node.CreateGroupChat(frm.NetworkNameOrPeerEmailAddress, frm.SharedSecret, !frm.OnlyLanChat, frm.DhtOnlyTracking);

                        lstChats.SelectItem(AddChatView(chat));
                        ShowSelectedChatView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void mnuViewProfile_Click(object sender, EventArgs e)
        {
            using (frmViewProfile frm = new frmViewProfile(_profile, null))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                    SaveProfile();
            }
        }

        private void mnuProfileSettings_Click(object sender, EventArgs e)
        {
            using (frmSettings frm = new frmSettings(_node.Profile))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    if (frm.PasswordChangeRequest)
                        _profile.ChangePassword(frm.Password);

                    _profile.DownloadFolder = frm.DownloadFolder;
                    _profile.TrackerURIs = frm.Trackers;
                    _profile.LocalPort = frm.Port;
                    _profile.CheckCertificateRevocationList = frm.CheckCertificateRevocationList;
                    _profile.AllowInboundInvitations = frm.AllowInboundInvitations;
                    _profile.AllowOnlyLocalInboundInvitations = frm.AllowOnlyLocalInboundInvitations;
                    _profile.EnableUPnP = frm.EnableUPnP;

                    if (frm.EnableProxy)
                        _profile.ConfigureProxy(frm.ProxyType, frm.ProxyAddress, frm.ProxyPort, frm.ProxyCredentials);
                    else
                        _profile.DisableProxy();

                    SaveProfile();

                    //set proxy
                    _updateClient.Proxy = _profile.Proxy;
                }
            }
        }

        private void mnuSwitchProfile_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Your current profile will be logged off. Are you sure to proceed with switching to another profile?", "Switch Profile?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                notifyIcon1.Visible = false;
                this.Hide();
                this.DialogResult = DialogResult.Ignore;
                this.Close();
            }
        }

        private void networkInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmNetworkInfo frm = new frmNetworkInfo(_node))
            {
                frm.ShowDialog(this);
            }
        }

        private void mnuCheckUpdate_Click(object sender, EventArgs e)
        {
            mnuCheckUpdate.Enabled = false;

            _updateClient.CheckForUpdate();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            using (frmAbout frm = new frmAbout())
            {
                frm.ShowDialog(this);
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            this.Hide();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void mnuMuteNotifications_Click(object sender, EventArgs e)
        {
            if (lstChats.SelectedItem != null)
            {
                ChatListItem itm = lstChats.SelectedItem as ChatListItem;

                mnuMuteNotifications.Checked = !mnuMuteNotifications.Checked;
                itm.BitChat.Mute = mnuMuteNotifications.Checked;
            }
        }

        private void mnuGoOffline_Click(object sender, EventArgs e)
        {
            if (lstChats.SelectedItem != null)
            {
                ChatListItem itm = lstChats.SelectedItem as ChatListItem;

                mnuGoOffline.Checked = !mnuGoOffline.Checked;
                itm.GoOffline = mnuGoOffline.Checked;

                if (mnuGoOffline.Checked)
                    itm.BitChat.GoOffline();
                else
                    itm.BitChat.GoOnline();
            }
        }

        private void mnuLeaveChat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to leave chat?\r\n\r\nWarning! You will lose all stored messages in this chat. If you wish to join back the same chat again, you will need to remember the Chat Name and Shared Secret.", "Leave Chat?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                RemoveSelectedChatView();
            }
        }

        private void mnuViewPeerProfile_Click(object sender, EventArgs e)
        {
            if (lstChats.SelectedItem != null)
            {
                ChatListItem itm = lstChats.SelectedItem as ChatListItem;

                using (frmViewProfile frm = new frmViewProfile(_profile, itm.Peer))
                {
                    frm.ShowDialog(this);
                }
            }
        }

        private void mnuGroupPhoto_Click(object sender, EventArgs e)
        {
            if (lstChats.SelectedItem != null)
            {
                ChatListItem itm = lstChats.SelectedItem as ChatListItem;

                using (frmViewGroup frm = new frmViewGroup(itm.BitChat))
                {
                    if (frm.ShowDialog(this) == DialogResult.OK)
                        SaveProfile();
                }
            }
        }

        private void mnuProperties_Click(object sender, EventArgs e)
        {
            if (lstChats.SelectedItem != null)
            {
                ChatListItem itm = lstChats.SelectedItem as ChatListItem;

                using (frmChatProperties frm = new frmChatProperties(itm.BitChat, _profile))
                {
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        try
                        {
                            itm.BitChat.SharedSecret = frm.SharedSecret;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void mnuShowBitChat_Click(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
        }

        #endregion

        #endregion

        #region private

        private void BitChatNode_InvalidCertificateDetected(BitChatNode node, InvalidCertificateException e)
        {
            MessageBox.Show(e.Message + "\r\n\r\nClick OK to logout from this Bit Chat profile.", "Invalid Certificate Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);

            notifyIcon1.Visible = false;
            this.Hide();
            this.DialogResult = DialogResult.Ignore;
            this.Close();
        }

        private void BitChatNode_BitChatInvitationReceived(BitChatNode node, BitChat chat)
        {
            AddChatView(chat);

            if (lstChats.Controls.Count == 1)
            {
                lstChats.SelectItem(lstChats.GetFirstItem());
                ShowSelectedChatView();
            }
        }

        private ChatListItem AddChatView(BitChat chat)
        {
            ChatListItem itm = new ChatListItem(chat);

            itm.ChatPanel.SettingsModified += chatPanel_SettingsModified;
            itm.ChatPanel.MessageNotification += chatPanel_MessageNotification;
            itm.ChatPanel.SwitchToPrivateChat += chatPanel_SwitchToPrivateChat;
            itm.ChatPanel.ShareFile += chatPanel_ShareFile;

            mainContainer.Panel2.Controls.Add(itm.ChatPanel);

            lstChats.AddItem(itm);

            return itm;
        }

        private void RemoveSelectedChatView()
        {
            if (lstChats.SelectedItem != null)
            {
                ChatListItem itm = lstChats.SelectedItem as ChatListItem;

                lstChats.RemoveItem(itm);
                mainContainer.Panel2.Controls.Remove(itm.ChatPanel);

                itm.ChatPanel.SettingsModified -= chatPanel_SettingsModified;
                itm.ChatPanel.MessageNotification -= chatPanel_MessageNotification;
                itm.ChatPanel.SwitchToPrivateChat -= chatPanel_SwitchToPrivateChat;

                itm.BitChat.LeaveChat();
            }
        }

        private void ShowSelectedChatView()
        {
            if (lstChats.SelectedItem != null)
            {
                if (_currentChatPanel != null)
                    _currentChatPanel.TrimMessageList();

                BitChatPanel chatPanel = (lstChats.SelectedItem as ChatListItem).ChatPanel;
                chatPanel.BringToFront();
                chatPanel.SetFocusMessageEditor();

                _currentChatPanel = chatPanel;
            }
        }

        private void ReadUISettingsFrom(Stream s)
        {
            BinaryReader bR = new BinaryReader(s);

            byte version = bR.ReadByte();

            switch (version) //version
            {
                case 1:
                case 2:
                    //form location
                    this.Location = new Point(bR.ReadInt32(), bR.ReadInt32());

                    //form size
                    this.Size = new Size(bR.ReadInt32(), bR.ReadInt32());

                    //form maximized
                    if (Convert.ToBoolean(bR.ReadByte()))
                        this.WindowState = FormWindowState.Maximized;

                    //form main container splitter position
                    if (version > 1)
                    {
                        mainContainer.SplitterDistance = mainContainer.Width - bR.ReadInt32();
                    }

                    //first chat panel settings
                    if (Convert.ToBoolean(bR.ReadByte()))
                    {
                        foreach (Control ctrl in mainContainer.Panel2.Controls)
                        {
                            BitChatPanel panel = ctrl as BitChatPanel;

                            if (panel != null)
                            {
                                panel.ReadSettingsFrom(bR);
                                break;
                            }
                        }
                    }
                    break;

                default:
                    throw new Exception("Settings format version not supported.");
            }
        }

        private void WriteUISettingsTo(Stream s)
        {
            BinaryWriter bW = new BinaryWriter(s);

            bW.Write((byte)2); //version

            //form location
            bW.Write(this.Location.X);
            bW.Write(this.Location.Y);

            //form size
            bool maximized = this.WindowState == FormWindowState.Maximized;
            Size size;

            if (maximized)
                size = new Size(960, 540);
            else
                size = this.Size;

            bW.Write(size.Width);
            bW.Write(size.Height);

            //form maximized
            if (maximized)
                bW.Write((byte)1);
            else
                bW.Write((byte)0);

            //form main container splitter position
            bW.Write(mainContainer.Width - mainContainer.SplitterDistance);


            //write first chat panel settings
            bool panelFound = false;

            foreach (Control ctrl in mainContainer.Panel2.Controls)
            {
                BitChatPanel panel = ctrl as BitChatPanel;

                if (panel != null)
                {
                    bW.Write((byte)1);
                    panel.WriteSettingsTo(bW);

                    panelFound = true;
                    break;
                }
            }

            if (!panelFound)
                bW.Write((byte)0);
        }

        private void LoadProfileSettings(byte[] clientData)
        {
            using (Package pkg = new Package(new MemoryStream(clientData, false), PackageMode.Open))
            {
                foreach (PackageItem item in pkg.Items)
                {
                    switch (item.Name)
                    {
                        case "ui":
                            ReadUISettingsFrom(item.DataStream);
                            break;

                        case "au":
                            {
                                BinaryReader bR = new BinaryReader(item.DataStream);

                                _lastUpdateCheckedOn = DateTime.FromBinary(bR.ReadInt64());
                                _lastModifiedGMT = DateTime.FromBinary(bR.ReadInt64());
                            }
                            break;
                    }
                }
            }
        }

        private byte[] SaveProfileSettings()
        {
            using (MemoryStream mS = new MemoryStream())
            {
                using (Package pkg = new Package(mS, PackageMode.Create))
                {
                    {
                        MemoryStream ui = new MemoryStream();
                        WriteUISettingsTo(ui);
                        ui.Position = 0;

                        pkg.AddItem(new PackageItem("ui", ui));
                    }

                    {
                        MemoryStream au = new MemoryStream();
                        BinaryWriter bW = new BinaryWriter(au);
                        bW.Write(_updateClient.LastUpdateCheckedOn.ToBinary());
                        bW.Write(_updateClient.LastModifiedGMT.ToBinary());
                        au.Position = 0;

                        pkg.AddItem(new PackageItem("au", au));
                    }
                }

                return mS.ToArray();
            }
        }

        private void SaveProfile()
        {
            //write profile in tmp file
            using (FileStream fS = new FileStream(_profileFilePath + ".tmp", FileMode.Create, FileAccess.ReadWrite, FileShare.None))
            {
                _node.UpdateProfile();
                _profile.ClientData = SaveProfileSettings();
                _profile.WriteTo(fS);
            }

            File.Delete(_profileFilePath + ".bak"); //remove old backup file
            File.Move(_profileFilePath, _profileFilePath + ".bak"); //make current profile file as backup file
            File.Move(_profileFilePath + ".tmp", _profileFilePath); //make tmp file as profile file
        }

        #endregion

        #region automatic update client

        private void _updateClient_UpdateError(object sender, Exception ex)
        {
            MessageBox.Show(this, "Automatic Update process encountered following error while checking for updates:\r\n\r\n" + ex.Message, "Error - Bit Chat", MessageBoxButtons.OK, MessageBoxIcon.Error);

            mnuCheckUpdate.Enabled = true;
        }

        private void _updateClient_NoUpdateAvailable(object sender, EventArgs e)
        {
            MessageBox.Show(this, "No new update was available for Bit Chat.", "No Update Available - Bit Chat", MessageBoxButtons.OK, MessageBoxIcon.Information);

            mnuCheckUpdate.Enabled = true;
        }

        private void _updateClient_UpdateAvailable(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "An update is available to download for Bit Chat.\r\n\r\nCurrent Version: " + Application.ProductVersion +
                "\r\nUpdate Version: " + _updateClient.UpdateInfo.UpdateVersion +
                "\r\nUpdate Source: " + _updateClient.UpdateInfo.DownloadURI +
                "\r\nUpdate Size: " + WebUtilities.GetFormattedSize(_updateClient.UpdateInfo.DownloadSize) +
                "\r\n\r\nDo you want to download and install the update now?",
                "Update Available - Bit Chat", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                _updateClient.DownloadAndInstall();
            }

            mnuCheckUpdate.Enabled = true;
        }

        private void _updateClient_ExitApplication(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            this.Hide();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        #endregion

        #region application active check

        public static bool ApplicationIsActivated()
        {
            var activatedHandle = GetForegroundWindow();
            if (activatedHandle == IntPtr.Zero)
            {
                return false;       // No window is currently activated
            }

            var procId = Process.GetCurrentProcess().Id;
            int activeProcId;
            GetWindowThreadProcessId(activatedHandle, out activeProcId);

            return activeProcId == procId;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

        #endregion

        #region IDebug

        public void Write(string message)
        {
            lock (_debugFile)
            {
                if (_debugWriter != null)
                    _debugWriter.WriteLine(message);
            }
        }

        private void StartDebugging()
        {
            if (_debugFile == null)
            {
                _debugFile = new FileStream(_profileFilePath + ".log", FileMode.Create, FileAccess.Write, FileShare.Read);
                _debugWriter = new StreamWriter(_debugFile);
                _debugWriter.AutoFlush = true;

                BitChatCore.Debug.SetDebug(this);

                this.Text += " [Debugging]";
            }
        }

        #endregion
    }
}
