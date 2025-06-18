using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Medium.IntegerToRoman
{
    public class IntegerToRoman
    {
        private readonly Dictionary<string, int> _romanDict = new Dictionary<string, int>()
        {
            {"I",1 },
            {"V", 5 },
            {"X", 10 },
            {"L", 50 },
            {"C", 100 },
            {"D", 500 },
            {"M", 1000 }
        };

        public string IntToRoman(int num)
        {
            if (num == 0)
            {
                return null;
            }

            var listNums = num.ToString().ToCharArray().Select(x => int.Parse(x.ToString())).ToList();
            var lenghtDictionary = _romanDict.Count();
            var lenghtListNum = listNums.Count();
            var indexListNum = 1;
            var ji = lenghtDictionary - 1;
            StringBuilder sb = new StringBuilder();

            for (int l = 0; l < listNums.Count(); l++)
            {
                var recidio = 0;
                var flag = true;
                var value = listNums[l];
                var ceroNumber = lenghtListNum - indexListNum;
                var p = (int)Math.Pow(10, ceroNumber);
                var jvalue = _romanDict.ElementAt(ji);
                var x = value * p;

                //if(num == jvalue.Value)
                //{
                //    return jvalue.Key;
                //}

                if(value == 0)
                {
                    flag = false;
                }
                
                if (value == 4 || value == 9)
                {
                    while (flag)
                    {
                        var ji_1 = _romanDict.ElementAt(ji - 1 );

                        var resultSecondEquation = x + ji_1.Value;

                        if (resultSecondEquation >= jvalue.Value)
                        {
                            if(resultSecondEquation != jvalue.Value)
                            {
                                recidio = 1;
                                x = resultSecondEquation - jvalue.Value;
                            }
                            else
                            {
                                flag = false;
                                sb.Append(ji_1.Key);
                                if(recidio > 0)
                                {
                                    jvalue = _romanDict.ElementAt(ji + recidio);
                                }
                                sb.Append(jvalue.Key);
                            }
                        }
                        else
                        {
                            ji--;
                            jvalue = _romanDict.ElementAt(ji);
                        }
                    }

                    recidio = 0;
                }
                else
                {
                    //algorith 1
                    while (flag)
                    {
                        if(x >= jvalue.Value)
                        {
                            sb.Append($"{jvalue.Key}");
                            if(x != jvalue.Value)
                            {
                                x = x - jvalue.Value;
                            }
                            else
                            {
                                flag = false;
                            }
                        }
                        else
                        {
                            ji--;
                            jvalue = _romanDict.ElementAt(ji);
                        }
                    }
                }
                indexListNum++;
            }

            return sb.ToString();
        }

        private string CaseWhenIsNotFourOrNine()
        {
            return "";
        }

        private string CaseWhenIsFourOrNine()
        {
            return "";
        }
    }
}
