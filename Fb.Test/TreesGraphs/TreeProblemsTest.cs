using fb.TreesGraphs;
using Xunit;

namespace Fb.Test.TreesGraphs
{
    public class TreeProblemsTest
    {
        [Theory]
        [InlineData(new int[] { 2, 1, 3 }, true)]
        public void TestSomething(int[] nums, bool expectedValue)
        {
            TreeNode root = generateTree(nums);
            var treeProblems = new TreeProblems();

            var actualResult = treeProblems.IsValidBST(root);
            
            Assert.Equal(expectedValue, actualResult);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 3)]
        [InlineData(new int[] { 9, 8, 7 }, 2)]
        public void TestDiameterOfBinaryTree(int[] nums, int expectedDiameter)
        {
            TreeNode root = generateBinarySearchTree(nums);
            
            var treeProblems = new TreeProblems();

            var actualDiameter = treeProblems.DiameterOfBinaryTree(root);
            
            Assert.Equal<int>(expectedDiameter, actualDiameter);
        }

        private TreeNode generateBinarySearchTree(int[] nums)
        {
            TreeNode root = null;
            
            foreach (var n in nums)
            {
                root = insertBinarySearchTree(root, n);
            }

            return root;
        }

        private TreeNode insertBinarySearchTree(TreeNode t, int num)
        {
            if (t == null)
            {
                return new TreeNode(num);
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
    }
}