using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.SearchInsertPosition
{
    public class SearchInsertPosition
    {
        public int SearchInsert(int[] nums, int target)
        {
            // key is value, value is position index
            var numsDictionary = new Dictionary<int, int>();

            foreach (var (item, index) in nums.Select((value,indexNum) => (value,indexNum)))
            {
                numsDictionary.Add(item, index);
            }

            var exist = numsDictionary.TryGetValue(target, out int position);

            if (exist) {
                return position;
            }
            else
            {
                for (var i = 0; i < nums.Length; i++)
                {
                    if (target < nums[i])
                    {
                        return i;
                    }
                    else if(i + 1 == nums.Length)
                    {
                        return i + 1;
                    }
                }
            }

            return 0;
        }
    }
}
