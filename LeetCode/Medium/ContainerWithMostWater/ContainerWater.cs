using System;

namespace LeetCode.Medium.ContainerWithMostWater
{
    public class ContainerWater
    {
        public int MaxArea(int[] height) {

            if(height.Length == 0)
            {
                return 0;
            }

            var maxValue = 0;

            //this works like i
            var indexValueRight = height.Length;
            //this works like f
            var indexLeftValue = 1;

            var a1 = 0;
            var a2 = 0;

            while(indexValueRight != indexLeftValue)
            {
                a1 = height[indexLeftValue - 1];
                a2 = height[indexValueRight - 1];

                var baseValue = indexValueRight - indexLeftValue;
                var lessHeightValue = 0;

                if (a2 <= a1)
                {
                    lessHeightValue = a2;
                    indexValueRight--;

                }
                else
                {
                    lessHeightValue = a1;
                    indexLeftValue++;
                }

                var areaOfContainer = baseValue * lessHeightValue;

                maxValue = areaOfContainer > maxValue ? areaOfContainer : maxValue;
            }

            return maxValue;
        }
    }
}