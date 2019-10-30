using Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SampleApp.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("         ")]
        [DataRow("=")]
        [DataRow(null)]
        [DataRow("NotAPlace")]
        [ExpectedException(typeof(ArgumentException))]
        public void FindSettings_Invalid_Name_Excpetion(string name)
        {
            IConfig mock = new MockConfig();
            Program.FindSetting(mock, name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindSettings_With_Null_Config()
        {
            Program.FindSetting(null, "TestOne");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Print_Null_Name_Thrown_Exception()
        {
            IConfig mock = new MockConfig();
            Program.PrintConfigSettings(mock, null);
        }
    }
}
