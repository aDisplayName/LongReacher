using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var utf8 = new UTF8Encoding();
            var bytes=utf8.GetBytes("郭凤英");
            foreach (var byt in bytes)
                Console.Write("{0:X2} ", byt);
            Console.WriteLine();


        }
    }
}
