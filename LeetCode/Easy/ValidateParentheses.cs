using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy
{
    public class ValidateParentheses
    {
        public bool IsValid(string s)
        {
            var isvalid = true;

            var stringArreglo = s.ToArray().Select(x => x.ToString()).ToList();

            var dictionaryCharacteres = new Dictionary<string, string>()
            {
                {"(",")" },
                {")","(" },
                {"[","]" },
                {"]","[" },
                {"{","}" },
                {"}","{" },

            };

            var rightValue = new Dictionary<string, bool>()
            {
                {"(",true },
                {"[",true },
                {"{",true },
                {")",false },
                {"]",false },
                {"}",false },
            };

            var i = 0;
            var j = stringArreglo.Count;

            if((stringArreglo.Count % 2) != 0)
            {
                return false;
            }

            if(i == j)
            {
                return isvalid = false;
            }

            while(isvalid && i != j)
            {
                var currenValueI = stringArreglo[i];
                var currenValueJ = stringArreglo[j - 1];

                var expectedResultI = dictionaryCharacteres[currenValueI];
                var expectedResultJ = dictionaryCharacteres[currenValueJ];

                var nextValueI = stringArreglo[i + 1];

                var itIsRightValue = rightValue[currenValueI];
                

                if(expectedResultI == nextValueI && itIsRightValue)
                {
                    i = i + 2;
                }else if (currenValueI == expectedResultJ && itIsRightValue)
                {
                    i++;
                    j--;
                }
                else
                {
                    isvalid = false;
                }
                
            }

            return isvalid;
        }

        public bool IsValid2(string s)
        {

        }
    }
}
