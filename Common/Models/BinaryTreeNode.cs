using System.Collections.Generic;

namespace Common.Models
{
    public class BinaryTreeNode
    {
        public readonly int val;
        public BinaryTreeNode left;
        public BinaryTreeNode right;

        public BinaryTreeNode(int val)
        {
            this.val = val;
            left = null;
            right = null;
        }

        public static BinaryTreeNode CreateBinaryTree(int?[] nums)
        {
            BinaryTreeNode root = null;

            if (nums != null && nums.Length > 0)
            {
                createBinaryTree(nums, 0, ref root);
            }

            return root;
        }

        private static void createBinaryTree(int?[] nums, int index, ref BinaryTreeNode root)
        {
            if (index >= nums.Length)
            {
                return;
            }

            if (nums[index].HasValue)
            {
                root = new BinaryTreeNode(nums[index].Value);
                createBinaryTree(nums, 2 * index + 1, ref root.left);
                createBinaryTree(nums, 2 * index + 2, ref root.right);
            }
        }

        public static IList<BinaryTreeNode> CreateBinaryTreeForest(int?[][] nums)
        {
            var results = new List<BinaryTreeNode>();

            foreach (var num in nums)
            {
                results.Add(CreateBinaryTree(num));
            }

            return results;
        }
    }
}