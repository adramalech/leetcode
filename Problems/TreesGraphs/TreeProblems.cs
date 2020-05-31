using System;
using System.Collections.Generic;
using Common.Models;

namespace Problems.TreesGraphs
{
    public class TreeProblems
    {
        public bool IsValidBST(BinaryTreeNode root)
        {
            return validBST(root, long.MinValue, long.MaxValue);
        }

        private bool validBST(BinaryTreeNode root, long min, long max)
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

        public int DiameterOfBinaryTree(BinaryTreeNode root)
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

        private int height(BinaryTreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Max(height(node.left), height(node.right));
        }

        public void Flatten(BinaryTreeNode root)
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

        public BinaryTreeNode LowestCommonAncestor(BinaryTreeNode root, BinaryTreeNode a, BinaryTreeNode b)
        {
            if (root == null)
            {
                return null;
            }

            if (root.val == a.val || root.val == b.val)
            {
                return root;
            }


            BinaryTreeNode left = null;
            BinaryTreeNode right = null;

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

        private void lowestAncestor(BinaryTreeNode root, BinaryTreeNode a, BinaryTreeNode b, BinaryTreeNode current)
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

        // O(n)
        public int CountNodes(BinaryTreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }

        public IList<BinaryTreeNode> DelNodes(BinaryTreeNode root, int[] to_delete)
        {
            if (to_delete == null || to_delete.Length < 1)
            {
                return new List<BinaryTreeNode>() { root } ;
            }

            if (root == null)
            {
                return new List<BinaryTreeNode>();
            }

            var results = new List<BinaryTreeNode>();

            root = deleteNodes(root, to_delete, results);

            if (root != null)
            {
                results.Add(root);
            }

            return results;
        }

        private BinaryTreeNode deleteNodes(BinaryTreeNode root, IList<int> deleteNums, List<BinaryTreeNode> results)
        {
            if (root == null)
            {
                return null;
            }

            if (deleteNums.Contains(root.val))
            {
                root.left = deleteNodes(root.left, deleteNums, results);
                root.right = deleteNodes(root.right, deleteNums, results);

                if (root.left != null)
                {
                    results.Add(root.left);
                }

                if (root.right != null)
                {
                    results.Add(root.right);
                }

                return null;
            }

            root.left = deleteNodes(root.left, deleteNums, results);
            root.right = deleteNodes(root.right, deleteNums, results);

            return root;
        }
    }
}