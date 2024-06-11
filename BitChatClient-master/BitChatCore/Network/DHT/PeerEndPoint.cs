
using System;
using System.IO;
using System.Net;
using TechnitiumLibrary.Net;

namespace BitChatCore.Network.KademliaDHT
{
    class PeerEndPoint : IPEndPoint
    {
        #region variables

        const int PEER_EXPIRY_TIME_SECONDS = 900; //15 min expiry

        DateTime _dateAdded = DateTime.UtcNow;

        #endregion

        #region constructor

        public PeerEndPoint(IPAddress address, int port)
            : base(address, port)
        { }

        public PeerEndPoint(Stream s)
            : base(0, 0)
        {
            IPEndPoint ep = IPEndPointParser.Parse(s);

            this.Address = ep.Address;
            this.Port = ep.Port;
        }

        #endregion

        #region public

        public bool HasExpired()
        {
            return (DateTime.UtcNow - _dateAdded).TotalSeconds > PEER_EXPIRY_TIME_SECONDS;
        }

        public void UpdateDateAdded()
        {
            _dateAdded = DateTime.UtcNow;
        }

        public void WriteTo(Stream s)
        {
            IPEndPointParser.WriteTo(this, s);
        }

        #endregion

        #region properties

        public DateTime DateAdded
        { get { return _dateAdded; } }

        #endregion
    }
}
