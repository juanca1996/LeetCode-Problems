using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Medium._3SumCloset
{
    public class threeSumClosetSolution
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int sumResult = 0;
            int lessDistance = int.MaxValue;
            int endIndexLimit = nums.Length - 1;
            int initIndexLimit = 0;

            while (initIndexLimit < nums.Length - 1)
            {
                int secondEndIndexLeft = endIndexLimit - 1;

                while(secondEndIndexLeft > initIndexLimit)
                {
                    var sumValues = nums[initIndexLimit] + nums[secondEndIndexLeft] + nums[endIndexLimit];

                    var distance = Math.Abs(target + (-1) * sumValues);

                    if(distance < lessDistance)
                    {
                        lessDistance = distance;
                        sumResult = sumValues;
                    }

                    endIndexLimit--;
                    secondEndIndexLeft = endIndexLimit - 1;
                }

                endIndexLimit = nums.Length - 1;
                initIndexLimit++;
            }

            endIndexLimit = nums.Length - 2;
            if (initIndexLimit == nums.Length - 1)
            {
                int secondEndIndexLeft = endIndexLimit - 1;
                while (secondEndIndexLeft > 0)
                {
                    var sumValues = nums[initIndexLimit] + nums[secondEndIndexLeft] + nums[endIndexLimit];

                    var distance = Math.Abs(target + (-1) * sumValues);

                    if (distance < lessDistance)
                    {
                        lessDistance = distance;
                        sumResult = sumValues;
                    }

                    endIndexLimit--;
                    secondEndIndexLeft = endIndexLimit - 1;
                }
            }


            return sumResult;
        }

        //https://leetcode.com/problems/3sum-closest/submissions/1729189469/
        //Analiza otro enfoque y es que siempre el dee atras se mueva con el primero
    
        public int ThreeSumClosestImproved(int[] nums, int target)
        {
            Array.Sort(nums);
            var intIndex = 0;
            var secondIndex = intIndex + 1;
            var thirdIndex = secondIndex + 1;
            var lastIndex = nums.Length - 1;
            int sumResult = 0;
            int lessDistance = int.MaxValue;

            if (nums.Count() < 3)
            {
                return 0;
            }

            do
            {
                while(thirdIndex != intIndex)
                {
                    var sumValues = nums[intIndex] + nums[secondIndex] + nums[thirdIndex];

                    var distance = Math.Abs(target + (-1) * sumValues);

                    if (distance < lessDistance)
                    {
                        lessDistance = distance;
                        sumResult = sumValues;
                    }

                    if (thirdIndex == lastIndex)
                    {
                        thirdIndex = -1;
                    }

                    thirdIndex++;
                }

                intIndex++;
                if (intIndex > lastIndex)
                {
                    intIndex = 0;
                }

                secondIndex = intIndex + 1;
                if (secondIndex > lastIndex)
                {
                    secondIndex = 0;
                }

                thirdIndex = secondIndex + 1;
                if (thirdIndex > lastIndex)
                {
                    thirdIndex = 0;
                }

            } while (intIndex != 0);

            return sumResult;
        }
    }
}
