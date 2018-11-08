using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.libraries.Google
{
    public static class Google
    {
        
        #region Google Problem - Look for missing range in an sorted list 
        
        public static void FindMissingRange(int[] arr)
        {
            string ranges = string.Empty;

            ranges += getRange(0, arr[0]);

            for(int i = 0; i < (arr.Length - 1); i++)
            {
                ranges += getRange(arr[i], arr[i+1]);
            }

            ranges += getRange(arr[arr.Length - 1], 99);

            Console.WriteLine();
            Console.WriteLine(ranges);
            Console.WriteLine();
        }

        private static string getRange(int first, int second)
        {
            string temp = string.Empty;

            if(first == second || (second - first) == 1)
            {
                return string.Empty;
            }

            if (((second - 1) - first) != 1 && first == 0)
                temp = first + "-" + (second - 1) + ",";
            else if (((second - 1) - first) == 1 && first != 0)
                temp = (first + 1) + ",";
            else if(((second - 1) - first) != 1 && second == 99)
                temp = (first + 1) + "-" + second;
            else
                temp = (first + 1) + "-" + (second - 1) + ",";
            
            return temp;
        }

        // NOTE: NOT USED. ONLY HERE FOR R&D PURPOSE.
        private static string StandardMathOperator(int xValue)
        {
            var result = 0;

            return result.ToString();
        }

        #endregion 
    }
}
