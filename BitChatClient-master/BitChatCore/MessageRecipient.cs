

using System;
using System.IO;
using TechnitiumLibrary.IO;

namespace BitChatCore
{
    public enum MessageRecipientStatus : byte
    {
        Undelivered = 0,
        Delivered = 1
    }

    public class MessageRecipient : IWriteStream
    {
        #region variables

        readonly string _name;

        MessageRecipientStatus _status = MessageRecipientStatus.Undelivered;
        DateTime _deliveredOn;

        #endregion

        #region constructor

        public MessageRecipient(string name)
        {
            _name = name;
        }

        public MessageRecipient(Stream s)
        {
            BincodingDecoder decoder = new BincodingDecoder(s);

            switch (decoder.DecodeNext().GetByteValue()) //version
            {
                case 1:
                    _name = decoder.DecodeNext().GetStringValue();
                    _status = (MessageRecipientStatus)decoder.DecodeNext().GetByteValue();
                    _deliveredOn = decoder.DecodeNext().GetDateTimeValue();
                    break;

                default:
                    throw new InvalidDataException("Cannot decode data format: version not supported.");
            }
        }

        #endregion

        #region public

        public void SetDeliveredStatus()
        {
            _status = MessageRecipientStatus.Delivered;
            _deliveredOn = DateTime.UtcNow;
        }

        public void WriteTo(Stream s)
        {
            BincodingEncoder encoder = new BincodingEncoder(s);

            encoder.Encode((byte)1); //version
            encoder.Encode(_name);
            encoder.Encode((byte)_status);
            encoder.Encode(_deliveredOn);
        }

        #endregion

        #region properties

        public string Name
        { get { return _name; } }

        public MessageRecipientStatus Status
        { get { return _status; } }

        public DateTime DeliveredOn
        { get { return _deliveredOn; } }

        #endregion
    }
}
