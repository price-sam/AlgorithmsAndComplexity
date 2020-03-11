using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndComplexityA1
{
    class Searches
    {
        public List<int> LinearSearch(int[] array, int target)
        //Performs a linear search on the given array of integers
        // Takes a target integer - Returns list of positions if found - returns empty list if not found and displays nearest value
        //Potential to have a O(n) 
        {
            int count = 0;
            int closestValue = array[0];
            int closestValuePosition = 0;
            List<int> result = new List<int>();
            foreach (int item in array)
            {
                if (item == target)
                {
                    Console.WriteLine("Found first matching value in " + count.ToString() + " steps.");
                    result.Add(count);
                }
                if (Math.Abs(item-target) < Math.Abs(target-closestValue))
                {

                    closestValue = item;
                    closestValuePosition = count;
                }
                count++;

            }

            Console.WriteLine("Completed in " + count.ToString() + " steps.");
            if (result.Count == 0)
            {
                Console.WriteLine("Nearest Value to target: " + closestValue + " at position " + closestValuePosition);
            }
            return result;
        }


        public List<int> BinarySearch(int[] array, int target)
            //Performs a binary search on the given array of integers
            //Takes a target integer - Returns position of target if found - Returns -1 if not found
            //Iterative Approach
        {

            List<int> result = new List<int>();


            int stepCount = 0;
            int left = 0;
            int right = array.Length - 1;
            int middle;
            int closestValue = array[0];
            int closestValuePosition = 0;
            while (left <= right)
            {
                stepCount++;
                middle = (left + right) / 2;
                if (target == array[middle])
                {
                    Console.WriteLine("Found first matching value in " + stepCount.ToString() + " steps.");
                    result.Add(middle);
                    //return middle; //Best case on first recursion 
                }
                //Calculate if currnet item is a better closest value than what is currently stored 
                if (Math.Abs(array[middle] - target) < Math.Abs(target - closestValue))
                {

                    closestValue = array[middle];
                    closestValuePosition = middle;
                }

                if (target > array[middle]) 
                { 
                    // If target is greater than middle value
                    left = middle + 1;
                    stepCount++;
                }
                else
                {
                    // If target is less than middle value
                    right = middle - 1;
                    stepCount++;
                }
                
            }

            Console.WriteLine("Completed in " + stepCount.ToString() + " steps.");
            Console.WriteLine("Nearest Value to target: " + closestValue + " at position " + closestValuePosition);

            return result;
        }
    }
}
