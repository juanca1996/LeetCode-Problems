using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.CommonLongestWord
{
    public class LongestCommonPrefix
    {
        public string LongestPrefix(string[] wordChain)
        {
            var initValue = wordChain[0].ToLower().ToCharArray();

            string[] largestWord = new string[initValue.Length];

            for (int i = 1; i < wordChain.Length; i++)
            {
                var nextWord = wordChain[i].ToLower().ToCharArray();

                if(i <= nextWord.Length)
                {
                    var valueWordComparation = initValue[(i - 1)];
                    var valueCurrenWord = nextWord[(i - 1)];

                    if (valueWordComparation.Equals(valueCurrenWord))
                    {
                        if (largestWord[(i-1)] == null)
                        {
                            largestWord[(i-1)] = valueWordComparation.ToString();
                        }
                    }

                }
            }
            return string.Join("",largestWord);

        }
    }
}
