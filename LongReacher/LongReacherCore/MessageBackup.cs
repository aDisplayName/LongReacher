﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

// 
// This source code was auto-generated by xsd, Version=4.6.1055.0.
// 

namespace aDisplayName.LongReacher
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false, ElementName = "ArrayOfMessage")]
    public partial class MB_Library
    {

        private MB_Message[] messageField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Message")]
        public MB_Message[] Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class MB_Message
    {

        private MB_Recepients recepientsField;

        private string bodyField;

        private bool isIncomingField;

        private bool isReadField;

        private MB_Attachment[] attachmentsField;

        private string localTimestampField;

        private string senderField;

        /// <remarks/>
        public MB_Recepients Recepients
        {
            get
            {
                return this.recepientsField;
            }
            set
            {
                this.recepientsField = value;
            }
        }

        /// <remarks/>
        public string Body
        {
            get
            {
                return this.bodyField;
            }
            set
            {
                this.bodyField = value;
            }
        }

        /// <remarks/>
        public bool IsIncoming
        {
            get
            {
                return this.isIncomingField;
            }
            set
            {
                this.isIncomingField = value;
            }
        }

        /// <remarks/>
        public bool IsRead
        {
            get
            {
                return this.isReadField;
            }
            set
            {
                this.isReadField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("MessageAttachment", IsNullable = false)]
        public MB_Attachment[] Attachments
        {
            get
            {
                return this.attachmentsField;
            }
            set
            {
                this.attachmentsField = value;
            }
        }

        /// <remarks/>
        public string LocalTimestamp
        {
            get
            {
                return this.localTimestampField;
            }
            set
            {
                this.localTimestampField = value;
            }
        }

        public DateTime UtcTime
        {
            get
            {

                var retValue = DateTime.MinValue;
                var dValue = localTimestampField;
                if (dValue == null)
                    return retValue;
                var trimmedString = dValue.Trim();
                if (string.IsNullOrEmpty(trimmedString))
                    return retValue;

                Int64 ticks;
                if (long.TryParse(trimmedString, out ticks))
                {
                    return DateTime.FromFileTimeUtc(ticks);
                }
                return retValue;
            }
        }

        /// <remarks/>
        public string Sender
        {
            get
            {
                return this.senderField;
            }
            set
            {
                this.senderField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class MB_Recepients
    {

        private string[] stringField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("string")]
        public string[] @string
        {
            get
            {
                return this.stringField;
            }
            set
            {
                this.stringField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class MB_Attachment
    {

        private string attachmentContentTypeField;

        private byte[] attachmentDataBase64StringField;

        /// <remarks/>
        public string AttachmentContentType
        {
            get
            {
                return this.attachmentContentTypeField;
            }
            set
            {
                this.attachmentContentTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] AttachmentDataBase64String
        {
            get
            {
                return this.attachmentDataBase64StringField;
            }
            set
            {
                this.attachmentDataBase64StringField = value;
            }
        }
    }
}