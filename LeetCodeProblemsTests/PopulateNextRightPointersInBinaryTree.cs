using System;
using System.Collections.Generic;

namespace LeetCodeChallenges
{
    ///
    /// 117. Populating Next Right Pointers in Each Node II
    /// https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii/
    /// 
    /// Given a binary tree.
    /// Populate each next pointer to point to its next right node. 
    /// If there is no next right node, the next pointer should be set 
    /// to NULL.
    /// Initially, all next pointers are set to NULL.
    public class PopulateNextRightPointersInBinaryTree
    {
        public Node Connect(Node root) 
        {
            PopulateRight(root, null, null);
            return root;
        }

        private void PopulateRight(
            Node node,
            Node rightSibling, 
            Node parentsNext)
        {
            if (node == null)
            {
                return;
            }

            if (rightSibling != null)
            {
                node.next = rightSibling;
            }
            else if (parentsNext != null)
            {
                var next = parentsNext;
                while (next != null && node.next == null)
                {
                    if (next.left != null)
                    {
                        node.next = next.left;
                    }
                    else if (next.right != null)
                    {
                        node.next = next.right;
                    }

                    next = next.next;
                }
            }

            // first go right child 
            PopulateRight(node.right, null, node.next);
            // then left
            PopulateRight(node.left, node.right, node.next);
        }

        public class Node 
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() {}

            public Node(int _val) 
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next) 
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }
    }
}