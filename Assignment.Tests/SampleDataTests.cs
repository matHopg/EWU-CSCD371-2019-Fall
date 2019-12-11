
using System;
using System.Collections.Generic;
using System.IO;
using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void CsvRows_AreReadCorrectly()
        {            
            string[] expected = File.ReadAllLines("People.csv");
            string expectedLine = "";
            for (int i = 1; i < expected.Length; i++)
            {
                expectedLine += expected[i] + " ";
            }
            SampleData sampleData = new SampleData();            
            IEnumerable<string> actual = sampleData.CsvRows;
            string actualString = "";
            foreach (string s in actual)
            {
                actualString += s + " ";
            }
            
            Assert.AreEqual(expectedLine, actualString);
        }
        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_AreCorrect()
        {
            SampleData sampleData = new SampleData();
            Assert.AreEqual("AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV", sampleData.GetAggregateSortedListOfStatesUsingCsvRows());
        }
        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_AreCorrect()
        {
            SampleData sampleData = new SampleData();
            IEnumerable<string> actual = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            string actualString = "";
            foreach (string s in actual)
            {
                actualString += s + " ";
            }

            Assert.AreEqual("AL AZ CA DC FL GA IN KS LA MD MN MO MT NC NE NH NV NY OR PA SC TN TX UT VA WA WV ", actualString);
        }
        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection_AreCorrect()
        {
            SampleData sampleData = new SampleData();
            IEnumerable<IPerson> people = sampleData.People;

            Assert.AreEqual("AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV", sampleData.GetAggregateListOfStatesGivenPeopleCollection(people));
        }
        [TestMethod]
        public void FilterByEmailAddress_AreCorrect()
        {
            SampleData sampleData = new SampleData();
            (string, string) expectedPriscilla = ("Priscilla", "Jenyns");
            (string, string) expectedKarin = ("Karin", "Joder");
            (string, string) expectedScarface = ("Scarface", "Dennington");
            (string, string) actualPriscillaString = ("", "");
            (string, string) actualKarinString = ("", "");
            (string, string) actualScarfaceString = ("", "");

            //Act
            IEnumerable<(string, string)> actualPriscilla = sampleData.FilterByEmailAddress("pjenyns0@state.gov");
            IEnumerable<(string, string)> actualKarin = sampleData.FilterByEmailAddress("kjoder1@quantcast.com");
            IEnumerable<(string, string)> actualScarface = sampleData.FilterByEmailAddress("sdennington9@chron.com");
            foreach ((string, string) name in actualPriscilla)
            {
                actualPriscillaString = name;
            }
            foreach ((string, string) name in actualKarin)
            {
                actualKarinString = name;
            }
            foreach ((string, string) name in actualScarface)
            {
                actualScarfaceString = name;
            }

            //Assert
            Assert.AreEqual(expectedPriscilla, actualPriscillaString);
            Assert.AreEqual(expectedKarin, actualKarinString);
            Assert.AreEqual(expectedScarface, actualScarfaceString);
        }
        [TestMethod]
        public void People_AreCorrect()
        {
            SampleData sampleData = new SampleData();
            sampleData.People.GetEnumerator().MoveNext();
            int count = 0;
            foreach (Person person in sampleData.People)
            {
                count++;
            }

            Assert.AreEqual(50, count);
        }

    }
}
