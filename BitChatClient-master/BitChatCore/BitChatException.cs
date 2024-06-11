
using System;

namespace BitChatCore
{
    [Serializable()]
    public class BitChatException : Exception
    {
        public BitChatException()
        { }

        public BitChatException(string message)
            : base(message)
        { }

        public BitChatException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public BitChatException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
    }
}