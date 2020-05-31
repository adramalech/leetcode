using System.Collections.Generic;
using System.Linq;
using Common.Models;
using Problems.TreesGraphs;
using Xunit;

namespace Problems.Test.TreesGraphs
{
    public class TreeProblemsTest
    {
        [Theory]
        [InlineData(new int[] { 2, 1, 3 }, true)]
        public void TestSomething(int[] nums, bool expectedValue)
        {
            BinaryTreeNode root = generateBinarySearchTree(nums);
            var treeProblems = new TreeProblems();

            var actualResult = treeProblems.IsValidBST(root);

            Assert.Equal(expectedValue, actualResult);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 3)]
        [InlineData(new int[] { 9, 8, 7 }, 2)]
        public void TestDiameterOfBinaryTree(int[] nums, int expectedDiameter)
        {
            BinaryTreeNode root = generateBinarySearchTree(nums);

            var treeProblems = new TreeProblems();

            var actualDiameter = treeProblems.DiameterOfBinaryTree(root);

            Assert.Equal<int>(expectedDiameter, actualDiameter);
        }

        private BinaryTreeNode generateBinarySearchTree(int[] nums)
        {
            BinaryTreeNode root = null;

            foreach (var n in nums)
            {
                root = insertBinarySearchTree(root, n);
            }

            return root;
        }

        private BinaryTreeNode insertBinarySearchTree(BinaryTreeNode t, int num)
        {
            if (t == null)
            {
                return new BinaryTreeNode(num);
            }

            if (num < t.val)
            {
                t.left = insertBinarySearchTree(t.left, num);
            }
            else
            {
                t.right = insertBinarySearchTree(t.right, num);
            }

            return t;
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6}, 6)]
        public void TestCountNodes(int[] nums, int expectedCount)
        {
            int?[] arr = nums.Cast<int?>().ToArray();

            var treeProblems = new TreeProblems();
            var root = BinaryTreeNode.CreateBinaryTree(arr);

            var actualCount = treeProblems.CountNodes(root);

            Assert.Equal<int>(expectedCount, actualCount);
        }

        [Fact]
        public void TestDelNodesEasy()
        {
            var root = BinaryTreeNode.CreateBinaryTree(new int?[] { 1, 2, 3, 4, 5, 6, 7 });
            var to_delete = new int[] { 3, 5 };

            var expectedForest = BinaryTreeNode.CreateBinaryTreeForest(new int?[3][] { new int?[1] { 6 }, new int?[1] { 7 }, new int?[4] { 1, 2, null, 4 } });

            var treeProblems = new TreeProblems();

            var actualForest = treeProblems.DelNodes(root, to_delete);

            Assert.Equal<int>(expectedForest.Count, actualForest.Count);
        }

        [Fact]
        public void TestDelNodesParentAndChild()
        {
            var root = BinaryTreeNode.CreateBinaryTree(new int?[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            var to_delete = new int[] { 2, 5 };

            var expectedForest = BinaryTreeNode.CreateBinaryTreeForest(new int?[2][] { new int?[3] { 4, 8, 9 }, new int?[5] { 1, null, 3, 6, 7 } });

            var treeProblems = new TreeProblems();

            var actualForest = treeProblems.DelNodes(root, to_delete);

            Assert.Equal<int>(expectedForest.Count, actualForest.Count);
        }
    }
}