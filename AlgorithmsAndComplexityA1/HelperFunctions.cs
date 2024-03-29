﻿using System;
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


        public void OutputArray(int[] array)
            //Outputs an array to console in a formatted way.
            //Folllows assessment brief rules with outputting different size arrays. (10 for >= 256 OR 50 < 256)
        {
            string arrayPrintable = "{";
            char seperator = ',';
            int iterator = 10;
            if (array.Length > 500) iterator = 50;

            for (int i = 0; i < array.Length; i+=iterator)
            {
                arrayPrintable = arrayPrintable + array[i].ToString() + seperator;
            }

            arrayPrintable = arrayPrintable + "}";
            Console.WriteLine("Displaying result array - showing every " + iterator + "th item in the array with length of " + array.Length);
            Console.WriteLine(arrayPrintable);

        }

        public int ParseInt(string x)
        {
            //Attempts to parse a string to int32 
            int output = 0;
            try
            {
                output = Convert.ToInt32(x);
            }
            catch
            {
                return -999999;
            }
            return output;
        }

        public int[] stringToIntArray(string[] array)
        {
            int[] newArray = new int[array.Length];
            int dataCount = 0;
            // Add each value as an integer to an array of integers ( as readalllines returns String[])
            foreach (string item in array)
            {
                if (item == "") continue;
                try
                {
                    newArray[dataCount] = Convert.ToInt32(item);
                }
                catch
                {
                    Console.WriteLine("\nInvaid data found in file. Ignoring...\n");
                    continue;
                }


                dataCount++;
            }

            return newArray;
        }
    }
}
