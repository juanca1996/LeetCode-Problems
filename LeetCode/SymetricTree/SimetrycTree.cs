using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using LeetCode.Binary_Tree_Inorder_Traversal;

namespace LeetCode.SymetricTree
{
    public class SimetrycTree
    {
        private bool isSymetric = true;

        public bool IsSymmetric(TreeNode root)
        {
            if((root.left == null && root.right != null) || (root.left != null && root.right == null))
            {
                isSymetric = false;   
            }else if(root.left == null && root.right == null)
            {
                isSymetric = true;
            }
            else
            {
                EvaluateSymetryForLevel(root.left, root.right);
            }

            return isSymetric;
        }


        public bool IsSymetrycRight(TreeNode root)
        {
            if((root.left == null && root.right != null) || (root.left != null && root.right == null))
            {
                isSymetric = false;
            }
            else
            {
                EvaluateSymetricRightValue(root.left, root.right);
            }

            return isSymetric;
        }

        //This is the correct value
        private void EvaluateSymetricRightValue(TreeNode left, TreeNode right)
        {
            if (left == null || right == null)
            {
                return;
            }else if((left == null && right != null) || (left != null && right == null))
            {
                isSymetric = false;
                return;
            }else if ((left.left == null && right.right != null) || (left.left != null && right.right == null) || (left.right == null && right.left != null) || (left.right != null && right.left == null))
            {
                isSymetric = false;
                return;
            }
            else if(left.left == null && left.right == null && right.left == null && right.right == null)
            {
                if (left.val != right.val)
                {
                    isSymetric = false;
                }
                return;
            }

            if (left.val != right.val)
            {
                isSymetric = false;
            }

            if (isSymetric)
            {
                EvaluateSymetricRightValue(left.left, right.right);
                EvaluateSymetricRightValue(left.right, right.left);
            }
        }


        //This is the firts step
        private TreeNode EvaluateSymetryc(TreeNode leftNode, TreeNode rightNode)
        {

            if (leftNode == null && rightNode == null)
            {
                return null;
            }else if((leftNode == null && rightNode != null) || (leftNode != null && rightNode == null))
            {
                isSymetric = false;
            }

            if(leftNode.val != rightNode.val)
            {
                isSymetric = false;
            }

            if(isSymetric)
            {
                EvaluateSymetryc(leftNode.left, rightNode.left);
                EvaluateSymetryc(leftNode.right, rightNode.right);
            }

            return null;
        }

        private TreeNode EvaluateSymetryForLevel(TreeNode treeNodeLeft,TreeNode treeNodeRigth)
        {
            if(treeNodeLeft == null && treeNodeRigth == null)
            {
                return null;
            }else if ((treeNodeLeft.left == null && treeNodeRigth.right != null) || (treeNodeLeft.left != null && treeNodeRigth.right == null))
            {
                isSymetric = false;
            }
            else
            {
                if(treeNodeLeft.val != treeNodeRigth.val)
                {
                    isSymetric = false;
                }
            }

            if (isSymetric)
            {
                if(SameValueLeavel(treeNodeLeft.left, treeNodeLeft.right) && SameValueLeavel(treeNodeRigth.right, treeNodeLeft.right))
                {
                    EvaluateSymetryForLevel(treeNodeLeft.left, treeNodeRigth.left);
                    EvaluateSymetryForLevel(treeNodeLeft.right, treeNodeRigth.right);
                }
            }
            else
            {
                isSymetric = false;
            }

            return null;
        }

        private bool SameValueLeavel(TreeNode left, TreeNode right)
        {
            if(left == null && right == null)
            {
                return true;
            }

           if(left.left == right.left)
           {
                if (left.right == right.right)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
