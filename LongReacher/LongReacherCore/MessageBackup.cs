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
using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.6.1055.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class ArrayOfMessage {
    
    private ArrayOfMessageMessage[] messageField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Message")]
    public ArrayOfMessageMessage[] Message {
        get {
            return this.messageField;
        }
        set {
            this.messageField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ArrayOfMessageMessage {
    
    private ArrayOfMessageMessageRecepients recepientsField;
    
    private string bodyField;
    
    private bool isIncomingField;
    
    private bool isReadField;
    
    private ArrayOfMessageMessageMessageAttachment[] attachmentsField;
    
    private string localTimestampField;
    
    private string senderField;
    
    /// <remarks/>
    public ArrayOfMessageMessageRecepients Recepients {
        get {
            return this.recepientsField;
        }
        set {
            this.recepientsField = value;
        }
    }
    
    /// <remarks/>
    public string Body {
        get {
            return this.bodyField;
        }
        set {
            this.bodyField = value;
        }
    }
    
    /// <remarks/>
    public bool IsIncoming {
        get {
            return this.isIncomingField;
        }
        set {
            this.isIncomingField = value;
        }
    }
    
    /// <remarks/>
    public bool IsRead {
        get {
            return this.isReadField;
        }
        set {
            this.isReadField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("MessageAttachment", IsNullable=false)]
    public ArrayOfMessageMessageMessageAttachment[] Attachments {
        get {
            return this.attachmentsField;
        }
        set {
            this.attachmentsField = value;
        }
    }
    
    /// <remarks/>
    public string LocalTimestamp {
        get {
            return this.localTimestampField;
        }
        set {
            this.localTimestampField = value;
        }
    }

    public DateTime UtcTime
    {
        get {

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
    public string Sender {
        get {
            return this.senderField;
        }
        set {
            this.senderField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ArrayOfMessageMessageRecepients {
    
    private string[] stringField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("string")]
    public string[] @string {
        get {
            return this.stringField;
        }
        set {
            this.stringField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ArrayOfMessageMessageMessageAttachment {
    
    private string attachmentContentTypeField;
    
    private byte[] attachmentDataBase64StringField;
    
    /// <remarks/>
    public string AttachmentContentType {
        get {
            return this.attachmentContentTypeField;
        }
        set {
            this.attachmentContentTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
    public byte[] AttachmentDataBase64String {
        get {
            return this.attachmentDataBase64StringField;
        }
        set {
            this.attachmentDataBase64StringField = value;
        }
    }
}