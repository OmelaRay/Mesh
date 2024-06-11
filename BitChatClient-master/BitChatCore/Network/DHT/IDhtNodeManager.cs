

using System.IO;
using System.Net;

namespace BitChatCore.Network.KademliaDHT
{
    interface IDhtNodeManager
    {
        Stream GetConnectionStream(IPEndPoint remoteNodeEP);
    }
}
