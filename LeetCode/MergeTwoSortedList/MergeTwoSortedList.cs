using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.MergeTwoSortedList
{
    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int val = 0, ListNode next = null){
            this.val = val;
            this.next = next;
      }
    }

    public class MergeTwoSortedList
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            var list = listNodeRecursive(list1, list2, new List<int>());

            ListNode listNode = new ListNode();

            for (int i = 0; i < list.Count; i++)
            {
                listNode.val = list[i];
                listNode.next = new ListNode();
            }

            return listNodeRecursive2(list1,list2);
        }

        private ListNode ListBySize(ListNode biggerNode,ListNode lessNode)
        {
            ListNode MergedNode = new ListNode();
            var nodeIndex = biggerNode;
            while(nodeIndex.next != null)
            {
                if(nodeIndex.val <= lessNode.val)
                {
                    MergedNode.val = nodeIndex.val;
                    MergedNode.next = lessNode;
                }
                else
                {
                    MergedNode.val = lessNode.val;
                    MergedNode.next = nodeIndex;
                }

                nodeIndex = nodeIndex.next;
                MergedNode = 
                lessNode = lessNode.next;
            }

            return MergedNode;
        }

        public void showListValues(ListNode listNode, string initValue = "")
        {
            if(listNode.next == null)
            {
                Console.WriteLine(initValue);
            }
            else
            {
                showListValues(listNode.next, initValue + $",{listNode.val}");
            }
        }

        private ListNode listNodeRecursive2(ListNode listNode1, ListNode listNode2)
        {
            if(listNode1 == null)
            {
                return listNode2;
            }else if(listNode2 == null)
            {
                return listNode1;
            }

            ListNode res = null;

            if(listNode1.val < listNode2.val)
            {
                res = listNode1;
                res.next = listNodeRecursive2(listNode1.next, listNode2);
            }
            else
            {
                res = listNode2;
                res.next = listNodeRecursive2(listNode1, listNode2.next);
            }

            return res;
        }

        private List<int> listNodeRecursive(ListNode listNode1,ListNode listNode2, List<int> result)
        {
            if(listNode1.next == null && listNode2.next == null)
            {
                if(listNode1.val <= listNode2.val)
                {
                    result.Add(listNode1.val);
                    result.Add(listNode2.val);
                }
                else
                {
                    result.Add(listNode2.val);
                    result.Add(listNode1.val);
                }

                return result;
            }
            else
            {
                if(listNode1.val <= listNode2.val)
                {
                    result.Add(listNode1.val);
                    return listNodeRecursive(listNode1.next, listNode2, result);
                }
                else
                {
                    result.Add(listNode2.val);
                    return listNodeRecursive(listNode1, listNode2.next, result);
                }
            }
        }

        private int lenghtNodeList(ListNode node, int size = 1)
        {
            if(node.next == null)
            {
                return size;
            }
            else
            {
                return lenghtNodeList(node.next, size + 1);
            }
        }
    }
}
