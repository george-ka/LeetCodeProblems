using System;
using System.Collections.Generic;

namespace LeetCodeChallenges
{
    ///
    /// 94. Binary Tree Inorder Traversal

    /// https://leetcode.com/problems/binary-tree-inorder-traversal/
    ///
    public class BinaryTreeInorderTraversal
    {
        public IList<int> InorderTraversal(TreeNode root) 
        {
            var result = new List<int>();
            var stack = new Stack<TreeNode>();

            var node = root;

            while (node != null || stack.Count > 0)
            {
                if (node.right != null)
                {
                    stack.Push(node.right);
                }
                
                if (node.left != null || node.right != null)
                {
                    stack.Push(new TreeNode(node.val));
                }

                if (node.left != null)
                {
                    node = node.left;
                }
                else if (node.right == null)
                {
                    result.Add(node.val);
                    node = stack.Count > 0 ? stack.Pop() : null;
                }
                else
                {
                    node = stack.Count > 0 ? stack.Pop() : null;
                }
                
            }

            return result;
        }
        
        public void TraverseInorderRecursively(TreeNode node, List<int> result)
        {
            if (node.left != null)
            {
                TraverseInorderRecursively(node.left, result);
            }

            result.Add(node.val);

            if (node.right != null)
            {
                TraverseInorderRecursively(node.right, result);
            }
        }

    
        public class TreeNode 
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}