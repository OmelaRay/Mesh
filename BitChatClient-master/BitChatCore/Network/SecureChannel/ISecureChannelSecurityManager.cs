

using TechnitiumLibrary.Security.Cryptography;

namespace BitChatCore.Network.SecureChannel
{
    interface ISecureChannelSecurityManager
    {
        bool ProceedConnection(Certificate remoteCertificate); 
    }
}
