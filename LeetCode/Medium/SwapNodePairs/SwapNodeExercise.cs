using LeetCode.Medium.RemoveNthFromEnd;
namespace LeetCode.Medium.SwapNodePairs
{
    public class SwapNodeExercise
    {
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            return NewListNodeOrderByTwo(head,head, 0, null);
        }

        private ListNode NewListNodeOrderByTwo(ListNode currentNode,ListNode previusValue, int subleavel, ListNode newListNode)
        {
            if (currentNode == null)
            {
                if (subleavel == 0) {
                    return null;
                }
                else
                {
                    return new ListNode(previusValue.val);
                }
                
            }

            if(subleavel == 1)
            {
                newListNode = new ListNode(currentNode.val);
                newListNode.next = new ListNode(previusValue.val);
                subleavel = 0;
                newListNode.next.next = NewListNodeOrderByTwo(currentNode.next,currentNode,subleavel,newListNode.next);
            }
            else
            {
                newListNode =  NewListNodeOrderByTwo(currentNode.next, currentNode, subleavel + 1, newListNode);
            }

            return newListNode;
        }
    }
}
