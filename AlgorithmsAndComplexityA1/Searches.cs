using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndComplexityA1
{
    class Searches
    {

        public int LinearSearch(int[] array, int target)
        //Performs a linear search on the given array of integers
        // Takes a target integer - Returns position if found - Returns -1 if not found
        //Potential to have a O(n) 
        {
            int count = 0;
            foreach (int item in array)
            {
                if (item == target) return count;
                count++;
            }

            return -1;
        }


        public int BinarySearch(int[] array, int target)
            //Performs a binary search on the given array of integers
            //Takes a target integer - Returns position of target if found - Returns -1 if not found
            //Iterative Approach
        {
            int left = 0;
            int right = array.Length - 1;
            int middle;
            while (left <= right)
            {
                middle = (left + right) / 2;
                if (target == array[middle]) return middle; //Best case on first recursion 

                if (target > array[middle]) 
                { 
                    // If target is greater than middle value
                    left = middle + 1;
                }
                else
                {
                    // If target is less than middle value
                    right = middle - 1;
                }
                
            }

            return -1;
        }
    }
}
