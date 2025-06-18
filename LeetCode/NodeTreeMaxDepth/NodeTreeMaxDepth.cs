using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCode.Binary_Tree_Inorder_Traversal;

namespace LeetCode.NodeTreeMaxDepth
{
    public class NodeTreeMaxDepth
    {

        private int maxValue = 0;
        private int rootValue = 0;

        public int MaxDepth(TreeNode root)
        {
            if(root == null)
            {
                return maxValue;
            }
            else
            {
                root.val = 10000;
                rootValue = root.val;
                MoveThroughTree(root, 0);
                return maxValue;
            }
            
        }

        private void MoveThroughTree(TreeNode startNodeCount, int countNodeRecursion)
        {
            if(startNodeCount == null)
            {
                if(countNodeRecursion > maxValue)
                {
                    maxValue = countNodeRecursion;
                }
                
                return;
            }
            else
            {
                countNodeRecursion = countNodeRecursion + 1;
            }

            MoveThroughTree(startNodeCount.left,countNodeRecursion);

            if(startNodeCount.val == rootValue)
            {
                countNodeRecursion = 1;
            }

            MoveThroughTree(startNodeCount.right, countNodeRecursion);
        }


    }
}
