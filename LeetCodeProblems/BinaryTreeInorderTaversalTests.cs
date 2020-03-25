using System;
using System.Collections.Generic;

namespace LeetCodeChallenges
{
    public class BinaryTreeInorderTraversalTests
    {
        public static void Test()
        {
            var tree = new BinaryTreeInorderTraversal.TreeNode(1);
            tree.right = new BinaryTreeInorderTraversal.TreeNode(2);
            tree.right.left = new BinaryTreeInorderTraversal.TreeNode(3);
            tree.right.right = new BinaryTreeInorderTraversal.TreeNode(4);
            tree.right.right.left = new BinaryTreeInorderTraversal.TreeNode(5);
            tree.right.right.right = new BinaryTreeInorderTraversal.TreeNode(6);

            var traversal = new BinaryTreeInorderTraversal();
            var result = traversal.InorderTraversal(tree);

            foreach (var i in result)
            {
                Console.Write(i);
                Console.Write(", ");
            }

            Console.WriteLine();
            Console.WriteLine("Expected 1, 3, 2, 5, 4, 6");
        }
    }
}