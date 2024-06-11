

using System;
using System.IO;
using System.Net;
using TechnitiumLibrary.Security.Cryptography;

namespace BitChatCore.Network.SecureChannel
{
    public enum SecureChannelCode : byte
    {
        None = 0,
        RemoteError = 1,
        ProtocolVersionNotSupported = 2,
        NoMatchingCryptoAvailable = 3,
        SecurityManagerDeclinedAccess = 4,
        InvalidRemoteCertificate = 5,
        InvalidRemoteCertificateAlgorithm = 6,
        InvalidRemoteKeyExchangeSignature = 7,
        InvalidMessageHMACReceived = 8,
        ProtocolAuthenticationFailed = 9,
        UnknownException = 254,
    }

    [Serializable()]
    public class SecureChannelException : IOException
    {
        #region variable

        SecureChannelCode _code;
        IPEndPoint _peerEP;
        Certificate _peerCertificate;

        #endregion

        #region constructor

        public SecureChannelException(SecureChannelCode code, IPEndPoint peerEP, Certificate peerCertificate)
        {
            _code = code;
            _peerEP = peerEP;
            _peerCertificate = peerCertificate;
        }

        public SecureChannelException(SecureChannelCode code, IPEndPoint peerEP, Certificate peerCertificate, string message)
            : base(message)
        {
            _code = code;
            _peerEP = peerEP;
            _peerCertificate = peerCertificate;
        }

        public SecureChannelException(SecureChannelCode code, IPEndPoint peerEP, Certificate peerCertificate, string message, Exception innerException)
            : base(message, innerException)
        {
            _code = code;
            _peerEP = peerEP;
            _peerCertificate = peerCertificate;
        }

        public SecureChannelException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }

        #endregion

        #region property

        public SecureChannelCode Code
        { get { return _code; } }

        public IPEndPoint PeerEP
        { get { return _peerEP; } }

        public Certificate PeerCertificate
        { get { return _peerCertificate; } }

        #endregion
    }
}
