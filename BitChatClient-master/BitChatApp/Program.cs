﻿
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using TechnitiumLibrary.Net.Firewall;
using TechnitiumLibrary.Security.Cryptography;

namespace BitChatApp
{
    static class Program
    {
        #region variables

        public const string MUTEX_NAME = "BitChatApp";
        public readonly static Uri SIGNUP_URI = new Uri("https://bitchat.im/api/signup.aspx");
        public readonly static Uri UPDATE_URI = new Uri("https://bitchat.im/download/windows/update.bin");
        public const int UPDATE_CHECK_INTERVAL_DAYS = 1;

        static string _rootCert = @"
Q0UBAQpUQ0EtMjAxNC0xQ1AB7wMAAM8DAAAgVGVjaG5pdGl1bSBDZXJ0aWZpY2F0ZSBBdXRob3Jp
dHkCEWNhQHRlY2huaXRpdW0uY29tFmh0dHA6Ly90ZWNobml0aXVtLmNvbS8NVmlraHJvbGkgRWFz
dAZNdW1iYWkLTWFoYXJhc2h0cmEFSW5kaWEGNDAwMDc5AXpulVQAAAAAesH8XQAAAAAB8wI8UlNB
S2V5VmFsdWU+PE1vZHVsdXM+cFBlZENzY2p5Z3Y1MDg5aDR1WGg2cnRZRUdhYklGV2xjbmZXaVJy
Ky8rZkNVR2NrYUVmVUxMVjlPaTJjSE1TaVFGVjNzaUs0N2VtSDlmUGd2WG8yYW5iWlREYW9TRVY4
WEc4STNvVkVuZG95RVZEL0JZVmVYcmQrZ2FnWWtMZmw5aEtNNVJNaUhHbDR2N2hpTWFPdkRWUUxy
ZWhOQjltcU15RzN3bk1ST3IxdSs5Tld3enFTZlR4a0VVS0ZhUGc4MlRnVi8rcFU2UEEzL0pYK3Na
MnpzZHhhcm1kSGFhTW41QTR5OWJkSm41eEUwUXlMMEkxMDFWSCtPMkE0ZmRNNVcvbXhJcjBiU2Z3
dlRjNThHR1QrdjFsR2RTWmpRZitxYXgxZG0yMzBHQy9xRTd3Y2NEK1pLaFNsTDF2VmlUMmJINXBs
TEo5cFppeEVnT3R4SnVJUTlGRUsvcDNDVEFrNHAvTFgwdmZ3TUZReUtaaUROVTlPZ3pUQW1FRFBF
VXc0eUVlUFlBV0c0QkVhbVRUUi9TZUlvZWxzTi8wU1ZURVhRb0tQeE5PZGM5QmhCZU1UTGRWVkZH
QTdSc09PRzd6eUFUeGl0RlpYeElhd21CSkpxTWFVRVdjR0t3eHAvSHFqTmJYYUFKTUZXUGdiL0sy
YmxpQlQzNzFtcWdEbElwZzY4OVg2aUdaZXBNRWVxcW1lckR4QWMzYUJNZFlEZHo2TWkzUlp1NE5P
aHVPSUErYjZWaWtGeU9tdXBscTc1THkyekN3Q1YzaDl0QkprUndFVWx3TDYyQ1FobHdUaDBRWlpE
Y3ZNREt5VDhOelVZZklpZWtGR2Q0SDJRZ3pBYWFMVUpNSExwcU5IYmpqdXdBWHFyZXJ2aVl4NHNR
Z0QzZUJLaGt0K3VTUzRnUXM9PC9Nb2R1bHVzPjxFeHBvbmVudD5BUUFCPC9FeHBvbmVudD48L1JT
QUtleVZhbHVlPiNodHRwczovL3RlY2huaXRpdW0uY29tL2NybC9jcmwuYXNweAFTTgEAAn/m6RMT
OVhQ7xyyc8NwVWbs+jA6cnPpks+yL6j+Di3BEcmT9HlDRIGVz8wBlI0qEtsJ1OsY7blYkJM8qm6s
qK4IlC6JxwzMgDQouaj7yPoMvZiHKNZnn0ikQTHln5IVgBjjnSRTpvzKpnhpRl069xB5kWLTJqIS
ozTnoccrn2pCrVPqhwcJHDZf7IBHlVn7VOfiBHm73yBDpSBvYWtkl+qojPL1P0RVtT+dhEG3HJF+
2gfLC3kXGtLyQSuOtjEsU38pSMr2/2DnOXan/5KDUEOUrW3gQ2BWKv4HK7RqLOZqUSigQIu2a5qV
w5W5oJrk7Dr2Uou0KLGaV1BofdGSKTem5Kz4gsSC3zwP8kjPmqETA7RkAPs8nL+kTi/20j5BWgIx
S2QVWrwjV4k4urVu91pyjY5P7JJOO3SN85TOQ9wdeVv0lthdd4cED7HFE+trqyfCeZD4BMKihXsZ
BF+Xh/PhxxJjLoHwsphPF7qGaltcAEYrK88zS0c1KOPdJQsbjqSJerwMT5al/OYSp7FPXn3POo+s
xN9SGwJcanbJC8cP02Bq3bxTW+GHXU+dEr1LY2eBXej5lB2RFs8gJ5uP8cmjzwWMX/Ib6aNIs6IM
4d1HijZ3z5iokvPkmO8qwYt0lSSysexs/fY9JLTmyJX4ww10amMLAg7qfYbN33Wv5qplBlNIQTI1
NgEA
";

