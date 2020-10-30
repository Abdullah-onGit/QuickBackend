using System;
using System.Net;
using QuickBackend;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (QuickServer.IsSupported)
            {
                QuickServer server = new QuickServer();
                server.DefalutConfiguration();
                server.Start();
            }
            else
            {
                Console.WriteLine("Sorry is application not supported");
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }
        }
       
    }
}
