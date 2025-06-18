using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCode.Binary_Tree_Inorder_Traversal;

namespace LeetCode.BalanceBinaryTree
{
    public class BalancedBinaryTree
    {
        public bool IsBalanced(TreeNode root)
        {
            if(root == null || (root.left == null && root.right != null) || (root.left != null && root.right == null))
            {
                return true;
            }
            else
            {
                var lefNode = CalculateLeavelPath(root.left);
                var rightNode = CalculateLeavelPath(root.right);

                var difference = lefNode - rightNode;
            }

            return true;
        }

        private int CalculateLeavelPath(TreeNode root)
        {
            if(root == null)
            {
                return 0;
            }

            if (root.left != null)
            {
                root = root.left;
            }
            else if (root.right != null) { 
                root = root.right;
            }

            return 1 + CalculateLeavelPath(root);
        }

        private void CalculateLeavelGood(TreeNode node, int left, int right)
        {
            if(node == null)
            {
                return;
            }
            CalculateLeavelGood(node.left, 0, 0);
            Console.WriteLine(node.val);
            CalculateLeavelGood(node.right, 0, 0);
        }
    }
}
