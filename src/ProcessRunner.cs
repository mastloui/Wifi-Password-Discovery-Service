using System.Diagnostics;

namespace WifiPasswordDiscoveryService
{
    public static class ProcessRunner
    {
        public static string Run(string cmd, string args)
        {
            ProcessStartInfo p = new ProcessStartInfo(cmd, args);
            p.CreateNoWindow = true;
            p.UseShellExecute = false;
            p.RedirectStandardOutput = true;

            var proc = Process.Start(p);
            string output = string.Empty;
            while (!proc.StandardOutput.EndOfStream)
            {
                output += proc.StandardOutput.ReadLine() + "\n";
            }

            return output;
        }
    }
}
