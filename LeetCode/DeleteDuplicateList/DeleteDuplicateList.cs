using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DeleteDuplicateList
{
    public class DeleteDuplicateList
    {
        public int RemoveDuplicates(int[] nums)
        {
            Dictionary<int,int> listValue = new Dictionary<int,int>();

            for (int i = 0; i < nums.Length; i++)
            {
                listValue.TryAdd(nums[i], nums[i]);
            }

            return listValue.Count();
        }
    }
}
