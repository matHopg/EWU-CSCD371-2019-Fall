using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxTests
    {
        [TestMethod]
        public void Mailbox_ToString_ReturnValue_Success()
        {
            Mailbox mailbox = new Mailbox(Sizes.Medium, (2, 2), new Person("New", "Person"));
            Assert.AreEqual("New Person owns mailbox 2, 2 with size 'Medium'", mailbox.ToString());
        }

        [TestMethod]
        public void Mailbox_toString_NewOwnerOfMailBox()
        {
            Mailbox mailbox = new Mailbox(Sizes.Medium, (2, 2), new Person("New", "Person"));
            mailbox.Owner = (new Person("NewNew", "NewPerson"));
            Assert.AreEqual("NewNew NewPerson owns mailbox 2, 2 with size 'Medium'", mailbox.ToString());

        }

        [TestMethod]
        [DataRow(Sizes.Default)]
        [DataRow(Sizes.Small)]
        [DataRow(Sizes.Medium)]
        [DataRow(Sizes.Large)]
        public void Mailbox_toString_NoPremiumOptionsButAllSizes(Sizes sizes)
        {
            string size = sizes + "";
            if(sizes == Sizes.Default)
            {
                size = "";
            }
            Mailbox mailbox = new Mailbox(sizes, (2, 4), new Person("New", "Person"));
            Assert.AreEqual($"New Person owns mailbox 2, 4 with size '{size}'", mailbox.ToString());
        }
    }
}
