using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Xml.Serialization;
using System.IO;

namespace aDisplayName.LongReacher.Core.Test
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

            var xmlSerializer = new XmlSerializer(typeof(MB_Library));
            var k = xmlSerializer.Deserialize(new StringReader(xmlSrc))as MB_Library;
            Assert.AreEqual("+12815553965", k.Message[0].Sender);
            Assert.AreEqual(k.Message[0].UtcTime.Second, 55);
        }

        [TestMethod]
        public void SenderList()
        {
            var m = new MB_Message();
            m.Sender = "";
            m.FillDefaultSender("Thomas");
            Assert.AreEqual("Thomas", m.Sender);

            m.Sender = " ";
            m.FillDefaultSender("Thomas");
            Assert.AreEqual("Thomas", m.Sender);

            m.Sender = "Reed";
            m.FillDefaultSender("Thomas");
            Assert.AreEqual("Reed", m.Sender);
        }

        [TestMethod]
        public void MmsMethod()
        {
                var xmlSerializer = new XmlSerializer(typeof(MB_Library));
            MB_Library mb;
            using (var k = new FileStream(Path.Combine(AppContext.BaseDirectory, "TestMMS.msg"), FileMode.Open, FileAccess.Read))
            {
                mb = xmlSerializer.Deserialize(k) as MB_Library;
            }
            
        }

        [TestMethod]
        public void ValidatePhoneCleaner()
        {
            Assert.AreEqual(" +86(10) 6061-6061".CleanPhoneNumber(), "+861060616061");
            Assert.AreEqual(" 86+(10) 6061-6061".CleanPhoneNumber(), "861060616061");
        }
    }
}
