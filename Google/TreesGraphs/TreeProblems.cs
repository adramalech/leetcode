using Common.Models;

namespace Google.TreesGraphs
{
    public class TreeProblems
    {
        // O(n)
        public int CountNodes(BinaryTreeNode root) 
        {
            if (root == null) 
            {
                return 0;
            }
        
            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }
    }
}