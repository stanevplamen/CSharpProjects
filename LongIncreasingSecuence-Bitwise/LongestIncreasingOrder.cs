using System;
using System.Collections.Generic;

class LongestIncreasingOrder
{
    static void Main()
    {
        List<int> nArray = new List<int>() { 1, 2, 3, 5, 4, 4, 2, 4, 6, 7, 23, 4, 2 };

        int counter = 0;
        int maxRepeatCounter = -1;
        int lastRepeatCounter = int.MinValue;
        int index = 0;
        int lastIndex = 0;
        int currentNumber = int.MinValue;
        List<int> intTempList = new List<int>();
        List<int> numbersList = new List<int>();
        int iterationsNumber = (int)Math.Pow((double)2, nArray.Count);

        for (int i = 1; i <= (iterationsNumber - 1); i++)
        {
            currentNumber = int.MinValue;
            for (int j = 0; j < nArray.Count; j++)
            {
                int mask = 1 << j;
                int nAndMask = mask & i;
                int bit = nAndMask >> j;

                if (bit == 1)
                {
                    if (nArray[j] >= currentNumber)
                    {
                        counter++;
                        intTempList.Add(nArray[j]);
                        if (maxRepeatCounter < counter)
                        {
                            maxRepeatCounter = counter;
                            index = j - 1;
                        }
                    }
                    else if (nArray[j] < currentNumber)
                    {
                        if (maxRepeatCounter < counter)
                        {
                            maxRepeatCounter = counter;
                            index = j - 1;
                        }
                        counter = 0;
                    }
                    currentNumber = nArray[j];
                }
            }
            if (lastRepeatCounter < maxRepeatCounter)
            {
                lastRepeatCounter = maxRepeatCounter;
                lastIndex = index;
                numbersList = new List<int>(intTempList);
                intTempList = new List<int>();
                counter = 0;
            }
            else
            {
                intTempList = new List<int>();
                counter = 0;
            }
        }

        Console.WriteLine("The entered array is: ");
        foreach (var item in nArray)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 30));

        Console.WriteLine("The longest increasing order is: ");
        foreach (var item in numbersList)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}