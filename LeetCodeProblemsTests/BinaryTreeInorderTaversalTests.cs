using System;
using System.Collections.Generic;
using NUnit.Framework;
using LeetCodeChallenges;

namespace LeetCodeProblemsTests
{
    [TestFixture]
    public class BinaryTreeInorderTraversalTests
    {
        [Test]
        public void Test()
        {
            var tree = new BinaryTreeInorderTraversal.TreeNode(1);
            tree.right = new BinaryTreeInorderTraversal.TreeNode(2);
            tree.right.left = new BinaryTreeInorderTraversal.TreeNode(3);
            tree.right.right = new BinaryTreeInorderTraversal.TreeNode(4);
            tree.right.right.left = new BinaryTreeInorderTraversal.TreeNode(5);
            tree.right.right.right = new BinaryTreeInorderTraversal.TreeNode(6);

            var traversal = new BinaryTreeInorderTraversal();
            var result = traversal.InorderTraversal(tree);

            var stringBuilder = new System.Text.StringBuilder();
            foreach (var i in result)
            {
                stringBuilder.Append($"{i}, ");
            }

            Assert.AreEqual("1, 3, 2, 5, 4, 6, ", stringBuilder.ToString());
        }
    }
}