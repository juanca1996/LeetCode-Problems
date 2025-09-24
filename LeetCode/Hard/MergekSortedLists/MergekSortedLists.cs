using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Hard.MergekSortedLists
{
    public class ListNode
    {
        public int val { get; set; }

        public ListNode next { get; set; }

        public ListNode(int val, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class MergekSortedLists
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            //Sorted the list by the head of the node
            var listNodeWithValues = new List<int>();

            for (int i = 0; i < lists.Length; i++)
            {
                GetNodelist(lists[i], listNodeWithValues);
            }

            listNodeWithValues.Sort();


            ListNode sortedListNode = CreateMergedNode(null, listNodeWithValues.Count, 0, listNodeWithValues);


            return sortedListNode;
        }

        private List<int> GetNodelist(ListNode node, List<int> listNode)
        {
            if (node == null)
            {
                return listNode;
            }

            listNode.Add(node.val);
            return GetNodelist(node.next, listNode);
        }

        private ListNode CreateMergedNode(ListNode node, int limit, int index, List<int> sortedList)
        {
            if (index == limit)
            {
                return null;
            }

            node = new ListNode(sortedList[index]);

            node.next = CreateMergedNode(node.next, limit, index + 1, sortedList);

            return node;
        }
    }
}
