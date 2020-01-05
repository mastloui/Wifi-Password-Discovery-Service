using System;
using System.Collections.Generic;
using System.Text;

namespace WifiPasswordDiscoveryService
{
    public static class ConsoleWriter
    {
        public static void WriteColor(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(str);
            Console.ResetColor();
        }

        public static void WriteLineColor(string str, ConsoleColor color)
        {
            WriteColor(str, color);
            Console.WriteLine();
        }
    }
}
