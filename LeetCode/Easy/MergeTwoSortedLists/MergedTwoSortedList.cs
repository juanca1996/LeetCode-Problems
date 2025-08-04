using LeetCode.Medium.RemoveNthFromEnd;

namespace LeetCode.Easy.MergeTwoSortedLists
{
    public class MergedTwoSortedList
    {
        public ListNode MergeTwolist(ListNode List1, ListNode list2)
        {
            return JoinList(List1 , list2, new ListNode());
        }

        public ListNode JoinList(ListNode lis1, ListNode lis2, ListNode newList)
        {
            if(lis1 == null || lis2 == null)
            {
                return null;
                
            }

            if (lis1.val <= lis2.val) {
                newList = new ListNode(lis1.val);
                if(lis1.next == null)
                {
                    newList.next = lis2;
                    newList.next = JoinList(lis1, lis2.next, newList);
                }
                else
                {
                    newList.next = lis1;
                    newList.next = JoinList(lis1.next, lis2, newList);
                }
            }
            else
            {
                newList = new ListNode(lis2.val);
                if(lis2.next == null)
                {
                    newList.next = lis1;
                    newList.next = JoinList(lis1.next, lis2, newList);
                }
                else
                {
                    newList.next = lis2;
                    newList.next = JoinList(lis1, lis2.next, newList);
                }
            }

            return newList;
        }
    }
}
