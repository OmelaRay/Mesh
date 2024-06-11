

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using TechnitiumLibrary.IO;
using TechnitiumLibrary.Net;

namespace BitChatCore.Network
{
    public class PeerInfo : IWriteStream
    {
        #region variables

        string _peerEmail;
        List<IPEndPoint> _peerEPList;

        #endregion

        #region constructor

        public PeerInfo(string peerEmail, List<IPEndPoint> peerEPList)
        {
            _peerEmail = peerEmail.ToLower();
            _peerEPList = peerEPList;
        }

        public PeerInfo(Stream s)
        {
            byte[] buffer = new byte[s.ReadByte()];
            OffsetStream.StreamRead(s, buffer, 0, buffer.Length);
            _peerEmail = Encoding.UTF8.GetString(buffer);

            int count = s.ReadByte();
            _peerEPList = new List<IPEndPoint>(count);

            for (int i = 0; i < count; i++)
                _peerEPList.Add(IPEndPointParser.Parse(s));
        }

        #endregion

        #region public

        public void WriteTo(Stream s)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(_peerEmail);

            s.WriteByte(Convert.ToByte(buffer.Length));
            s.Write(buffer, 0, buffer.Length);

            s.WriteByte(Convert.ToByte(_peerEPList.Count));

            foreach (IPEndPoint peerEP in _peerEPList)
                IPEndPointParser.WriteTo(peerEP, s);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            PeerInfo objPeerInfo = obj as PeerInfo;

            return _peerEmail.Equals(objPeerInfo._peerEmail);
        }

        public override int GetHashCode()
        {
            return _peerEmail.GetHashCode();
        }

        #endregion

        #region properties

        public string PeerEmail
        { get { return _peerEmail; } }

        public List<IPEndPoint> PeerEPList
        { get { return _peerEPList; } }

        #endregion
    }
}