        public readonly static Certificate[] TRUSTED_CERTIFICATES;

        private static Mutex _app;

        #endregion

        #region public

        static Program()
        {
            TRUSTED_CERTIFICATES = new Certificate[1];

            using (MemoryStream mS = new MemoryStream(Convert.FromBase64String(_rootCert)))
            {
                TRUSTED_CERTIFICATES[0] = new Certificate(mS);
            }
        }

        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                #region check windows firewall entry

                string appPath = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "").Replace("/", "\\");
                bool firewallEntryExists = WindowsFirewallEntryExists(appPath);

                if (!firewallEntryExists)
                {
                    bool isAdmin = (new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator);

                    if (isAdmin)
                    {
                        AddWindowsFirewallEntry(appPath);
                    }
                    else
                    {
                        ProcessStartInfo processInfo = new ProcessStartInfo(appPath, string.Join(" ", args));

                        processInfo.UseShellExecute = true;
                        processInfo.Verb = "runas";

                        try
                        {
                            Process.Start(processInfo);
                            return;
                        }
                        catch
                        { }
                    }
                }

                #endregion

                #region check for multiple instances

                bool createdNewMutex;

                _app = new Mutex(true, MUTEX_NAME, out createdNewMutex);

                if (!createdNewMutex)
                {
                    MessageBox.Show("Bit Chat is already running. Please click on the Bit Chat system tray icon to open the chat window.", "Bit Chat Already Running!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                #endregion

                #region profile manager

                while (true)
                {
                    frmProfileManager mgr = new frmProfileManager();

                    if (mgr.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            if (mgr.Profile != null)
                            {
                                bool loadMainForm = false;

                                if ((mgr.Profile.LocalCertificateStore.Certificate.Type == CertificateType.User) && (mgr.Profile.LocalCertificateStore.Certificate.Capability == CertificateCapability.UserAuthentication))
                                {
                                    loadMainForm = true;
                                }
                                else
                                {
                                    using (frmRegister frm = new frmRegister(mgr.Profile, mgr.ProfileFilePath, mgr.IsPortableApp, mgr.ProfileFolder, false))
                                    {
                                        loadMainForm = (frm.ShowDialog() == DialogResult.OK);
                                    }
                                }

                                if (loadMainForm)
                                {
                                    using (frmMain frm = new frmMain(mgr.Profile, mgr.ProfileFilePath, string.Join(" ", args)))
                                    {
                                        Application.Run(frm);

                                        if (frm.DialogResult != DialogResult.Ignore)
                                            break;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error! " + ex.Message, "Error - Bit Chat Profile Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message + "\r\n\r\nClick OK to quit the application.", "Error - Bit Chat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region private

        private static bool WindowsFirewallEntryExists(string appPath)
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                    if (Environment.OSVersion.Version.Major > 5)
                    {
                        //vista and above
                        try
                        {
                            return WindowsFirewall.RuleExistsVista("", appPath) == RuleStatus.Allowed;
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    else
                    {
                        try
                        {
                            return WindowsFirewall.ApplicationExists(appPath) == RuleStatus.Allowed;
                        }
                        catch
                        {
                            return false;
                        }
                    }

                default:
                    return true;
            }
        }

        private static void AddWindowsFirewallEntry(string appPath)
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                    if (Environment.OSVersion.Version.Major > 5)
                    {
                        //vista and above
                        try
                        {
                            RuleStatus status = WindowsFirewall.RuleExistsVista("", appPath);

                            switch (status)
                            {
                                case RuleStatus.Blocked:
                                case RuleStatus.Disabled:
                                    WindowsFirewall.RemoveRuleVista("", appPath);
                                    break;

                                case RuleStatus.Allowed:
                                    return;
                            }

                            WindowsFirewall.AddRuleVista("Bit Chat", "Allow incoming connection request to Bit Chat application.", FirewallAction.Allow, appPath, Protocol.ANY);
                        }
                        catch
                        { }
                    }
                    else
                    {
                        try
                        {
                            RuleStatus status = WindowsFirewall.ApplicationExists(appPath);

                            switch (status)
                            {
                                case RuleStatus.Disabled:
                                    WindowsFirewall.RemoveApplication(appPath);
                                    break;

                                case RuleStatus.Allowed:
                                    return;
                            }

                            WindowsFirewall.AddApplication("Bit Chat", appPath);
                        }
                        catch
                        { }
                    }

                    break;
            }
        }

        #endregion
    }
}
