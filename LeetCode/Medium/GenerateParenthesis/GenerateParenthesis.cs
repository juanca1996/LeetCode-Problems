using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Medium.GenerateParenthesis
{
    public class GenerateParenthesis
    {
        // analizar por que el arreglo esta retornando menos valores
        // puede estar relacionado la tema de como se esta recorriendo el array o su orden
        public IList<string> GenerateParenthesisMethod(int n)
        {
            if(n == 0)
            {
                return null;
            }

            int arraySize = n * 2;
            string[] parenthesysArray = new string[arraySize];
            int[] indexParParentesis = new int[n];
            int[] indexOddParentesis = new int[n];

            HashSet<string> result = new HashSet<string>();

            
            string repeatedLeft = string.Concat(Enumerable.Repeat("(", n));
            string repeatedRight = string.Concat(Enumerable.Repeat(")", n));
            string defaultValue = repeatedLeft + repeatedRight;

            int indexPosition = 0;
            for (int i = 0; i < arraySize; i = i + 2)
            {
                parenthesysArray[i] = "(";
                parenthesysArray[(i + 1)] = ")";

                if(indexPosition < n)
                {
                    indexParParentesis[indexPosition] = i;
                    indexOddParentesis[indexPosition] = i + 1;
                }
                else
                {
                }

                indexPosition++;
            }


            // second part 

            for (int i = 0; i < indexOddParentesis.Count() - 1; i++)
            {
                for (int j = indexParParentesis.Count() - 1; j > 0; j--)
                {
                    string[] parenthesysArrayCopy = new string[arraySize];

                    parenthesysArrayCopy = (string[])parenthesysArray.Clone();

                    if (j == i)
                    {
                        var indexOdd = indexOddParentesis[i];
                        var valueCopy = parenthesysArrayCopy[indexOdd];

                        // first substitucion
                        var indexPar = indexParParentesis[j + 1];
                        var valueParCopy = parenthesysArrayCopy[indexPar];

                        parenthesysArrayCopy[indexOdd] = valueParCopy;
                        parenthesysArrayCopy[indexPar] = valueCopy;


                        // third substitution
                        var indexOdd2 = indexOddParentesis[i - 1];
                        var valueCopy2 = parenthesysArrayCopy[indexOdd2];

                        var indexPar2 = indexParParentesis[j];
                        var valueParCopy2 = parenthesysArrayCopy[indexPar2];

                        parenthesysArrayCopy[indexOdd2] = valueParCopy;
                        parenthesysArrayCopy[indexPar2] = valueCopy;

                        result.Add(string.Join("", parenthesysArrayCopy));
                        break;
                    }
                    else
                    {
                        var indexOdd = indexOddParentesis[i];
                        var valueCopy = parenthesysArrayCopy[indexOdd];

                        var indexPar = indexParParentesis[j];
                        var valueParCopy = parenthesysArrayCopy[indexPar];

                        //substitution 
                        parenthesysArrayCopy[indexOdd] = valueParCopy;
                        parenthesysArrayCopy[indexPar] = valueCopy;

                        result.Add(string.Join("", parenthesysArrayCopy));

                    }
                }
            }

            result.Add(string.Join("", parenthesysArray));
            result.Add(defaultValue);


            return result.ToList();
        }

        public IList<string> GenerateParenthesisVersion2(int n)
        {
            int arraySize = n * 2;
            HashSet<string> result = new HashSet<string>();

            string baseArray = string.Concat(Enumerable.Repeat("(", n));
            baseArray = baseArray + string.Concat(Enumerable.Repeat(")", n));

            string[] arrayChange = baseArray.ToArray().Select(x => x.ToString()).ToArray();

            int[] leftValues = new int[n - 1];
            int[] rightValue = new int[n - 1];

            int intSubArrays = 0;

            for(int i = 0; i < arrayChange.Count() - 1; i++)
            {
                if(i != 0 && i <= n - 1)
                {
                    leftValues[intSubArrays] = i;
                    intSubArrays = intSubArrays + 1;
                }

                if(intSubArrays == n - 1)
                {
                    intSubArrays = 0;
                }

                if (i > n - 1 && i != arrayChange.Count())
                {
                    rightValue[intSubArrays] = i;
                    intSubArrays = intSubArrays + 1;
                }

                
            }



            return null;
        }
    }
}
