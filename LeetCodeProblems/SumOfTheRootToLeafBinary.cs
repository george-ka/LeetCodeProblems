using System;

namespace LeetCodeChallenges
{
    ///
    /// 1022. Sum of Root To Leaf Binary Numbers
    /// https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers/
    ///
    public class SumOfRootToLeafBinary
    {
        public int SumRootToLeaf(TreeNode root) 
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            var result = 0;


            return result;
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