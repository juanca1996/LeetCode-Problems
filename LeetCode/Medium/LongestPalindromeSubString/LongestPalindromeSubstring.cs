using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Medium.LongestPalindromeSubString
{
    public class LongestPalindromeSubstring
    {
        private string longestSubString = "";

        public string LongestPalindrome(string s)
        {


            return "";
        }

        public string LongestPalindromeUnRefactor(string s)
        {
            var arrayString = s.ToArray();

            if(s == string.Join("",arrayString.Reverse()))
            {
                return s;
            }
            else
            {
                StringBuilder substringBuilder = new StringBuilder();

                for (var i = 0; i < arrayString.Length; i++)
                {
                    substringBuilder.Append(arrayString[i]);

                    for (var j = i + 1; j < arrayString.Length; j++)
                    {
                        substringBuilder.Append(arrayString[j]);

                        var arraySubStringReverse = substringBuilder.ToString().ToArray().Reverse();

                        var stringReverse = string.Join("", arraySubStringReverse);

                        if(substringBuilder.ToString() == stringReverse && longestSubString.Length < substringBuilder.Length)
                        {
                            longestSubString = substringBuilder.ToString();
                        }
                    }

                    substringBuilder.Clear();
                }

                if(longestSubString == string.Empty)
                {
                    longestSubString = arrayString[0].ToString();
                }
            }

            return longestSubString;
        }
    }
}
