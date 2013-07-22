using System;

public static class LongestIncreasingSecuence
{
    static void Main()
    {
        int arrayLength = 13;
        int[] inputNumbers = { 3, 5, 4, 7, 6, -34, 8, 434, -34, 455, 0, 2, 4};
        int maxLength = 1;
        int bestEnd = 0;
        int[] arrayPlus = new int[arrayLength];
        int[] arrayMinus = new int[arrayLength];
        arrayPlus[0] = 1;
        arrayMinus[0] = -1;
        for (int i = 1; i < arrayLength; i++)
        {
            arrayPlus[i] = 1;
            arrayMinus[i] = -1;
            for (int j = i - 1; j >= 0; j--)
            {
                if (arrayPlus[j] + 1 > arrayPlus[i] && inputNumbers[j] < inputNumbers[i])
                {
                    arrayPlus[i] = arrayPlus[j] + 1;
                    arrayMinus[i] = j;
                }
            }
            if (arrayPlus[i] > maxLength)
            {
                bestEnd = i;
                maxLength = arrayPlus[i];
            }
        }
        Console.Write("Max length: " + maxLength);
        Console.Write("\n");
        Console.Write("Sequence end index: " + bestEnd);
        Console.Write("\n");
        Console.Write("Longest subsequence: ");
        int currentBE = bestEnd;
        int[] longestIncreasingSecuenceArray = new int[arrayLength];
        int p = 0;
        while (currentBE != -1)
        {
            longestIncreasingSecuenceArray[p] = inputNumbers[currentBE];
            currentBE = arrayMinus[currentBE];
            p++;
        }

        for (int i = longestIncreasingSecuenceArray.Length - 1; i >= 0; i--)
        {
            if (longestIncreasingSecuenceArray[i] != 0)
            {
                Console.Write("{0} ", longestIncreasingSecuenceArray[i]);
            }
        }
        Console.Write("\n");
    }
}
