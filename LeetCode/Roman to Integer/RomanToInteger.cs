using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Roman_to_Integer
{
    public class RomanToInteger
    {
        private Dictionary<char, int> keyValuePairs = new Dictionary<char, int>()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        public int RomanToInt(string romanValue)
        {

            int result = 0;
            int prevValue = 0;

            for (int i = romanValue.Length - 1; i >= 0; i--)
            {
                int currentValue = keyValuePairs[romanValue[i]];

                // If the current value is less than the previous value, we subtract it (e.g., IV = 5 - 1 = 4)
                if (currentValue < prevValue)
                    result -= currentValue;
                else //otherwise we add it
                    result += currentValue;

                //update previuous value for further iteration
                prevValue = currentValue;
            }
            return result;
        }
    }
}
