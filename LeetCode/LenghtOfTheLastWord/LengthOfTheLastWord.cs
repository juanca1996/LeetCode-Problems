using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LenghtOfTheLastWord
{
    public class LengthOfTheLastWord
    {
        public int LengthOfLastWord(string s)
        {
            var arrayDataSplittedBySpace = s.Split(' ');

            var isLastOneWithNoSpace = true;
            var lengthList = arrayDataSplittedBySpace.Length - 1;

            while (isLastOneWithNoSpace)
            {
                if (!string.IsNullOrEmpty(arrayDataSplittedBySpace[lengthList]))
                {
                    isLastOneWithNoSpace = false;
                    return arrayDataSplittedBySpace[lengthList].Length;
                }
                else
                {
                    lengthList--;
                }

            }

            return arrayDataSplittedBySpace[lengthList].Length;
        }
    }
}
