using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndComplexityA1
{
    class Merging
    {
        public int[] mergeFiles(int[] arrayOne, int[] arrayTwo)
        {
            int totalLengthOfBoth = 0;
            totalLengthOfBoth += arrayOne.Length;
            totalLengthOfBoth += arrayTwo.Length;


            int[] newMergedArray = new int[totalLengthOfBoth];

            int step = 0;
            foreach (int item in arrayOne)
            {
                newMergedArray[step] = item;
                step++;
            }
            foreach (int item in arrayTwo)
            {
                newMergedArray[step] = item;
                step++;
            }

            return newMergedArray;
        }
    }
}
