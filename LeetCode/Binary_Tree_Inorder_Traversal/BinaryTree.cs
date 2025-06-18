using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Binary_Tree_Inorder_Traversal
{
    
    public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
    }
 
    public class BinaryTree
    {
        private IList<int> num = new List<int>();

        public IList<int> InorderTraversal(TreeNode root)
        {
            //MoveInOrder(root);
            if(root == null)
            {
                return num;
            }
            InorderTraversal(root.left);
            num.Add(root.val);
            InorderTraversal(root.right);

            return num;
        }


        public TreeNode MoveInOrderImprove(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.left == null && node.right == null)
            {
                Console.WriteLine(node.val);
                return node;
            }

            MoveInOrderImprove(node.left);

            Console.WriteLine(node.val);

            MoveInOrderImprove(node.right);

            return node;
        }
    }

    public class SameTree
    {
        private bool areSameNode = true;

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            MoveInsideTheNode(p, q);

            return areSameNode;
        }

        public TreeNode MoveInsideTheNode(TreeNode p, TreeNode q)
        {
            if(p == null && q == null)
            {
                return null;
            }
            else
            {
                if((p == null && q != null) || (p != null && q == null))
                {
                    areSameNode = false;
                    return null;
                }
            }

            if(p.val != q.val)
            {
                areSameNode = false;
            }
           
            MoveInsideTheNode(p.left, q.left);
            
            MoveInsideTheNode(p.right, q.right);

            return p;
        }

    }
}
