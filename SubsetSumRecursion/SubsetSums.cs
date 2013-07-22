using System;
using System.Collections.Generic;

class SubsetSums
{
    static long[] nArray = { 4, 3, 4, 11, 4, 2, 6, 5, 12, 1, 13, 14, 7, 5 };
    static int checkedSum = 11;

    static void Gen01(int index, int[] vector)
    {
        if (index == -1)
        {
            Print(vector);
        }
        else
        {
            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                Gen01(index - 1, vector);
            }
        }
    }
    static void Print(int[] vector)
    {
        long currentSum = 0;
        List<long> intList = new List<long>();

        for (int i = 0; i < vector.Length; i++)
        {
            if (vector[i] == 1)
            {
                currentSum = currentSum + nArray[i];
                intList.Add(nArray[i]);
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
            intList = new List<long>();
        }
        else
        {
            intList = new List<long>();
        }
    }

    static void Main()
    {
        int number = nArray.Length;
        int[] vector = new int[number];
        Console.WriteLine("The elements which sum is equal to the requested sum ({0}) are: ", checkedSum);
        Gen01(number - 1, vector);
    }
}
