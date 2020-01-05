using System.Collections.Generic;

namespace WifiPasswordDiscoveryService
{
    public static class NetSh
    {
        public const string WifiProfileKey = "Profile";
        public const string WifiPasswordKey = "Key Content";

        /// <summary>
        /// Generates a property bag partitioned on colon characters (':').
        /// </summary>
        /// <param name="netShOutput">The resulting output of a netsh command.</param>
        /// <returns></returns>
        public static Dictionary<string, string> GeneratePropertyBag(string netShOutput)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            string[] keyValuePair = netShOutput.Split(new char[] { '\n' });

            foreach (string line in keyValuePair)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                int separatorIndex = line.IndexOf(":");

                if (separatorIndex == -1)
                    continue;

                string key = line.Substring(0, separatorIndex).Trim();
                string value = line.Substring(separatorIndex + 1).Trim();

                map[key] = value;
            }

            return map;
        }
    }
}
