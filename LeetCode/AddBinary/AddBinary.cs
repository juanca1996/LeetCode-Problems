using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.AddBinary
{
    public class AddBinary
    {
        public string AddBinaryNew(string a, string b)
        {
            var arrayA = a.ToArray().Select(x => int.Parse(x.ToString())).ToList();
            var arrayB = b.ToArray().Select(y => int.Parse(y.ToString())).ToList();

            if(arrayA.Count() > arrayB.Count())
            {
                var temporalList = new int[arrayA.Count()];
                var indexTemporalList = temporalList.Length - 1;
                for (var i = arrayB.Count() - 1; i >= 0; i--)
                {
                    temporalList[indexTemporalList] = arrayB[i];
                    indexTemporalList--;
                }
                arrayB = temporalList.ToList();
            }
            else
            {
                var temporalList = new int[arrayB.Count()];
                var indexTemporalList = temporalList.Length - 1;
                for (var i = arrayA.Count() - 1; i >= 0; i--)
                {
                    temporalList[indexTemporalList] = arrayA[i];
                    indexTemporalList--;
                }
                arrayA = temporalList.ToList();
            }

            var resudio = 0;
            var list = new List<string>();
            for (int i = arrayA.Count - 1; i >= 0; i--)
            {
                var valueA = arrayA[i];
                var valueB = arrayB[i];

                var firtsCalculation = resudio + valueA;
                if(firtsCalculation > 1)
                {
                    resudio = 1;
                    firtsCalculation = 0;
                }
                else
                {
                    resudio = 0;
                }

                var sum = firtsCalculation + valueB;

                if(sum > 1)
                {
                    resudio = 1;
                }
                else if(firtsCalculation > 1)
                {
                    resudio = 1;
                }

                if(sum > 1 && (i - 1) >  -1)
                {
                    list.Add((0).ToString());
                    resudio = 1;
                }
                else if((i) == 0 && sum > 1)
                {
                    list.Add("0");
                }else{
                    list.Add(sum.ToString());
                }

            }

            if(resudio == 1)
            {
                list.Add("1");
            }

            var contValue = string.Join("",list).Reverse();
            var resultValue = string.Concat(contValue);
            return resultValue;
        }
    }
}
