﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndComplexityA1
{
    class Sorts
    {
        public int bubbleSort(int[] array, int n)
            // Bubble Sort
            // Takes in an array and length integer
            // Returns total steps taken
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
                    }
                }
            }
            return stepCount;
        }

        public int InsertionSort(int[] data)
        {
            // Insertsion Sort
            // Takes in an array
            // Returns total steps taken
            int stepCount = 0;
            int sortedTotal = 0;
            int index;
            while (sortedTotal < data.Length)
            {
                stepCount++;
                int temp = data[sortedTotal];
                for (index = sortedTotal; index > 0; index--)
                {
                    stepCount++;
                    if (temp < data[index - 1])
                    {
                        data[index] = data[index - 1];
                        stepCount++;
                    }
                    else
                    {
                        break;
                    }
                }

                data[index] = temp;
                sortedTotal++;
             }
            return stepCount;
        }

        private void merger(int[] data, int[] temp, int low, int middle, int high)
        {
            //Merger (PRIVATE)
            //Merges two arrays for merge sort
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

        private int MergeSortRecursive(int[] data, int[] temp, int low, int high, int stepCount)
        {
            // Merge Sort Recursive (PRIVATE)
            // Private function to start recursive loop for merge sort
            int n = high - low + 1;
            int middle = low + n / 2;
            int i;

            if (n < 2) return stepCount;
            for (i = low; i < middle; i++)
            {
                temp[i] = data[i];
                stepCount++;
            }
            stepCount += 3;
            MergeSortRecursive(temp, data, low, middle - 1, stepCount);
            MergeSortRecursive(data, temp, middle, high, stepCount);
            merger(data, temp, low, middle, high);

            return stepCount;
        }

        public int MergeSort(int[] data)
        // Merge Sort
        // Takes in an array 
        // Returns total steps taken
        {
            int[] temp = new int[data.Length];
            return MergeSortRecursive(data, temp, 0, data.Length - 1, 0);
        }



        private int theQuickSort(int[] data, int left, int right, int stepCount) 
        {
            stepCount++;
            int i, j;
            int pivot, temp;
            i = left;
            j = right;
            pivot = data[(left + right) / 2];

            do
            {
                while ((data[i] < pivot) && (i < right)) 
                {
                    i++;
                    stepCount++;
                 } ;
                while ((pivot < data[j]) && (i > left))
                {
                    j--;
                    stepCount++;
                }

               

                if (i <= j)
                {
                    stepCount++;
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (left < j) theQuickSort(data, left, j, stepCount);
            if (i < right) theQuickSort(data, i, right, stepCount);

            return stepCount;
        }


        public int QuickSort(int[] data)
        // Quick Sort
        // Takes in an array 
        // Returns total steps taken
        {
            return theQuickSort(data, 0, data.Length - 1, 0);
        }
    

    }

}