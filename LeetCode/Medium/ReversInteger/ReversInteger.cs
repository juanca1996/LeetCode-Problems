using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Medium.ReversInteger
{
    public static class ReversInteger
    {
        public static int Reverse(int x)
        {
            if (x > Int32.MaxValue || x < Int32.MinValue || x == 0)
            {
                return 0;
            }
            else
            {
                var charInt = x.ToString().ToArray();
                StringBuilder stringBuilder = new StringBuilder();
                var allceroleftCompleted = false;
                var sign = "";
                var min = 0;

                if (charInt[0].ToString() == "-")
                {
                    stringBuilder.Append("-");
                    min = +1;
                }

                for (var i = charInt.Length - 1; i  >= (min); i--)
                {
                    var value = charInt[i];
                    if((int.Parse(value.ToString()) == 0))
                    {
                        if (allceroleftCompleted)
                        {
                            stringBuilder.Append(value.ToString());
                        }
                    }
                    else
                    {
                        allceroleftCompleted = true;
                        stringBuilder.Append(value.ToString());
                    }
                }

                try
                {
                    return int.Parse(stringBuilder.ToString());
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }
    }
}
