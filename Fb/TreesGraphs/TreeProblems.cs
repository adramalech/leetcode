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
            return validate(root, long.MinValue, long.MaxValue);
        }
    
        private bool validate(TreeNode root, long min, long max) 
        {
            if (root == null)
            {
                return true;
            }
            
            if (root.val > min && root.val < max)
            {
                return validate(root.left, min, root.val) && validate(root.right, root.val, max);
            }

            return false;
        }
    }
}