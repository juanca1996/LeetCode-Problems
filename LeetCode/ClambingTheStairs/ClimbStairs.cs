using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.ClambingTheStairs
{
    public class ClimbStairs
    {
        public int ClimbStairsCode(int n)
        {
            var isPart = n % 2 == 0;

            var divResult = n / 2;

            var result = n == 1 ? 1 : 2;

            var sumOne = 2;

            for (int i = 1; i < divResult; i++)
            {
                result = (result * result);
                sumOne = sumOne + 2;
            }

            result = result + sumOne;

            if (isPart) {
                result = result - 1;
            }

            return result;
        }
    }
}
