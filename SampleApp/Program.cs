using System;
using Configuration;
using System.Collections.Generic;
namespace SampleApp
{
    public class Program
    {
        static void Main()
        {
            //Console.WriteLine("Hello World!");

            List<string> testStrings = new List<String> { "TestOne", "TestTwo", "TestThree" };
            IConfig fileConfig = new FileConfig();

            for (int steps=0; steps < testStrings.Count; steps++){
                fileConfig.SetConfigValue(testStrings[steps], steps.ToString());
            }
            PrintConfigSettings(fileConfig, testStrings);
        }

        // MMM Comment: Great refactoring for testibility.
        public static string FindSetting(IConfig config, string name)
        {
            if(config is null)
            {
                throw new ArgumentException("Config is null");
            }else if(name is null)
            {
                throw new ArgumentException("Name is null");
            }

            string? value = "";
            config.GetConfigValue(name, out value);

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid Name");
            }
            return $"{name}={value}";

        }
        public static void PrintConfigSettings(IConfig config, List<string> names)
        {
            if(config is null)
            {
                throw new ArgumentNullException($"The {nameof(config)} is null");
            }else if(names is null)
            {
                throw new ArgumentNullException("names is null");
            }

            foreach(string name in names)
            {
                Console.WriteLine(FindSetting(config, name));
            }
        }
    }
}
