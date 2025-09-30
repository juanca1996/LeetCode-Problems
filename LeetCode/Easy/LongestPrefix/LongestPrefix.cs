using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy.LongestPrefix
{
    public class LongestPrefix
    {
        public string LongestCommonPrefixHarder(string[] strs)
        {
            if (strs.Length == 1)
            {
                return strs[0];
            }

            string firstValue = strs[0];

            string[] arrayFirstValue = firstValue.ToCharArray().Select(x => x.ToString()).ToArray();

            string largestWord = "";
            StringBuilder largestCommondPrefix = new StringBuilder();

            int mainCursor = 0;
            int lastestCursorState = mainCursor;
            while (mainCursor < arrayFirstValue.Length - 1)
            {
                var word = arrayFirstValue[mainCursor];
                largestCommondPrefix.Append(word);


                for (int i = 1; i < strs.Length; i++)
                {
                    var contiansWord = strs[i].Contains(largestCommondPrefix.ToString());

                    if (!contiansWord)
                    {
                        largestCommondPrefix.Clear();
                        mainCursor = lastestCursorState;
                        lastestCursorState++;
                        continue;
                    }

                    if ((i + 1) == strs.Length)
                    {
                        if (largestCommondPrefix.Length > largestWord.Length)
                        {
                            largestWord = largestCommondPrefix.ToString();
                        }
                    }
                }

                mainCursor++;
            }

            return largestWord;
        }
    }
}
