using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Medium.RemoveNthFromEnd
{
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


    public class RemoveNthFromEndClass
    {
        private int listNodeLenght = 0;
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null)
            {
                return null;
            }

            if (n == 1 && head.next == null)
            {
                return null;
            }
            return Recursion(head, n, 1) ?? head.next;
        }

        private ListNode Recursion(ListNode node, int n, int lenght)
        {
            if (node.next == null)
            {
                listNodeLenght = lenght;
                return node;
            }

            ListNode curren = new ListNode(node.val);
            curren.next = Recursion(node.next, n, lenght + 1);

            if ((listNodeLenght - n) == 0)
            {
                return null;
            }

            if ((listNodeLenght - n) == lenght)
            {
                curren.next = curren.next.next;
            }

            return curren;
        }
    }
}
