using System;
using System.Collections.Generic;

class SubsetSums
{
    static void Main()
    {
        long[] nArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, -1, -2, -3, -4, -5, -6, -7, -8, -9, -10, -600 };
        int checkedSum = 0;
        int counter = 0;
        long currentSum = 0;
        List<long> intList = new List<long>();
        long iterationsNumber = (long)Math.Pow((double)2, nArray.Length);

        Console.WriteLine("The elements which sum is equal to the requested sum ({0}) are: ", checkedSum);
        for (int i = 1; i <= (iterationsNumber - 1); i++)
        {
            currentSum = 0;
            for (int j = 0; j < nArray.Length; j++)
            {
                long mask = 1 << j;
                long nAndMask = mask & i;
                long bit = nAndMask >> j;

                if (bit == 1)
                {
                    currentSum = currentSum + nArray[j];
                    intList.Add(nArray[j]);
                }
            }
            if (currentSum == checkedSum)
            {
                foreach (int c in intList)
                {
                    Console.Write("{0},", c);
                }
                Console.Write("\b;");
                Console.WriteLine();
                counter++;
                intList = new List<long>();
            }
            else
            {
                intList = new List<long>();
            }
        }
    }
}
