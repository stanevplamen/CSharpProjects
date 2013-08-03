using System;
using System.Collections.Generic;

static class LevenshteinDistance
{
    static double deleteCost = 0.9;
    static double insertCost = 0.8;
    static double replaceCost = 1.0;
    public static double[,] med;

    public static double Compute(string firstStr, string secondStr)
    {
        int n = firstStr.Length;
        int m = secondStr.Length;
        med = new double[firstStr.Length + 1, secondStr.Length + 1];

        // Step 1 load the Zero rows and columns
        for (int i = 0; i <= firstStr.Length; i++)
        {
            med[i, 0] = i * deleteCost;
        }

        for (int j = 0; j <= secondStr.Length; j++)
        {
            med[0, j] = j * insertCost;
        }

        // Step 2 check if we have an empty string
            // transform first to second : insert
        if (firstStr.Length == 0)
        {
            return secondStr.Length * insertCost;
        }
            // transform first to second : delete
        if (secondStr.Length == 0)
        {
            return firstStr.Length * deleteCost;
        }

        double currentCost = 0;
        for (int i = 1; i <= firstStr.Length; i++)
        {          
            for (int j = 1; j <= secondStr.Length; j++)
            {
                // Step 3 check if the current letters are equal
                if (secondStr[j - 1] == firstStr[i - 1])
                {
                    currentCost = 0.0;
                }
                else
                {
                    currentCost = replaceCost;
                }

                // Step 4 check the neighbor cells and add the current min value
                med[i, j] = Math.Min(Math.Min(med[i - 1, j] + deleteCost, med[i, j - 1] + insertCost), med[i - 1, j - 1] + currentCost);
            }
        }
        // Step 5 return
        return med[firstStr.Length, secondStr.Length];
    }
}

class MinimumEditDistance
{
    static void Main()
    {
        List<string[]> allWordsToCompare = new List<string[]>
                {
	            new string[]{"ant", "aunt"},
                new string[]{"aunt", "ant"},
	            new string[]{"Sam", "Samantha"},
	            new string[]{"clozapine", "olanzapine"},
	            new string[]{"flomax", "volmax"},
	            new string[]{"toradol", "tramadol"},
	            new string[]{"kitten", "sitting"},
                new string[]{"flomax", "volmax"},
                new string[]{"developer", "enveloped"},
                };

        foreach (string[] strArr in allWordsToCompare)
        {
            double currentMinCost = LevenshteinDistance.Compute(strArr[0], strArr[1]);
            Console.WriteLine("{0} -> {1} = {2}", strArr[0], strArr[1], currentMinCost);
            PrintCostsTable(LevenshteinDistance.med);
        }
    }

    public static void PrintCostsTable(double[,] table)
    {
        Console.WriteLine("Costs table");
        for (int i = 0; i < table.GetLength(0); i++)
        {
            for (int j = 0; j < table.GetLength(1); j++)
            {
                Console.Write("{0:0.00} ", table[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("\n\n");
    }
}