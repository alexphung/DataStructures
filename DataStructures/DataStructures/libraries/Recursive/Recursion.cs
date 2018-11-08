using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.libraries.Recursive
{
    public static class Recursion
    {
        #region All Recursive Functions are made static here for easy access and usage

        /// <summary>
        /// Ackermann's Function - Grows rapidly with respect to the size of m and n.
        ///                        Thus, a recursive solution is considered.
        ///                        
        ///                         {   n + 1                           if m = 0                         
        ///         Acker(m, n) =   {   Acker(m - 1, 1)                 if n = 0
        ///                         {   Acker(m - 1, Acker(m, n - 1))   Otherwise
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Acker(int m, int n)
        {
            if (m == 0)
                return (n + 1);
            if (n == 0)
                return Acker(m - 1, 1);
            else
                return Acker(m - 1, Acker(m, n - 1));
        }

        /// <summary>
        /// The Towers of Hanoi problem.
        /// Given:
        /// N = Number of disk on a Pole
        /// src     = 'A' : Pole A
        /// dest    = 'B' : Pole B
        /// spare   = 'C' : Pole C
        /// Objective is to simulate the moving of all the disks from A to C, 
        /// where the larger disk can't be on top of the smaller disk.
        /// This function simulate the number of instructional moves that are
        /// required to transfer the N disks from the src to the dest.
        /// </summary>
        /// <param name="N"></param>
        /// <param name="src"></param>
        /// <param name="dest"></param>
        /// <param name="spare"></param>
        public static void SolveTowers(int N, char src, char dest, char spare)
        {
            if (N == 1)
                Console.WriteLine("Move top disk from pole " + src + " to pole " + dest);
            else
            {
                // Making 3 recursive calls denoted : X, Y and Z
                SolveTowers(N - 1, src, spare, dest);   // X
                SolveTowers(1, src, dest, spare);       // Y
                SolveTowers(N - 1, spare, dest, src);   // Z
            }
        }

        /// <summary>
        /// This is an example of a recursive binary search of an Array items.
        /// Given: Binary Search of Array : <1, 5, 9, 12, 15, 21, 29, 31>
        /// Note binary search have an efficient of log(N/2)
        /// </summary>
        /// <param name="arr">Array Items</param>
        /// <param name="first">First Index</param>
        /// <param name="last">Last Index</param>
        /// <param name="value">Search Value</param>
        /// <param name="index">Found Index</param>
        public static void BinarySearchOfArray(int[] arr, int first, int last, int value, ref int index)
        {
            if(first > last)
                index = -1;
            else
            {
                int mid = ((first + last) / 2);
                if(value == arr[mid])
                {
                    index = mid;
                }
                else if(value < arr[mid])
                {
                    BinarySearchOfArray(arr, first, mid - 1, value, ref index);
                }
                else
                {
                    BinarySearchOfArray(arr, mid + 1, last, value, ref index);
                }
            }

        }

        public static bool IsPalindromes(string word)
        {
            // Handle for all word in the same either UPPER OR LOWER CASE.
            word = word.ToLower();

            if (string.IsNullOrEmpty(word) || word.Length == 1)
            {
                return true;
            }
            else if(word[0] == word[word.Length - 1])
            {   
                word = word.Substring(1, word.Length - 2);
                return IsPalindromes(word);
            }
            else
            {
                return false;
            }
        }

        public static bool IsWordAnBnForm(string word)
        {
            // Handle for all word of A^nB^n in UPPER CASE.
            word = word.ToUpper();
            if (string.IsNullOrEmpty(word))
                return true;
            else if(word[0] == 'A' && word[word.Length - 1] == 'B')
            {
                word = word.Substring(1, word.Length - 2);
                return IsWordAnBnForm(word);
            }
            else
            {
                return false;
            }
        }

        public static int FindSmallestNumber(int[] array, int firstIndex, int lastIndex)
        {
            if (firstIndex == lastIndex)
                return array[firstIndex - 1];
            else
            {
                int Mid = (firstIndex + lastIndex) / 2;
                int s1 = 0;
                int s2 = 0;

                s1 = FindSmallestNumber(array, firstIndex, Mid);
                s2 = FindSmallestNumber(array, Mid + 1, lastIndex);

                // Simply flipping the sign "<=" to ">=" will invert 
                // this function to look for the Kth largest number in the array.
                if (s1 <= s2)
                    return s1;
                else
                    return s2;
            }
        }

        // Books version of Finding the Kth Smallest Value
        public static void KSmall(ref int ksmall, int[] array, int first, int last)
        {
            // suppose we choose p in array[first...last]
            // partition the items of array[first...last] about p
            int pivotIndex = 0;

            if(ksmall < pivotIndex - first + 1)
            {
                KSmall(ref ksmall, array, first, pivotIndex - 1);
            }
            else if(ksmall == pivotIndex - first + 1)
            {
                ksmall = pivotIndex;
            }
            else
            {
                ksmall = (ksmall - (pivotIndex - first + 1));
                KSmall(ref ksmall, array, pivotIndex + 1, last);
            }
        }

        #endregion
    }
}
