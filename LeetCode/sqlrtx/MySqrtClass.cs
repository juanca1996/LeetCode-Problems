using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.sqlrtx
{
    public class MySqrtClass
    {
        public int MySqrt(int x)
        {
            var flag = true;

            

            var minimunValue = 0;
            var previusValue = minimunValue;

            while (flag) {

                var resultPotencia = minimunValue * minimunValue;

                if (resultPotencia > x) { 
                    
                    flag = false;

                }else if(resultPotencia == x)
                {
                    flag = false;
                    previusValue = minimunValue;
                }
                else
                {
                    previusValue = minimunValue;
                    minimunValue++;
                }
            }
            
            return previusValue;
        }

        public int MySqrtImproved(int x)
        {
            var newHalf = x / 2;
            var difference = 0;
            double tolerance = 1e-10;

            do
            {
                var lastHalf = (newHalf + x / 2) / 2;
                difference = newHalf - lastHalf;
                newHalf = lastHalf;
            } while (difference > tolerance);

            return newHalf;
        }
    }
}
