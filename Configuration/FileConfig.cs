using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Configuration
{
    public class FileConfig:IConfig 
    {
        static readonly string filePath = Environment.CurrentDirectory + "//config.settings";
        private const string EQUALS = "=";
        private const string SPACE = " ";

        public bool GetConfigValue(string name, out string? value)
        {
            value = "";
            if (!nameCheck(name))
            {
                return false;
            }

            string[] lines = File.ReadAllLines(filePath);
            for(int i =0; i<lines.Length; i++)
            {
                string[] currentLine = lines[i].Split("=");

#pragma warning disable CA1307 // Specify StringComparison
                if (currentLine[0].Equals(name) && !string.IsNullOrEmpty(currentLine[1]))
#pragma warning restore CA1307 // Specify StringComparison
                {
                    value = currentLine[1];
                    break;
                }
            }
            return !string.IsNullOrEmpty(value);
        }

        public bool SetConfigValue(string name, string? value)
        {
            if(!nameCheck(name) || !valueCheck(value))
            {
                return false;
            }
            if (!File.Exists(filePath))
            {
                File.AppendAllText(filePath, "");
            }

            List<string> lines = new List<string>(File.ReadAllLines(filePath));

            for(int steps =0; steps<lines.Count; steps++)
            {
#pragma warning disable CA1307 // Specify StringComparison
                if (lines[steps].StartsWith(name + EQUALS))
#pragma warning restore CA1307 // Specify StringComparison
                {
                    string[] currentLine = lines[steps].Split(EQUALS);

                    // MMM Comment: Use null forgiveness operator
#pragma warning disable CS8601 // Possible null reference assignment.
                    currentLine[1] = value;
#pragma warning restore CS8601 // Possible null reference assignment.

                    lines[steps] = $"{currentLine[0]}={currentLine[1]}{Environment.NewLine}";
                    File.WriteAllLines(filePath, lines);
                    return true;
                }
            }

            File.AppendAllText(filePath, $"{name}={value}{Environment.NewLine}");
            return true;
        }

        public static void DeleteFile()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        // MMM Comment: Isn't this code a duplicate?  Why not refactor?
        private static bool nameCheck(string? name)
        {
            if(name is null)
            {
                throw new ArgumentException($"The name: {name} is null");
            }else if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"The name: {name} is empty");
            }else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"The name: {name} is just whitespace");
#pragma warning disable CA1307 // Specify StringComparison
            }
            else if (name.Contains(SPACE))
#pragma warning restore CA1307 // Specify StringComparison
            {
                throw new ArgumentException($"The name: {name} has a space in it");
            }
#pragma warning disable CA1307 // Specify StringComparison
            else if (name.Contains(EQUALS))
#pragma warning restore CA1307 // Specify StringComparison
            {
                throw new ArgumentException($"The name {name} contains an equals sign");
            }
            return true;
        }
        
        private static bool valueCheck(string? value)
        {
            if(value is null)
            {
                throw new ArgumentException($"The value: {value} is null");
            }else if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"The value: {value} is empty");
            }
            return true;
        }
    }

    
}
