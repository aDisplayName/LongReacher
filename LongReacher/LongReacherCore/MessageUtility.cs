using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aDisplayName.LongReacher.Core
{
    public static class MessageUtility
    {
        public static void FillDefaultSender(this MB_Message message, string defaultSender)
        {
            if(message!=null)
            {
                if(!string.IsNullOrEmpty(message.Sender))
                {
                    if (!string.IsNullOrEmpty(message.Sender.Trim()))
                        return;
                }
                message.Sender = defaultSender;
            }

        }

        public static string CleanPhoneNumber(this string rawphonenumber)
        {
            var rp = rawphonenumber.Trim().ToCharArray();
            var k = new StringBuilder();
            for (var i=0;i<rp.Length;i++)
            {
                if (i == 0)
                {
                    if (rp[i] == '+')
                    {
                        k.Append("+");
                    }
                }
                if(char.IsDigit(rp[i]))
                {
                    k.Append(rp[i]);
                }
            }

            return k.ToString();
        }

        public static bool SimiliarToPhoneNumber(this string thisNumber, string comparedTo)
        {
            if (string.IsNullOrEmpty(comparedTo))
                return true;
            var cleanedCompare = comparedTo.CleanPhoneNumber();
            var cleanedRef = thisNumber.CleanPhoneNumber();

            if (cleanedRef.Length > cleanedCompare.Length)
                return cleanedRef.EndsWith(cleanedCompare);
            else
                return cleanedCompare.EndsWith(cleanedRef);
        }
    }
}
