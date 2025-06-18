using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Palindrome
{
    public class PalindromeFacade
    {
        public bool IsPalindrome(int x)
        {
            var arrayValue = ($"{x}").ToList();

            var min = 0; var max = arrayValue.Count - 1;


            var isPalindrome = true;

            while (isPalindrome && min < arrayValue.Count && max >= 0)
            {
                if (!(arrayValue[min].Equals(arrayValue[max])))
                {
                    var valie = arrayValue[min];
                    isPalindrome = false;
                }

                min++;
                max--;
            }

            return isPalindrome;
        }

        public bool IsPalindromeRefactore(int x)
        {
            var stringInt = x.ToString();
            var stringIntReverse = x.ToString().ToCharArray().Reverse();

            if(String.Concat(stringIntReverse) != stringInt)
            {
                return false;
            }

            return true;
        }
    }
}
