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

            int sum = 0;
            TraverseAndSumTree(root, 0, ref sum);

            return sum;
        }

        private void TraverseAndSumTree(TreeNode node, int number, ref int sum)
        {
            number = number | node.val;
            if (node.left == null && node.right == null)
            {
                sum += number;
                return;
            }

            if (node.left != null)
            {
                TraverseAndSumTree(node.left, number << 1, ref sum);
            }

            if (node.right != null)
            {
                TraverseAndSumTree(node.right, number << 1, ref sum);
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