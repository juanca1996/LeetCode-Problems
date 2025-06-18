using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCode.Binary_Tree_Inorder_Traversal;

namespace LeetCode.ConvertSortedArrayInBinaryTree
{
    public class ConverteSortedArrayInBinaryTree
    {
        private TreeNode root;
        private int middValue = 0;

        public TreeNode SortedArrayToBST(int[] nums)
        {
            if(nums.Length == 0)
            {
                return null;
            }
            else
            {
                var middlePossition = nums.Length / 2;
                middValue = nums[middlePossition];

                root = new TreeNode(middValue);
                //lef site
                root = createTree(root, nums, 0);

                // right site
                root = createTree(root, nums, middlePossition + 1);
            }

            return root;
        }

        private TreeNode createTree(TreeNode node, int[] num, int index)
        {
            
            if (index == num.Length || num[index] == middValue)
            {
                return node;
            }

            if (num[index] < node.val)
            {
                node.left = createTree(new TreeNode(num[index]), num, index + 1);
            }
            else
            {
                node.right = createTree(new TreeNode(num[index]), num, index + 1);
            }

            return node;
        }
    }
}
