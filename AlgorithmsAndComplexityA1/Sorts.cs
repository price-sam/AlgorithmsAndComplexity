using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndComplexityA1
{
    class Sorts
    {
        public int bubbleSort(int[] array, int n)
        {
            int stepCount = 0;
            for (int x = 0; x < n - 1; x++)
            {
                stepCount++;
                for (int y = 0; y < n - 1 - x; y++)
                {
                    stepCount++;
                    if (array[y + 1] < array[y])
                    {
                        int tempSwap = array[y];
                        array[y] = array[y + 1];
                        stepCount++;
                        array[y + 1] = tempSwap;
                        stepCount++;
                    }
                }
            }
            return stepCount;
        }

        public void InsertionSort(int[] data)
        {
            int sortedTotal = 0;
            int index;
            while (sortedTotal < data.Length)
            {
                int temp = data[sortedTotal];
                for (index = sortedTotal; index > 0; index--)
                {
                    if (temp < data[index - 1])
                    {
                        data[index] = data[index - 1];
                    }
                    else
                    {
                        break;
                    }
                }

                data[index] = temp;
                sortedTotal++;
            }
        }

        private void merger(int[] data, int[] temp, int low, int middle, int high)
        {
            int ri = low;
            int ti = low;
            int di = middle;
            while (ti < middle && di <= high)
            {
                if (data[di] < temp[ti])
                {
                    data[ri++] = data[di++];
                }
                else
                {
                    data[ri++] = temp[ti++];
                }
            }
            while (ti < middle)
            {
                data[ri++] = temp[ti++];
            }
        }

        private void MergeSortRecursive(int[] data, int[] temp, int low, int high)
        {
            int n = high - low + 1;
            int middle = low + n / 2;
            int i;

            if (n < 2) return;
            for (i = low; i < middle; i++)
            {
                temp[i] = data[i];
            }
            MergeSortRecursive(temp, data, low, middle - 1);
            MergeSortRecursive(data, temp, middle, high);
            merger(data, temp, low, middle, high);
        }

        public void MergeSort(int[] data)
        {
            int[] temp = new int[data.Length];
            MergeSortRecursive(data, temp, 0, data.Length - 1);
        }

        public void QuickSort(int[] data, int left, int right) //Not working - figure this out
        {
            int i, j;
            int pivot, temp;
            i = left;
            j = right;
            pivot = data[(left + right) / 2];

            do
            {
                while ((data[i] < pivot) && (i < right)) i++;
                while ((pivot < data[j]) && (i > left)) j--;

                if (i <= j)
                {
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (left < j) QuickSort(data, left, j);
            if (i < right) QuickSort(data, i, right);
        }
    

    }

}