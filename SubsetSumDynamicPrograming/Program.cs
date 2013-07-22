using System;
using System.Collections.Generic;

public static class SubsetSums
{
    static int offset;
    public static int[] possible;
    static void Main()
    {
        int[] numbs = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, -1, -2, -3, -4, -5, -6, -7, -8, -9, -10, -600 };
        int N = numbs.Length;
        offset = 100000;
        int minPos = numbs[0];
        int maxPos = numbs[0];
        possible = new int[offset + offset];
        for (int i = 0; i < N; i++)
        {
            int newMinPos = minPos;
            int newMaxPos = maxPos;
            int[] newPossible = new int[possible.Length];
            for (int j = maxPos; j >= minPos; j--) 
            {
                if (possible[j + offset] >= 1)
                {
                    newPossible[j + numbs[i] + offset]++;
                }
                if (j + numbs[i] > newMaxPos)
                {
                    newMaxPos = j + numbs[i];
                }
                if (j + numbs[i] < newMinPos)
                {
                    newMinPos = j + numbs[i];
                }
            }
            minPos = newMinPos;
            maxPos = newMaxPos;
            for (int j = maxPos; j >= minPos; j--)
            {
                if (newPossible[j + offset] >= 1)
                {
                    possible[j + offset] = possible[j + offset] + newPossible[j + offset];
                }
            }

            if (numbs[i] > maxPos)
            {
                maxPos = numbs[i];
            }
            if (numbs[i] < minPos)
            {
                minPos = numbs[i];
            }
            possible[numbs[i] + offset]++;
        }


        Console.Write("All array elements: ");
        for (int i = 0; i < N; i++)
        {
            Console.Write("{0} ", numbs[i]);
        }
        Console.WriteLine("\n");

        int firstCheckedSum = 11; 
        CheckCurrentSum(possible, firstCheckedSum);    
        int secondCheckedSum = -700;
        CheckCurrentSum(possible, secondCheckedSum);
        int thirdCheckedSum = 0;
        CheckCurrentSum(possible, thirdCheckedSum);
        int fourthCheckedSum = 55;
        CheckCurrentSum(possible, fourthCheckedSum);
        int fifthCheckedSum = 210;
        CheckCurrentSum(possible, fifthCheckedSum);

        // Uncoment for all possible sums
        Console.WriteLine("All possible sums:");
        for (int i = minPos; i <= maxPos; i++)
        {
            if (possible[i + offset] >= 1)
            {
                Console.Write("Possible sum: {0,-8}", i);
            }
        }
    }

    private static void CheckCurrentSum(int[] possible, int currentCheckedSum)
    {
        if (possible[currentCheckedSum + offset] != 0)
        {
            Console.WriteLine("The sum {0} is possible", currentCheckedSum);
        }
        else
        {
            Console.WriteLine("The sum {0} is not possible", currentCheckedSum);
        }
    }
}

