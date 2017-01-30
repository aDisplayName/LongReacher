using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoobeeVcfToIcloud
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DecodeQuotedCode("=E5=AE=81"));
            var sr = new StreamReader(new FileStream("00001.vcf", FileMode.Open));
            while(!sr.EndOfStream)
            {
                var newLline = sr.ReadLine();
                 Console.WriteLine(PrintParsedLine(newLline));
                              
            }
        }

        const string tag= ";CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE";
        private static string PrintParsedLine(string newLline)
        {
            var returningLine = "";
            if (newLline.Contains(tag))
            {
                var i = newLline.IndexOf(tag);
                returningLine += newLline.Substring(0, i);
                var inputBuffer = newLline.Substring(i + tag.Length);
                while (inputBuffer.Length > 0)
                {
                    var nextChar = getNextCharacters(ref inputBuffer);
                    returningLine += nextChar;
                }
            }
            else
                returningLine = newLline;
            return returningLine;
        }

        private static string getNextCharacters(ref string inputBuffer)
        {
            if (inputBuffer.Length == 0)
                return "";
            if (inputBuffer[0] != '=')
            {
                var result= inputBuffer[0].ToString();
                inputBuffer = inputBuffer.Substring(1);
                return result;
            }
            var bytes = new List<byte>();
            while (inputBuffer.Length > 0)
            {
                if (inputBuffer[0] != '=')
                    break;
                var codeStr = "";
                try
                {
                    codeStr = inputBuffer.Substring(0, 3);
                }
                catch (ArgumentOutOfRangeException)
                {
                    inputBuffer = "";
                    break;
                }
                byte b;
                if (!byte.TryParse(codeStr.Substring(1), NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out b))
                {
                    throw new Exception("Failed to parse " + codeStr);
                }
                bytes.Add(b);
                inputBuffer = inputBuffer.Substring(3);
            }
            return new string(new UTF8Encoding().GetChars(bytes.ToArray()));
        }

        private static string DecodeQuotedCode(string encodedCode)
        {
            byte b1, b2, b3;
            Byte.TryParse(encodedCode.Substring(1, 2), System.Globalization.NumberStyles.AllowHexSpecifier, CultureInfo.InstalledUICulture, out b1);
            Byte.TryParse(encodedCode.Substring(4, 2), NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out b2);
            Byte.TryParse(encodedCode.Substring(7, 2), NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out b3);

            return new string(new UTF8Encoding().GetChars(new[] { b1, b2, b3 }));
        }
    }
}
