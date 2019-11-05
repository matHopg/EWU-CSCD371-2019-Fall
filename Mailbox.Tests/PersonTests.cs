using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [DataRow("First", null)]
        [DataRow(null, "Last")]
        public void Person_NullName(string firstName, string lastName)
        {
            Person person = new Person(firstName, lastName);
        }

        [TestMethod]
        public void Person_ValidNames_CreatesObject()
        {
            Person person = new Person("First", "Last");
            Assert.IsNotNull(person);
        }


        [TestMethod]
        [DataRow("First","Last")]
        [DataRow("Mat","Last")]
        public void Person_Equals_PeopleAreEqual(string firstName, string lastName)
        {
            Person first = new Person(firstName, lastName);
            Person second = new Person(firstName, lastName);
            bool success = first.Equals(second);
            Assert.IsTrue(success);

        }
    }
}
