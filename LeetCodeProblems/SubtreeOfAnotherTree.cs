using System;
using System.Collections.Generic;

namespace LeetCodeChallenges
{
    ///
    /// 572. Subtree of Another Tree
    /// https://leetcode.com/problems/subtree-of-another-tree/
    ///
    /// Given the roots of two binary trees root and subRoot, 
    /// return true if there is a subtree of root with the same 
    /// structure and node values of subRoot and false otherwise.
    /// A subtree of a binary tree tree is a tree that consists of 
    /// a node in tree and all of this node's descendants. The tree 
    /// tree could also be considered as a subtree of itself.
    public class SubtreeOfAnotherTree
    {
        public bool IsSubtree(TreeNode root, TreeNode subRoot) 
        {
            if (root == null)
            {
                if (subRoot == null)
                {
                    return true;
                }

                return false;
            }

            if (subRoot == null)
            {
                return true;
            }

            // node values are not unique
            if (root.val == subRoot.val)
            {
                var tryThis = TraverseAndCompare(root, subRoot);
                if (tryThis)
                {
                    return true;
                }
            }

            return IsSubtree(root.left, subRoot) 
                || IsSubtree(root.right, subRoot);
        }

        private bool TraverseAndCompare(TreeNode node, TreeNode subNode)
        {
            if (node == null && subNode == null)
            {
                return true;
            }

            if (node == null || subNode == null)
            {
                return false;
            }

            if (node.val != subNode.val)
            {
                return false;
            }

            return TraverseAndCompare(node.left, subNode.left)
                && TraverseAndCompare(node.right, subNode.right);
        }

        /// Definition for a binary tree node.
        public class TreeNode 
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) 
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    } 
}