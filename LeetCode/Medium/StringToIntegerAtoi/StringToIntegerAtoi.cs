using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Medium.StringToIntegerAtoi
{
    public class StringToIntegerAtoi
    {
        public int MyAtoi(string s)
        {
            s = s.Trim();

            StringBuilder sb = new StringBuilder();

            var start = 0;

            var arrayString = s.ToArray();

            if(arrayString.Length == 0)
            {
                return 0;
            }

            if (arrayString[0] == '-' || arrayString[0] == '+')
            {
                sb.Append(arrayString[0]);
                start = 1;
            }

            bool noMoreCeroLeft = false;

            for (int i = start; i < arrayString.Length; i++)
            {
                var intValue = characterToInt(arrayString[i].ToString());

                if (intValue == -1)
                {
                    i = arrayString.Length + 1;
                    if(start == i)
                    {
                        sb.Clear();
                    }
                }

                if(noMoreCeroLeft && i < arrayString.Length)
                {
                   sb.Append(intValue.ToString());
                }
                else
                {
                    if(intValue != 0 && i < arrayString.Length)
                    {
                        sb.Append(intValue.ToString());
                        noMoreCeroLeft = true;
                    }
                }

                
            }

            if(sb.Length == 0)
            {
                return 0;
            }

            return rouding(sb.ToString(), start == 1 ? sb[0] : '+');
        }

        private int characterToInt(string value)
        {
            try
            {
                return Int32.Parse(value);
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        private int rouding(string realValue, char sign)
        {
            try
            {
                if(realValue == sign.ToString())
                {
                    return 0;
                }

                return Int32.Parse(realValue);

            }catch(Exception e)
            {

                
                if(sign == '-')
                {
                    return Int32.MinValue;
                }
                else
                {
                    return Int32.MaxValue;
                }   
                
            }
        }

        public int MyAtoiFastSolution(string s)
        {
            int i = 0, sign = 1, result = 0;
            int n = s.Length;
            while (i < n && s[i] == ' ') i++;
            if (i < n && (s[i] == '+' || s[i] == '-'))
            {
                sign = (s[i] == '-') ? -1 : 1;
                i++;
            }
            while (i < n && char.IsDigit(s[i]))
            {
                int digit = s[i] - '0';
                if (result > (int.MaxValue - digit) / 10)
                {
                    return (sign == 1) ? int.MaxValue : int.MinValue;
                }
                result = result * 10 + digit;
                i++;
            }
            return result * sign;
        }
    }
}
