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
    }
}