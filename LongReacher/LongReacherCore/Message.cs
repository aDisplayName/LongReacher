using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aDisplayName.LongReacher.Core
{
    public class Message
    {
        public Message()
        {
            Sender = null;
            Incoming = true;
            Recipients = new Recipients();
        }
        public long LocalTimestamp { get; set; }
        public string Sender { get; set; }
        public bool Incoming { get; set; }
        public Recipients Recipients { get; }
        public string Body { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var typedObj = obj as Message;
            if (typedObj == null)
                return false;

            if (typedObj.LocalTimestamp != LocalTimestamp)
                return false;
            if (!typedObj.Sender.Equals(Sender))
                return false;
            if (typedObj.Incoming != Incoming)
                return false;
            if (!typedObj.Body.Equals(Body))
                return false;

            return true;
        }
    }

    public class MessageAttachments: List<MessageAttachment>
    {
        public override bool Equals(object obj)
        {
            var k = obj as MessageAttachments;
            if (k == null)
                return false;

            if (k.Count != Count)
                return false;
            for(var i=0;i<Count;i++)
            {
                if (!this[i].Equals(k[i]))
                    return false;
            }
            return true;
        }
    }

    public class MessageAttachment
    {
        public MessageAttachment()
        {
            MessageAttachmentType = string.Empty;
            MessageAttachmentInBASE64 = string.Empty;
        }
        public string MessageAttachmentType { get; set; }
        public string MessageAttachmentInBASE64 { get; set; }

        public override bool Equals(object obj)
        {
            var k = obj as MessageAttachment;
            if (k == null)
                return false;
            if (!MessageAttachmentType.Equals(k.MessageAttachmentType))
                return false;
            if (!MessageAttachmentInBASE64.Equals(k.MessageAttachmentInBASE64))
                return false;
            return true;
        }
    }
    public class Recipients: List<string>
    {
        public void AddRecipient(string number)
        {
            if (string.IsNullOrEmpty(number))
                return;
            number = number.Trim();
            if (string.IsNullOrEmpty(number))
                return;
            foreach(var existingNumber in this)
            {
                if (existingNumber.SimiliarToPhoneNumber(number))
                    return;
            }
            this.Add(number.CleanPhoneNumber());
        }
    }
}
