using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Xml.Serialization;
using System.IO;

namespace LongReacher.Core.Test
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestMethod1()
        {
            var xmlSrc= "<?xml version=\"1.0\" encoding=\"utf - 8\"?>"+
                "<ArrayOfMessage xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">"+
                "<Message><Recepients /><Body>Let's go to Valhalla first and go to barbarella afterwards. </Body><IsIncoming>true</IsIncoming>"+
                "<IsRead>true</IsRead><Attachments /><LocalTimestamp>130811369350158144</LocalTimestamp><Sender>+12815553965</Sender></Message>"+
                "</ArrayOfMessage>";

            var xmlSerializer = new XmlSerializer(typeof(ArrayOfMessage));
            var k = xmlSerializer.Deserialize(new StringReader(xmlSrc))as ArrayOfMessage;
            Assert.AreEqual("+12815553965", k.Message[0].Sender);
            Assert.AreEqual(k.Message[0].UtcTime.Second, 55);
        }
    }
}
