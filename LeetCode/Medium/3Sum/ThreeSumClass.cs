using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Medium._3Sum
{
    public class ThreeSumClass
    {
        // this solution contains an error cause it need to go from deep to top not from both sides 
        public Dictionary<int, IList<int>> dictionary = new Dictionary<int, IList<int>>();
        public Dictionary<string, IList<int>> dictionaryValuesAlreadyInTheList = new Dictionary<string, IList<int>>();

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> sumList = new List<IList<int>>();

            var sortedList = nums.OrderBy(x => x).ToArray();

            var possitionValue = sortedList.Select((x, i) => new { value = x, index = i }).ToList();

            foreach (var item in possitionValue) {
                var valueExist = dictionary.TryGetValue(item.value, out var valueIndex);
                if (valueExist)
                {
                    var newList = valueIndex.ToList();
                    newList?.Add(item.index);
                    dictionary[item.value] = newList.OrderBy(x => x).ToArray();
                }
                else
                {
                    dictionary.TryAdd(item.value, new int[] {item.index});
                }
            }

            var iIndex = 0;
            var jIndex = sortedList.Length - 1;
            var kIndex = -30000;
            var vI = sortedList[iIndex];
            var vj = sortedList[jIndex];
            var vk = 0;
            var directionDecretion = "right";

            //the equation is v(k) = 'V(I) + 'V(J) in otherWords V(k) = (-1)(V(i) + (-1)(V(j)))

            while (jIndex != iIndex)
            {
                vk = ((-1 * vI) + (-1 * vj));

                var existInDictionary = dictionary.ContainsKey(vk);
                if (existInDictionary)
                {
                    var positions = dictionary[vk];

                    if(positions.Count == 1)
                    {
                        kIndex = positions.FirstOrDefault();
                        if (ValidateKIsNotIAndJ(iIndex, jIndex, kIndex))
                        {
                            var sum = sortedList[iIndex] + sortedList[jIndex] + sortedList[kIndex];

                            if (sum == 0) {
                                var listValue = new List<int>() { sortedList[iIndex], sortedList[jIndex], sortedList[kIndex] };
                                var listSorted = listValue.OrderBy(x => x).ToList();

                                if (!IsAlreadyInTheList(listSorted))
                                {
                                    sumList.Add(listSorted);
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach(var value in positions)
                        {
                            if(value != iIndex && value != jIndex)
                            {
                                kIndex = value;
                                break;
                            }
                        }

                        if (ValidateKIsNotIAndJ(iIndex, jIndex, kIndex))
                        {
                            var sum = sortedList[iIndex] + sortedList[jIndex] + sortedList[kIndex];

                            if (sum == 0)
                            {
                                var listValue = new List<int>() { sortedList[iIndex], sortedList[jIndex], sortedList[kIndex] };
                                var listSorted = listValue.OrderBy(x => x).ToList();

                                if (!IsAlreadyInTheList(listSorted))
                                {
                                    sumList.Add(listSorted);
                                }
                            }
                                
                        }
                    }
                }

                if(directionDecretion == "right" && sortedList[iIndex] != 0)
                {
                    iIndex++;
                    vI = sortedList[iIndex];
                    directionDecretion = "left";
                }
                else
                {
                    jIndex--;
                    vj = sortedList[jIndex];
                    directionDecretion = "right";
                }
            }

            return sumList;
        }

        private bool IsAlreadyInTheList(IList<int> listToCompare)
        {
            var keyValue = string.Join("", listToCompare);

            var isAlreadyInTheList = dictionaryValuesAlreadyInTheList.TryGetValue(keyValue, out IList<int> list);

            if (isAlreadyInTheList)
            {
                return true;
            }
            else
            {
                dictionaryValuesAlreadyInTheList.Add(keyValue, listToCompare);
                return false;
            }
        }

        private bool ValidateKIsNotIAndJ(int i, int j, int k)
        {
            if(k != i && k != j)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public IList<IList<int>> ThreeSumRight(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> result = new List<IList<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue; // Skip duplicate values for i
                }
                int j = i + 1, k = nums.Length - 1;
                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (sum == 0)
                    {
                        result.Add(new List<int> { nums[i], nums[j], nums[k] });
                        j++;
                        k--;
                        while (j < k && nums[j] == nums[j - 1]) j++;
                        while (j < k && nums[k] == nums[k + 1]) k--;
                    }
                    else if (sum < 0)
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                }
            }

            return result;
        }
    }
}
