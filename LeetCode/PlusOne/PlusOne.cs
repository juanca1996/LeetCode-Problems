using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.PlusOne
{
    public class PlusOne
    {
        public int[] PlusOneMatch(int[] digits)
        {
            var lastDigit = digits[digits.Length - 1];

            if (lastDigit < 8)
            {
                digits[digits.Length - 1] = lastDigit + 1;
                return digits;
            }
            else
            {
                var newArray = new int[digits.Length + 1];
                foreach (var (digit,index) in digits.Select((x,y) => (x,y)))
                {
                    newArray[index] = digit;
                }

                var SumlastDigit = digits[digits.Length - 1] + 1;

                var toCharInt = SumlastDigit.ToString().ToCharArray();

                newArray[newArray.Length - 2] = int.Parse(toCharInt[0].ToString());
                newArray[newArray.Length - 1] = int.Parse(toCharInt[1].ToString());

                return newArray;
            }
        }
    }
}
