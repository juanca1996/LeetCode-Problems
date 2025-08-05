using LeetCode.Medium.RemoveNthFromEnd;

namespace LeetCode.Easy.MergeTwoSortedLists
{
    public class MergedTwoSortedList
    {
        public ListNode MergeTwolist(ListNode List1, ListNode list2)
        {
            if(List1 != null && list2 != null)
            {
                return JoinList(List1, list2, new ListNode());

            }else if (List1 == null && list2 != null)
            {
                return list2;
            }
            else
            {
                return List1;
            }
        }

        public ListNode JoinList(ListNode lis1, ListNode lis2, ListNode newList)
        {
            if(lis1 == null || lis2 == null)
            {
                if (lis1 == null && lis2 != null)
                {
                    return lis2;
                }
                else
                {
                    return lis1;
                }
            }

            if (lis1.val <= lis2.val) {

                newList = new ListNode(lis1.val);
                newList.next = JoinList(lis1.next, lis2, newList.next);
            }
            else
            {

                newList = new ListNode(lis2.val);
                newList.next = JoinList(lis1,lis2.next, newList.next);
            }

            return newList;
        }
    }
}
