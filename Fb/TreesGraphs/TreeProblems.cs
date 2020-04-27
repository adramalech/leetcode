using System;

namespace fb.TreesGraphs
{
    public class TreeNode 
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; } 
    }
    
    public class TreeProblems
    {
        public bool IsValidBST(TreeNode root) 
        {
            return validBST(root, long.MinValue, long.MaxValue);
        }
    
        private bool validBST(TreeNode root, long min, long max) 
        {
            if (root == null)
            {
                return true;
            }
            
            if (root.val > min && root.val < max)
            {
                return validBST(root.left, min, root.val) && validBST(root.right, root.val, max);
            }

            return false;
        }
        
        public int DiameterOfBinaryTree(TreeNode root) 
        {
            if (root == null)
            {
                return 0;
            }
        
            if (root.left == null && root.right == null)
            {
                return 0;
            }

            return height(root.left) + height(root.right);
        }
    
        private int height(TreeNode node)
        {
            if (node == null) 
            {
                return 0;
            }

            return 1 + Math.Max(height(node.left), height(node.right));
        }
    }
}