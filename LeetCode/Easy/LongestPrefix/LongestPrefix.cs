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

        public string LongestCommonPrefixEasy(string[] strs)
        {
            if (strs.Length == 1)
            {
                return strs[0];
            }

            string smallwordinthelist = strs[0];
            for (int i = 0; i < strs.Length; i++)
            {
                if (strs[i].Length < smallwordinthelist.Length)
                {
                    smallwordinthelist = strs[i];
                }
            }

            var firstValueArray = smallwordinthelist.ToArray().Select(x => x.ToString()).ToArray();

            strs = strs.OrderByDescending(x => x.Length).ToArray();
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < firstValueArray.Length; i++)
            {
                for (int j = 0; j < strs.Length; j++)
                {
                    var arraySubString = strs[j].ToArray();
                    if (arraySubString[i].ToString() != firstValueArray[i])
                    {
                        if (builder.Length == 0)
                        {
                            return "";
                        }
                        else
                        {
                            return builder.ToString();
                        }

                    }
                    else if ((j + 1) == strs.Length)
                    {
                        builder.Append(firstValueArray[i]);
                    }

                }
            }

            return builder.ToString();
        }
    }
}
