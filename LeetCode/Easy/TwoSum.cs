

namespace LeetCode.Easy
{
    public class TwoSum
    {
        public int[] TwoSum_case(int[] nums, int target)
        {
            var sortedNums = nums.Order();

            var listLessValues = NewArraySmallValueAtTarget(sortedNums.ToArray(), target);

            for (int i = 0; i < nums.Length; i++)
            {

            }
            return [];
        }

        private IEnumerable<int> NewArraySmallValueAtTarget(int[] nums, int target)
        {
            for (int i = 0; i <nums.Length; i++)
            {
                if (nums[i] > target)
                {
                    break;
                }

                yield return nums[i];
            }
        }
    }
}
