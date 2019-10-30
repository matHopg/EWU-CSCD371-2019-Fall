using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {
        private const string EQUALS = "=";
        private const string SPACE = " ";
        public bool GetConfigValue(string key, out string? pair)
        {
            pair = "";
            if (!nameCheck(key))
            {
                return false;
            }
            pair = Environment.GetEnvironmentVariable(key);
            return !string.IsNullOrEmpty(pair);
        }
        
        public bool SetConfigValue(string key, string? pair)
        {
            if(!nameCheck(key) || !valueCheck(pair))
            {
                return false;
            }
            Environment.SetEnvironmentVariable(key, pair, EnvironmentVariableTarget.Process);
            return true;
        }

        private static bool nameCheck(string? key)
        {
            if (key is null)
            {
                throw new ArgumentException($"The key: {key} is null");
            }
            else if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException($"The key: {key} is empty");
            }
            else if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"The key: {key} is just whitespace");
#pragma warning disable CA1307 // Specify StringComparison
            }
            else if (key.Contains(SPACE))
#pragma warning restore CA1307 // Specify StringComparison
            {
                throw new ArgumentException($"The key: {key} has a space in it");
            }
#pragma warning disable CA1307 // Specify StringComparison
            else if (key.Contains(EQUALS))
#pragma warning restore CA1307 // Specify StringComparison
            {
                throw new ArgumentException($"The key {key} contains an equals sign");
            }
            return true;
        }
        private static bool valueCheck(string? pair) {
                if(pair is null)
                {
                    throw new ArgumentException($"The value: {pair} is null");
                }else if (string.IsNullOrEmpty(pair))
                {
                    throw new ArgumentException($"The value{pair} is empty");
                }
                return true;
        } 
    }
}
