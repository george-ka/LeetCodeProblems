using System;
using System.Collections.Generic;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class SearchInSortedMatrixTests
    {
        [Test]
        public void SearchInSortedMatrixTest1()
        {
            var result = GetTestResult(GetTestMatrix(), 1);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void SearchInSortedMatrixTest2()
        {
            var result = GetTestResult(GetTestMatrix(), 10);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void SearchInSortedMatrixTest3()
        {
            var result = GetTestResult(GetTestMatrix(), 23);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void SearchInSortedMatrixTest4()
        {
            var result = GetTestResult(GetTestMatrix(), 5);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void SearchInSortedMatrixTest5()
        {
            var result = GetTestResult(GetTestMatrix(), 16);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void SearchInSortedMatrixTest6()
        {
            var result = GetTestResult(GetTestMatrix(), 60);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void SearchInSortedMatrixTest7()
        {
            var result = GetTestResult(GetTestMatrix(), 2);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void SearchInSortedMatrixTest8()
        {
            var result = GetTestResult(GetTestMatrix(), 30);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void SearchInSortedMatrixTestSingleElement()
        {
            var result = GetTestResult(new int[][] { new int[] { 1 } }, 1);
            Assert.AreEqual(true, result);
        }

        private bool GetTestResult(int[][] matrix, int target)
        {
            var sut = new SearchInSortedMatrix();
            return sut.SearchMatrix(matrix, target);
        }

        private int[][] GetTestMatrix()
        {
            return new int[][] 
            { 
                new int[] { 1,3,5,7 },
                new int[] { 10,11,16,20 },
                new int[] { 23,30,34,60 }
            };
        }
    }
}