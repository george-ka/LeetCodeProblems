using System;

namespace LeetCodeChallenges
{
    ///
    /// 82. Remove Duplicates from Sorted List II
    /// https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/
    ///
    /// Given the head of a sorted linked list, 
    /// delete all nodes that have duplicate numbers, 
    /// leaving only distinct numbers from the original list. 
    /// Return the linked list sorted as well.
    public class RemoveDuplicatesFromSortedLinkedList
    {
        public ListNode DeleteDuplicates(ListNode head) 
        {
            if (head == null)
            {
                return null;
            }
            
            var current = head;
            var tempHead = new ListNode(head.val - 1, head);
            ListNode lastNonDuplicate = null;
            var previous = tempHead;

            // 1 2 3 3 4 4 5
            while (current != null)
            {
                if (current.val != previous.val)
                {
                    if (lastNonDuplicate != null)
                    {
                        lastNonDuplicate.next = previous;    
                    }
                    
                    lastNonDuplicate = previous;
                }
                else
                {
                    var duplicateVal = current.val;
                    while (current != null && current.val == duplicateVal)
                    {
                        current = current.next;
                    }    
                }

                previous = current;
                current = current == null ? null : current.next;
            }

            lastNonDuplicate.next = previous;
            return tempHead.next;
        }
    }

    public class ListNode 
    {
        public ListNode(int val = 0, ListNode next = null) 
        {
            this.val = val;
            this.next = next;
        }
        
        public int val;
        public ListNode next;
    }
}