using System.Linq;
using Common.Models;
using Google.TreesGraphs;
using Xunit;

namespace Google.Test.TreesGraphs
{
    public class TreeProblemsTest
    {
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
        
    }
}