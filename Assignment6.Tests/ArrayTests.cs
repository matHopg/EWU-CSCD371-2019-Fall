using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Assignment6.Tests
{
    [TestClass]
    public class ArrayTests
    {
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Cannot_Add_When_Size_Is_Full()
        {
            Array<int> testArray = new Array<int>(0);
            testArray.Add(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Cannot_Add_Null_Type()
        {
            Array<string> testArray = new Array<string>(1);
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
            string? t = null;
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
            testArray.Add(t);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Exception_When_Item_Doesnt_Exist_Array_Empty()
        {
            Array<string> testArray = new Array<string>(1);
            testArray.Contains("Matthew");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Exception_When_Item_Doesnt_Exist_Array_Filled()
        {
            Array<string> testArray = new Array<string>(1);
            testArray.Add("Hopkins");
            testArray.Contains("Matthew");
        }

        [TestMethod]
        public void Array_Contains_Return_True()
        {
            Array<string> testArray = new Array<string>(1);
            testArray.Add("Matthew");
            Assert.IsTrue(testArray.Contains("Matthew"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CopyTo_Validates_Array_Is_To_Small()
        {
            int genericSize = 2;
            int copyArraySizeIsSmaller = 1;
            Array<string> testArray = new Array<string>(genericSize);
            string[] copyArray = new string[copyArraySizeIsSmaller];
            testArray.CopyTo(copyArray, 0);
        }

        [TestMethod]
        public void CopyTo_Copies_Succesfully()
        {
            Array<string> testArray = new Array<string>(2);
            List<string> testList = new List<string>();
            testList.Add("First");
            testList.Add("Second");
            foreach(string s in testList)
            {
                testArray.Add(s);
            }
            string[] copyArray = new string[testArray.Count];
            testArray.CopyTo(copyArray, 0);

            int i = 0;
            foreach(string s in testList)
            {
                Assert.IsTrue(s == copyArray[i]);
                i++;
            }
        }

        [TestMethod]
        public void Index_Operator_Retrieves_Succesfully()
        {
            string[] basicArray = new string[] { "1", "2", "3" };
            Array<string> testArray = new Array<string>() { "1", "2", "3" };
            for(int i =0; i<basicArray.Length; i++)
            {
                Assert.IsTrue(testArray[i] == basicArray[i]);
            }
        }
        [TestMethod]
        public void Remove_Returns_True_Decrements_Count()
        {
            int size = 2;
            Array<string> testArray = new Array<string>(size);
            string testString = "test";
            testArray.Add(testString);
            Assert.IsTrue(testArray.Remove(testString));
            Assert.IsTrue(testArray.Count == 0);
        }

        [TestMethod]
        public void Clear_Sets_Count_to_Zero()
        {
            int csize = 1;
            Array<string> testArray = new Array<string>(csize);
            string name = "test";
            testArray.Add(name);
            testArray.Clear();
            Assert.IsTrue(testArray.Size == csize);
            Assert.IsTrue(testArray.Count == 0);
           
        }
    }
}
