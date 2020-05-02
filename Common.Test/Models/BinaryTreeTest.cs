using Common.Models;
using Xunit;

namespace Common.Test.Models
{
    public class BinaryTreeTest
    {
        [Fact]
        public void TestCreateBinaryTree()
        {
            int?[] nums = new int?[] {1, 2, 3, 4, null, null, 5, 6};
            
            var binaryTree = BinaryTreeNode.CreateBinaryTree(nums);
            
            Assert.NotNull(binaryTree);
        }
    }
}