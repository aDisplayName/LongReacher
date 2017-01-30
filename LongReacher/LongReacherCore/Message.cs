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

        public Message(MB_Message messageRecord):this()
        {
            if (messageRecord == null)
                return;
            Sender = messageRecord.Sender;
            Incoming = messageRecord.IsIncoming;
            try
            {
                LocalTimestamp = long.Parse(messageRecord.LocalTimestamp);
            }
            finally
            {

            }
            Body = messageRecord.Body;
            if(messageRecord.Recepients!=null)
            {
                foreach (var recipient in messageRecord.Recepients.@string)
                {
                    Recipients.AddRecipient(recipient);
                }
            }

            if (messageRecord.Attachments != null)
            {
                foreach (var attachment in messageRecord.Attachments)
                {
                    Attachments.Add(new MessageAttachment(attachment));
                }
            }
        }
        public long LocalTimestamp { get; set; }
        public string Sender { get; set; }
        public bool Incoming { get; set; }
        public Recipients Recipients { get; }
        public string Body { get; set; }
        public MessageAttachments Attachments;
        public bool IsSameMessage(Message another)
        {
            if (another == null)
                return false;
            return LocalTimestamp.Equals(another.LocalTimestamp);
        }

        public void MergeIfSame(Message another)
        {
            if (!IsSameMessage(another))
                return;

            // Only recipient will be merged. We assume the rest information are the same.
            if (another.Recipients == null)
                return;
            foreach (var recipient in another.Recipients)
            {
                Recipients.AddRecipient(recipient);
            }
        }
    }

    public class MessageAttachments: List<MessageAttachment>
    {
    }

    public class MessageAttachment
    {
        public MessageAttachment()
        {
            MessageAttachmentType = string.Empty;
            MessageAttachmentBytes = null;
        }

        public MessageAttachment(MB_Attachment rawAttachment):this()
        {
            if(rawAttachment!=null)
            {
                MessageAttachmentType = rawAttachment.AttachmentContentType;
                MessageAttachmentBytes = rawAttachment.AttachmentDataBase64String.Clone() as byte[];
            }
        }
        public string MessageAttachmentType { get; private set; }
        public byte[] MessageAttachmentBytes { get; private set; }
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
