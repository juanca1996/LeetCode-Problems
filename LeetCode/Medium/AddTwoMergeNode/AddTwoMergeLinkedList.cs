using LeetCode.MergeTwoSortedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Medium.AddTwoMergeNode
{
    public class AddTwoMergeLinkedList
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var lis1ValueString = GetListNodeValue(l1);
            var listValueString2 = GetListNodeValue(l2);

            var list1string = lis1ValueString.ToArray().Select(x => x.ToString());
            var list2string = listValueString2.ToArray().Select(x => x.ToString());

            if(list1string.Count() >= list2string.Count())
            {
                return SumNodeList(list1string.ToArray(), list2string.ToArray(), 0, null, 0);
            }
            else
            {
                return SumNodeList(list2string.ToArray(), list1string.ToArray(), 0, null, 0);
            }
        }

        public ListNode secondApproach(ListNode l1, ListNode l2)
        {
            var lis1ValueString = GetListNodeValue(l1);
            var listValueString2 = GetListNodeValue(l2);

            var l1Long = long.Parse(lis1ValueString);
            var l2Long = long.Parse(listValueString2);

            var sum = l1Long + l2Long;

            var result = sum.ToString().ToCharArray().Reverse();

            return AddToNode(null, result.ToArray(), 0);
        }

        private ListNode SumNodeList(string[] hightList, string[] lessList, int index, ListNode root, int residuo)
        {
            if(hightList.Count() == index)
            {
                if(residuo == 1)
                {
                    return new ListNode(residuo);
                }
                return root;
            }

            var valueIndexList1 = int.Parse(hightList[index]);
            var valueIndexList2 = 0;

            if(!(index >= lessList.Count()))
            {
                valueIndexList2 = int.Parse(lessList[index]);
            }

            var sumTwoIndexValue = valueIndexList1 + valueIndexList2 + residuo;
            if(sumTwoIndexValue > 9)
            {
                var arraySum = sumTwoIndexValue.ToString().ToCharArray();
                var valueNumber = int.Parse(arraySum.GetValue(arraySum.Count() - 1).ToString());
                return new ListNode(valueNumber, SumNodeList(hightList, lessList,index + 1,null, 1));
            }
            else
            {
                return new ListNode(sumTwoIndexValue, SumNodeList(hightList, lessList, index + 1, null, 0));
            }
        }

        private string GetListNodeValue(ListNode root)
        {
            if (root == null)
            {
                return "";
            }

            return $"{root.val}" + GetListNodeValue(root.next); 
        }

        private ListNode AddToNode(ListNode root, char[] list, int index)
        {
            if(list.Count() == index)
            {
                return null;
            }

            return new ListNode(int.Parse(list[index].ToString()), AddToNode(null, list, index + 1));
        }
    }
}
