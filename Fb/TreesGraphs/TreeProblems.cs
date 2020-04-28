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

        public void Flatten(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            if (root.left == null && root.right == null)
            {
                return;
            }

            if (root.left != null)
            {
                Flatten(root.left);

                var tmp = root.right;
                root.right = root.left;
                root.left = null;

                var current = root.right;
                
                while (current.right != null)
                {
                    current = current.right;
                }

                current.right = tmp;
            }

            Flatten(root.right);
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode a, TreeNode b)
        {
            if (root == null)
            {
                return null;
            }

            if (root.val == a.val || root.val == b.val)
            {
                return root;
            }


            TreeNode left = null;
            TreeNode right = null;

            lowestAncestor(root.left, a, b, left);
            lowestAncestor(root.right, a, b, right);
            
            if (left != null && right != null)
            {
                return root;
            }

            if (left != null)
            {
                return left;
            }

            if (right != null)
            {
                return right;
            }
            
            return root;
        }

        private void lowestAncestor(TreeNode root, TreeNode a, TreeNode b, TreeNode current)
        {
            if (root == null)
            {
                return;
            }

            if (root.val == a.val || root.val == b.val)
            {
                current = root;
                return;
            }

            lowestAncestor(root.left, a, b, current);
            lowestAncestor(root.right, a, b, current);
        }
    }
}