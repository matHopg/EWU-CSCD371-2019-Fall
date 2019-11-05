using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class DataLoaderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Load_StreamIsNull_ThrowException()
        {
            DataLoader dataLoader = new DataLoader(null);
        }
        [TestMethod]
        public void DataLoader_Save_Success()
        {
            List<Mailbox> boxList = new List<Mailbox>();
            MemoryStream memoryStream = new MemoryStream();
            DataLoader dataLoader = new DataLoader(memoryStream);
            boxList.Add(new Mailbox(Sizes.Small, new ValueTuple<int, int>(1, 1), new Person("New", "Person")));
            dataLoader.Save(boxList);
            dataLoader.Dispose();
        }

        [TestMethod]
        public void Load_ReturnMailboxes()
        {
            List<Mailbox> boxList = new List<Mailbox>();
            MemoryStream memoryStream = new MemoryStream();
            DataLoader dataLoader = new DataLoader(memoryStream);
            boxList.Add(new Mailbox(Sizes.Small, new ValueTuple<int, int>(1, 1), new Person("New", "Person")));
            boxList.Add(new Mailbox(Sizes.Small, new ValueTuple<int, int>(1, 3), new Person("New", "Person2")));
            boxList.Add(new Mailbox(Sizes.Small, new ValueTuple<int, int>(1, 5), new Person("New", "Person3")));
            dataLoader.Save(boxList);
            boxList = dataLoader.Load();
            Assert.AreEqual(boxList.Count, 3);
            Assert.IsTrue(boxList.Contains(new Mailbox(Sizes.Small, new ValueTuple<int, int>(1, 3), new Person("New", "Person2"))));
        }
        [TestMethod]
        public void DataLoader_Load_JsonReaderException()
        {
            MemoryStream memoryStream = new MemoryStream();
            using (StreamWriter streamWriter = new StreamWriter(memoryStream, leaveOpen: true))
            {
                streamWriter.Write(new Mailbox(Sizes.Small, (1, 1), new Person("New", "Person")));
            }
            DataLoader dataLoader = new DataLoader(memoryStream);
            Assert.IsNull(dataLoader.Load());
            dataLoader.Dispose();
        }
    }
}
