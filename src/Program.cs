using System;
using System.Collections.Generic;

namespace WifiPasswordDiscoveryService
{
    class Program
    {
        static void Main(string[] args)
        {
            //Extract wifi name
            Dictionary<string,string> networkInterfacePropertyBag = 
                NetSh.GeneratePropertyBag(ProcessRunner.Run("netsh", "wlan show interfaces"));
            
            if(!networkInterfacePropertyBag.ContainsKey(NetSh.WifiProfileKey))
            {
                Console.WriteLine("You are not connected to a Wifi network!");
                Console.ReadKey();
                return;
            }

            string networkName = networkInterfacePropertyBag[NetSh.WifiProfileKey];
            Dictionary<string,string> profilePropertyBag = 
                NetSh.GeneratePropertyBag(ProcessRunner.Run("netsh", $"wlan show profiles \"{networkName}\" key=clear"));

            if (!profilePropertyBag.ContainsKey(NetSh.WifiPasswordKey))
            {
                Console.WriteLine($"Network '{networkName}' does not require a password!");
                Console.ReadKey();
                return;
            }

            Console.Write("Wifi Name:\t");
            Console.WriteLine(networkName);

            Console.Write("Wifi Password:\t");
            ConsoleWriter.WriteLineColor(profilePropertyBag[NetSh.WifiPasswordKey], ConsoleColor.Green);
            Console.ReadKey();
        }
    }
}
