using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace DetectBtcClipper
{
    internal class Program
    {
        static string test_address = "3FZbgi29cpjq2GjdwV8eyHuJJnkLtktZc5";
        static void Main(string[] args)
        {
            Console.WriteLine("Your clipboard will clean if do you want continue press any key");
            Console.ReadKey();
            Warning();
            Console.WriteLine("Scanning...\n");
            Detect();
            Console.ReadKey();
        }
        static void Warning()
        {
            Console.WriteLine("Scanner starting please wait 5 second and dont copy nothing!!");
            Thread.Sleep(1000);
            Console.Clear();
        }
        static void Detect()
        {
            Clipboard.SetText(test_address);
            Thread.Sleep(5000);
            Match regex = Regex.Match(Clipboard.GetText(), "^(bc1|[13])[a-zA-HJ-NP-Z0-9]{25,39}$");
            if (regex.Success && regex.Value != test_address)
            {
                Console.WriteLine("Detected!");
            }
            else
            {
                Console.WriteLine("Not Detected");
            }
        }

    }
}
