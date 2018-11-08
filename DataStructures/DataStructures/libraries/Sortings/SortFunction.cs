using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.libraries.Sortings
{
    public static class SortFunction
    {
        #region Selection Sort - Algorithm O(N^2)

        public static void SelectionSort(int[] array, int firstIndex, int lastIndex)
        {
            while (firstIndex < lastIndex)
            {
                int largestIndex = FindLargeIndex(array, lastIndex);

                Swap(array, lastIndex - 1, largestIndex);

                lastIndex--;
            }
        }

        private static int FindLargeIndex(int[] array, int curSize)
        {
            int retLargeIndex = 0;

            for (int i = 0; i < curSize; i++)
            {
                if (array[retLargeIndex] < array[i])
                    retLargeIndex = i;
            }

            return retLargeIndex;
        }

        private static void Swap(int[] array, int lastIndex, int largeIndex)
        {
            int temp = array[lastIndex];
            array[lastIndex] = array[largeIndex];
            array[largeIndex] = temp;
        }

        #endregion

        #region Bubble Sort - Algorithm O(N^2)

        public static void BubbleSort(int[] array)
        {
            for (int pass = 1; pass < array.Length; pass++)
            {
                for (int index = 0; index < (array.Length - pass); index++)
                {
                    int nextIndex = index + 1;
                    if (array[index] > array[nextIndex])
                    {
                        int temp = array[index];
                        array[index] = array[nextIndex];
                        array[nextIndex] = temp;
                    }
                }
            }
        }

        #endregion

        #region Insertion Sort - Algorithm O(N^2)

        public static void InsertionSort(int[] array, int nItems)
        {
            for (int unsorted = 1; unsorted < nItems; unsorted++)
            {
                int nextItem = array[unsorted];
                int rightPosition = unsorted;

                // All we really doing here is performing N - 1 comparison and shift if necessary
                for (; (rightPosition > 0) && (array[rightPosition - 1] > nextItem); rightPosition--)
                {
                    array[rightPosition] = array[rightPosition - 1];
                }

                array[rightPosition] = nextItem;
            }
        }

        #endregion

        #region Merge Sort - O(N * Log(N))

        public static void MergeSort(int[] array, int firstIndex, int lastIndex)
        {
            int midIndex = (firstIndex + lastIndex) / 2;

            DivideArray(array, firstIndex, lastIndex);

            MergeArray(array, firstIndex, midIndex, lastIndex);
        }

        public static void DivideArray(int[] array, int firstIndex, int lastIndex)
        {
            if(firstIndex < lastIndex)
            {
                int midIndex = (firstIndex + lastIndex) / 2;
                SortArray(array, firstIndex, midIndex);
                DivideArray(array, firstIndex, midIndex);
                SortArray(array, firstIndex, midIndex + 1);
                DivideArray(array, midIndex + 1, lastIndex);
            }
        }

        private static void SortArray(int[] array, int first, int last)
        {
            for(;first < last; first++)
            {
                if(array[first - 1] > array[first])
                {
                    int temp = array[first];
                    array[first] = array[first - 1];
                    array[first - 1] = temp;
                }
            }
        }

        // F = FirstIndex , M = MidIndex , L = LastIndex
        private static void MergeArray(int[] array, int F, int M, int L)
        {
            int[] tempArray = new int[L];

            int First1 = F - 1;
            int Last1 = M;
            int First2 = M;
            int Last2 = L - 1;

            // The first half and the second half are sorted in asc
            // The first value of the first half is less than the first value of the second half respectively.
            for (int index = First1; (First1 <= Last1) && (First2 <= Last2); index++)
            {
                if (array[First1] < array[First2] && First1 != M)
                {
                    tempArray[index] = array[First1];
                    First1++;
                }
                else
                {
                    tempArray[index] = array[First2];
                    First2++;
                }
            }

            for (int index = 0; index < L; index++)
                array[index] = tempArray[index];
        }

        #endregion

        #region Quick SOrt - O(N * Log(N)) where worse case is O(N^2)

        public static int Partition(int[] numbers, int left, int right)
        {
            int pivot = numbers[left];

            while (true)
            {
                while (numbers[left] < pivot)
                    left++;
                
                while (numbers[right] > pivot)
                    right--;

                if (left < right)
                {
                    int temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        public static void QuickSort_Recursive(int[] arr, int left, int right)
        {
            // For Recusrion
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                    QuickSort_Recursive(arr, left, pivot - 1);

                if (pivot + 1 < right)
                    QuickSort_Recursive(arr, pivot + 1, right);
            }
        }

        #endregion

        #region Radix Sort - O(N)
        /// <summary>
        /// @TODO: Need to look into in some more and find an implementation.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="sizeOfArray"></param>
        /// <param name="numberOfDigits"></param>
        public static void RadixSort(string[] array, int sizeOfArray, int numberOfDigits)
        {
            for (int j = numberOfDigits; j >= 1; j--)
            {
                for (int i = 0; i < sizeOfArray; i++)
                {

                }
            }
        }

        #endregion
    }
}
