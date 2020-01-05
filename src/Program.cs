using System;
using System.Collections.Generic;

namespace WifiPasswordDiscoveryService
{
    class Program
    {
        static void Main(string[] args)
        {
            //Extract wifi name
            string networkName = 
                NetSh.GeneratePropertyBag(ProcessRunner.Run("netsh", "wlan show interfaces"))[NetSh.WifiProfileKey];
            
            if (string.IsNullOrEmpty(networkName))
            {
                Console.WriteLine("You are not connected to a network!");
                return;
            }
            Dictionary<string,string> profilePropertyBag = 
                NetSh.GeneratePropertyBag(ProcessRunner.Run("netsh", $"wlan show profiles \"{networkName}\" key=clear"));

            if (!profilePropertyBag.ContainsKey(NetSh.WifiPasswordKey))
            {
                Console.WriteLine($"Network '{networkName}' does not require a password!");
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
