using System;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class BackspaceStringComparerTests
    {
        [Test]
        public void BackspaceStringComparerTestNegative1()
        {
            Assert.IsFalse(Compare("3333###", "3#"));
        }

        [Test]
        public void BackspaceStringComparerTestNegative2()
        {
            Assert.IsFalse(Compare("3333###", "3#3333"));
        }

        [Test]
        public void BackspaceStringComparerTestPositive1()
        {
            Assert.IsTrue(Compare("3###", "##"));
        }

        [Test]
        public void BackspaceStringComparerTestPositive2()
        {
            Assert.IsTrue(Compare("ab##", "c#d#"));
        }

        [Test]
        public void BackspaceStringComparerTestPositive3()
        {
            Assert.IsTrue(Compare("bxj##tw", "bxo#j##tw"));
        }

        [Test]
        public void BackspaceStringComparerTestPositive4()
        {
            Assert.IsTrue(Compare("nzp#o#g", "b#nzp#o#g"));
        }

        private bool Compare(string s, string t)
        {
            var sut = new BackspaceStringComparer();
            return sut.BackspaceCompare(s, t);
        }
    }
}