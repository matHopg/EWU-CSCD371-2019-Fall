using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class EnvironmentConfigTests
    {
        [DataTestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("         ")]
        [DataRow("=")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentException))]
        public void Get_Invalid_Name_Thrown_Exception(string name)
        {
            IConfig environment = new EnvironmentConfig();
            SetValidDataForConfig(environment);
            string? value = "";
            environment.GetConfigValue(name, out value);
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
            IConfig environment = new EnvironmentConfig();
            SetValidDataForConfig(environment);
            environment.SetConfigValue(name, value);
        }

        [DataTestMethod]
        [DataRow("Test=", "")]
        [DataRow("T est", null)]
        [DataRow(null, "")]
        [DataRow("=", null)]
        [ExpectedException(typeof(ArgumentException))]
        public void Set_Invalid_Name_And_Value(string name, string value)
        {
            IConfig environment = new EnvironmentConfig();
            SetValidDataForConfig(environment);
            environment.SetConfigValue(name, value);
        }

        [TestMethod]
        public void Get_Correct_Value()
        {
            IConfig environment = new EnvironmentConfig();
            SetValidDataForConfig(environment);
            string? value = "";
            environment.GetConfigValue("Valid0", out value);
            Assert.AreEqual("0", value);
            environment.GetConfigValue("Valid1", out value);
            environment.GetConfigValue("Valid3", out value);
        }

        [TestMethod]
        public void Get_Correct_Return()
        {
            IConfig environment = new EnvironmentConfig();
            SetValidDataForConfig(environment);
            string? value = "";
            Assert.IsTrue(environment.GetConfigValue("Valid0", out value));
        }
        


        private void SetValidDataForConfig(IConfig config)
        {
            config.SetConfigValue("Valid0", "0");
            config.SetConfigValue("Valid1", "1");
            config.SetConfigValue("Valid3", "3");
        }
    }
}
