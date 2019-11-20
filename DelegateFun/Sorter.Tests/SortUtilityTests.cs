using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [DataTestMethod]
        [DataRow(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 },
            new[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 2, 1, 0 })]
        public void SortUtility_ShouldAscendAbove3_ThenDescend(int[] array, int[] expected)
        {
            var sortUtility = new SortUtility();
            sortUtility.InsertionSort(array, (first, second) => { if (first < 3 || second < 3) { return first > second; } return first < second; });
            CollectionAssert.AreEqual(expected, array);

        }
        [DataTestMethod]
        [DataRow(new[] { 3, 4, 2, 5, 6, 7, 8, 9, 1, 0 }, new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9})]
        [DataRow(new[] { 0,0,0,2,1}, new[] { 0,0,0,1,2})]
        public void SortUtility_SortAscending(int[] array, int[] expected)
        {
            var sortUtility = new SortUtility();
            Comparison comparison = delegate (int first, int second)
            {
                return first < second;
            };
            sortUtility.InsertionSort(array, comparison);
            CollectionAssert.AreEqual(expected, array);
        }

        [DataTestMethod]
        [DataRow(new[] { 0 })]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtility_GivenNull_ExcpetionThrown(int[] array)
        {
            var sortUtility = new SortUtility();
            if(array is null)
            {
                sortUtility.InsertionSort(null, (first, second) => first > second);
            }
            sortUtility.InsertionSort(array, null);
        }
        [DataTestMethod]
        [DataRow(new[] { 1,4,2,3}, new[] { 4, 3, 2, 1 })]
        public void SortUtility_SortDescendingAlphabetical_UsingLambda(int[] array, int[] expected)
        {
            var sortUtility = new SortUtility();
            sortUtility.InsertionSort(array, (int first, int second) => { return first.ToString().CompareTo(second.ToString()) > 0; });
            CollectionAssert.AreEqual(array, expected);
        }


    }
}
