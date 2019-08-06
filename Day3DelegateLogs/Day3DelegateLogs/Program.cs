using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3DelegateLogs
{
    class Program
    {
        public delegate void LoggerDelegate(string msg);

        public static void LogToScreen (string m)
        {
            Console.WriteLine("Screen: " +m);
        }

        public static void LogFancy(string mm)
        {
            Console.WriteLine("Fancy: " + mm);
        }

        public static void LogToFile(string message)
        {
            string dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            File.AppendAllText(@"..\..\log.txt", $"{dt}  " +message + Environment.NewLine);
        }

        static void Main(string[] args)
        {
            try { 
            LoggerDelegate logger;
                logger = LogToScreen;
                logger += LogFancy;
                logger += LogToFile;
                
                logger?.Invoke("Somthing happened"); //it's a nullable expression = if (logger != null) logger("Somthing happened");

            }
            finally
            {
                Console.WriteLine("press");
                Console.ReadLine();
            }
        }
    }
}
