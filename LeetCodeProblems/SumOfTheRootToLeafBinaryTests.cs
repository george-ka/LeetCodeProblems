using System;

namespace LeetCodeChallenges
{
    class SumOfTheRootToLeafBinaryTests
    {
        public static void Test()
        {
            var tree = new SumOfRootToLeafBinary.TreeNode(1);
            tree.left = new SumOfRootToLeafBinary.TreeNode(0);
            tree.left.left = new SumOfRootToLeafBinary.TreeNode(0);
            tree.left.right = new SumOfRootToLeafBinary.TreeNode(1);
            
            tree.right = new SumOfRootToLeafBinary.TreeNode(1);
            tree.right.left = new SumOfRootToLeafBinary.TreeNode(0);
            tree.right.right = new SumOfRootToLeafBinary.TreeNode(1);
            
            var sum = new SumOfRootToLeafBinary();
            var result = sum.SumRootToLeaf(tree);

            var expected = 22;
            Console.WriteLine($"Sum of the binary tree is {result} expected: {expected}");
        }
    }
}