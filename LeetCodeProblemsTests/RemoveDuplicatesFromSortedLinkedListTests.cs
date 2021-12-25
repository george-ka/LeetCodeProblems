using System;
using System.Collections.Generic;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class RemoveDuplicatesFromSortedLinkedListTests 
    {
        [Test]
        public void RemoveDuplicatesFromSortedLinkedListWithNoDuplicates()
        {
            var vals = new int[] { 0, 1, 2, 3, 4, 5 };
            var result = RemoveDuplicates(vals);
            Assert.AreEqual(vals, result);
        }

        [Test]
        public void RemoveDuplicatesFromSortedLinkedListWithEmptyList()
        {
            var vals = new int[] { };
            var result = RemoveDuplicates(vals);
            Assert.AreEqual(new int[] {}, result);
        }

        [Test]
        public void RemoveDuplicatesFromSortedLinkedListWithAllDuplicates()
        {
            var vals = new int[] { 1, 1, 2, 2 };
            var result = RemoveDuplicates(vals);
            Assert.AreEqual(new int[] {}, result);
        }

        [Test]
        public void RemoveDuplicatesFromSortedLinkedListWithAllDuplicates2()
        {
            var vals = new int[] { 1, 1, 1, 1 };
            var result = RemoveDuplicates(vals);
            Assert.AreEqual(new int[] {}, result);
        }

        [Test]
        public void RemoveDuplicatesFromSortedLinkedListWithDuplicatesInTheBeginning()
        {
            var vals = new int[] { 1, 1, 1, 2 };
            var result = RemoveDuplicates(vals);
            Assert.AreEqual(new int[] {2}, result);
        }

        [Test]
        public void RemoveDuplicatesFromSortedLinkedListWithDuplicatesInTheEnd()
        {
            var vals = new int[] { 0, 1, 1, 1  };
            var result = RemoveDuplicates(vals);
            Assert.AreEqual(new int[] {0}, result);
        }

        [Test]
        public void RemoveDuplicatesFromSortedLinkedListWithDuplicatesInTheMiddle()
        {
            var vals = new int[] { 0, 1, 1, 1, 2  };
            var result = RemoveDuplicates(vals);
            Assert.AreEqual(new int[] {0, 2}, result);
        }

        private int[] LinkedListToArray(ListNode head)
        {
            var list = new List<int>();
            var current = head;
            while (current != null)
            {
                list.Add(current.val);
                current = current.next;
            }

            return list.ToArray();
        }

        private ListNode ArrayToLinkedList(int[] vals)
        {
            if (vals == null || vals.Length == 0)
            {
                return null;
            }

            var head = new ListNode(vals[0]);
            var current = head;
            for (var i = 1; i < vals.Length; i++)
            {
                current.next = new ListNode(vals[i]);
                current = current.next;
            }

            return head;
        }

        private int[] RemoveDuplicates(int[] vals)
        {
            var sut = new RemoveDuplicatesFromSortedLinkedList();
            return LinkedListToArray(sut.DeleteDuplicates(ArrayToLinkedList(vals)));
        }
    }
}