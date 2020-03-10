using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndComplexityA1
{
    class HelperFunctions
    {
        public void ReverseOrder(int[] array)
            //Reverses the order of a given array of integers.
            //For example Asc > Desc OR Desc > Asc
        {
            if (array.Length <= 1) return; //Best Case - no need to reverse an array of size 1

            for (int x = 0; x < array.Length / 2 ; x++)
            {
                // Loop through first half of array to ensure it's only reversed once
                int currentPos = array[x];
                int calc = array.Length - 1 - x; //Swap halves
                array[x] = array[calc];
                array[calc] = currentPos;
            }
        }

        public void stringToArray(string data)
        {

        }
    }
}
