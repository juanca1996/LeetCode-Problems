using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.RemoveDuplicatedValues
{
    public class ListNodeRemoveDuplace
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            if(head == null)
            {
                return null;
            }

            if(head.next == null)
            {
                return head;
            }

            return MoveToTheNextNodeAsycTest(head);
        }

        protected ListNode MoveToTheNextNodeAsyc(ListNode currentNode, int previusValue = -1000,ListNode newList = null)
        {
            if(currentNode == null)
            {
                return null;
            }

            if(previusValue == currentNode.val && currentNode.next != null)
            {
                newList = new ListNode(currentNode.next.val, MoveToTheNextNodeAsyc(currentNode.next.next, currentNode.next.val, new ListNode(currentNode.next.val)));
            }
            else
            {
                newList = new ListNode(currentNode.val, MoveToTheNextNodeAsyc(currentNode.next, currentNode.val, new ListNode(currentNode.val)));
            }
            return newList;
        }

        protected ListNode MoveToTheNextNodeAsycTest(ListNode currentNode, ListNode newList = null)
        {
            if (currentNode == null)
            {
                return null;
            }

            if(currentNode.next == null && newList.val != currentNode.val)
            {
                return new ListNode(currentNode.val);
            }
            else if(currentNode.next == null)
            {
                return null;
            }

            if(currentNode.val == currentNode.next.val)
            {
                newList = new ListNode(currentNode.next.val, MoveToTheNextNodeAsycTest(currentNode.next.next, new ListNode(currentNode.next.val)));
            }
            else
            {
                newList = new ListNode(currentNode.val, MoveToTheNextNodeAsycTest(currentNode.next, new ListNode(currentNode.val)));
            }
            return newList;
        }

    }

    public class ListNode
    {
       public int val;
       public ListNode next;
       public ListNode(int val = 0, ListNode next = null)
       {
         this.val = val;
         this.next = next;
       }
  }
}
