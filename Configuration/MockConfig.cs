using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    // MMM Comment: Preferable if this is in a test project.
    public class MockConfig : IConfig
    {
        private Dictionary<string, string> keyValuePairs;
        private const string EQUALS = "=";
        private const string SPACE = " ";

        public MockConfig()
        {
            keyValuePairs = new Dictionary<string, string>();
            keyValuePairs.Add("TestOne", "1");
            keyValuePairs.Add("TestTwo", "2");
            keyValuePairs.Add("TestThree", "3");

        }
        public bool GetConfigValue(string key, out string? value)
        {
            value = "";
            if (!nameCheck(key))
            {
                return false;
            }else if (keyValuePairs.ContainsKey(key))
            {
                value = keyValuePairs[key];
            }
            return !string.IsNullOrEmpty(value);
        }
        
        public bool SetConfigValue(string key, string? value)
        {
            if(!nameCheck(key) || !valueCheck(value))
            {
                return false;
            }else if (keyValuePairs.ContainsKey(key))
            {
                // MMM Comment: Use null forgiveness operator
#pragma warning disable CS8601 // Possible null reference assignment.
                keyValuePairs[key] = value;
#pragma warning restore CS8601 // Possible null reference assignment.
            }
            else
            {
#pragma warning disable CS8604 // Possible null reference argument.
                keyValuePairs.Add(key, value);
#pragma warning restore CS8604 // Possible null reference argument.
            }
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
        private static bool valueCheck(string? value)
        {
            if (value is null)
            {
                throw new ArgumentException($"The value: {value} is null");
            }
            else if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"The value: {value} is empty");
            }
            return true;
        }
    
    
    }
}
