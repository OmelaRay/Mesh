﻿

using System;
using System.IO;
using System.Text;
using TechnitiumLibrary.IO;
using TechnitiumLibrary.Security.Cryptography;

namespace AutomaticUpdate.Client
{
    public class UpdateInfo : EventArgs, IWriteStream
    {
        #region variables

        string _updateVersion;
        Uri _downloadURI;
        long _downloadSize;
        Signature _signature;

        #endregion

        #region constructor

        public UpdateInfo(string updateVersion, Uri downloadURI, long downloadSize, Signature signature)
        {
            _updateVersion = updateVersion;
            _downloadURI = downloadURI;
            _downloadSize = downloadSize;
            _signature = signature;

            if (_signature.SigningCertificate.Capability != CertificateCapability.SignDocument)
                throw new Exception("Signing certificate is not capable to sign files.");
        }

        public UpdateInfo(Stream s)
        {
            BinaryReader bR = new BinaryReader(s);

            if (Encoding.ASCII.GetString(bR.ReadBytes(2)) != "UI")
                throw new Exception("Invalid UpdateInfo format.");

            switch (bR.ReadByte()) //version
            {
                case 1:
                    _updateVersion = Encoding.ASCII.GetString(bR.ReadBytes(bR.ReadByte()));
                    _downloadURI = new Uri(Encoding.ASCII.GetString(bR.ReadBytes(bR.ReadByte())));
                    _downloadSize = bR.ReadInt64();
                    _signature = new Signature(bR.BaseStream);

                    if (_signature.SigningCertificate.Capability != CertificateCapability.SignDocument)
                        throw new Exception("Signing certificate is not capable to sign files.");

                    break;

                default:
                    throw new Exception("UpdateInfo version not supported.");
            }
        }

        #endregion

        #region public

        public bool IsUpdateAvailable(string currentVersion)
        {
            string[] uVer = _updateVersion.Split(new char[] { '.' });
            string[] cVer = currentVersion.Split(new char[] { '.' });

            int x = uVer.Length;
            if (x > cVer.Length)
                x = cVer.Length;

            for (int i = 0; i < x; i++)
            {
                if (Convert.ToInt32(uVer[i]) > Convert.ToInt32(cVer[i]))
                    return true;
                else if (Convert.ToInt32(uVer[i]) < Convert.ToInt32(cVer[i]))
                    return false;
            }

            if (uVer.Length > cVer.Length)
            {
                for (int i = x; i < uVer.Length; i++)
                {
                    if (Convert.ToInt32(uVer[i]) > 0)
                        return true;
                }
            }

            return false;
        }

        #endregion

        #region IWriteStream

        public void WriteTo(Stream s)
        {
            s.Write(Encoding.ASCII.GetBytes("UI"), 0, 2); //format
            s.WriteByte((byte)1); //version

            s.WriteByte(Convert.ToByte(_updateVersion.Length));
            s.Write(Encoding.ASCII.GetBytes(_updateVersion), 0, _updateVersion.Length);

            s.WriteByte(Convert.ToByte(_downloadURI.AbsoluteUri.Length));
            s.Write(Encoding.ASCII.GetBytes(_downloadURI.AbsoluteUri), 0, _downloadURI.AbsoluteUri.Length);

            s.Write(BitConverter.GetBytes(_downloadSize), 0, 8);
            _signature.WriteTo(s);
        }

        #endregion

        #region properties

        public string UpdateVersion
        { get { return _updateVersion; } }

        public Uri DownloadURI
        { get { return _downloadURI; } }

        public long DownloadSize
        { get { return _downloadSize; } }

        public Signature DownloadSignature
        { get { return _signature; } }

        #endregion
    }
}
