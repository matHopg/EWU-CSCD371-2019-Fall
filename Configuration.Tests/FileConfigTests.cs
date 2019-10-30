using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class FileConfigTests
    {
        [TestInitialize]
        [TestCleanup]
        public void Initialize()
        {
            FileConfig.DeleteFile();
        }
        [DataTestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("         ")]
        [DataRow("=")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentException))]
        public void Get_Invalid_Name_Thrown_Exception(string name)
        {
            IConfig file = new FileConfig();
            SetValidDataForConfig(file);
            string? value = "";
            file.GetConfigValue(name, out value);
        }
        [DataTestMethod]
        [DataRow("", " ")]
        [DataRow(" ", " ")]
        [DataRow("       ", " ")]
        [DataRow("=", " ")]
        [DataRow(null, " ")]
        [ExpectedException(typeof(ArgumentException))]
        public void Set_Invalid_Name_Exception_Thrown(string name, string value)
        {
            IConfig file = new EnvironmentConfig();
            SetValidDataForConfig(file);
            file.SetConfigValue(name, value);
        }

        [DataTestMethod]
        [DataRow("Test=", "")]
        [DataRow("T est", null)]
        [DataRow(null, "")]
        [DataRow("=", null)]
        [ExpectedException(typeof(ArgumentException))]
        public void Set_Invalid_Name_And_Value(string name, string value)
        {
            IConfig file = new FileConfig();
            SetValidDataForConfig(file);
            file.SetConfigValue(name, value);
        }

        [TestMethod]
        public void Get_Correct_Value()
        {
            IConfig file = new FileConfig();
            SetValidDataForConfig(file);
            string? value = "";
            file.GetConfigValue("Valid0", out value);
            Assert.AreEqual("0", value);
            file.GetConfigValue("Valid1", out value);
            file.GetConfigValue("Valid3", out value);
        }

        [TestMethod]
        public void Get_Correct_Return()
        {
            IConfig file = new FileConfig();
            SetValidDataForConfig(file);
            string? value = "";
            Assert.IsTrue(file.GetConfigValue("Valid0", out value));
        }



        private void SetValidDataForConfig(IConfig config)
        {
            config.SetConfigValue("Valid0", "0");
            config.SetConfigValue("Valid1", "1");
            config.SetConfigValue("Valid3", "3");
        }
    }
}
