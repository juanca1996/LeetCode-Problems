using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Medium.LongestSubstringWithNoRepetingChara
{
    public class LongestSubstring
    {
        private int longestSubstring = 0;



        public int LengthOfLongestSubstring(string s)
        {
            var charSet = new HashSet<char>();
            int left = 0, maxLength = 0;

            for (int right = 0; right < s.Length; right++)
            {
                while (charSet.Contains(s[right]))
                {
                    charSet.Remove(s[left++]);
                }

                charSet.Add(s[right]);
                maxLength = Math.Max(maxLength, right - left + 1);
            }

            return maxLength;
        }

        public int LenghOfLongestSubstringSecondApproach(string s)
        {
            var arrayOfCharacters = s.ToLower().ToArray();

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < arrayOfCharacters.Length; i++)
            {
                string currentValueStringBuilder = new string(stringBuilder.ToString());

                if (currentValueStringBuilder.Contains(arrayOfCharacters[i].ToString()))
                {
                    stringBuilder.Clear();
                    stringBuilder.Append(arrayOfCharacters[i].ToString());
                }
                else
                {
                    stringBuilder.Append(arrayOfCharacters[i].ToString());
                }

                if (stringBuilder.Length > longestSubstring)
                {
                    longestSubstring = stringBuilder.Length;
                }

            }

            return longestSubstring;
        }
    }
}
