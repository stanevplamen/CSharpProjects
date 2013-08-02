using System;
using System.Collections.Generic;

class KnapsackProblem
{
    static Dictionary<Tuple<int, int>, string> productsAndWeights;
    static List<List<Tuple<int, int>>> allDiffWeights;
    static List<int> allDiffSums;
    static int boarderM = 35;
    static int maxPrice = 0;

    static void Main()
    {
        productsAndWeights = new Dictionary<Tuple<int, int>, string>();
        ReloadTheSourseDictionary();
        DateTime start = DateTime.Now;
        allDiffWeights = new List<List<Tuple<int, int>>>();
        allDiffSums = new List<int>();
        ReloadTheAllDiffWeights();

        int bestIndex = FindTheMaxPrice();

        FindPrintOptimalSolution(bestIndex);
        TimeSpan duration = DateTime.Now - start;
        Console.WriteLine("That took " + duration.TotalMilliseconds + " ms");
    }

    private static void FindPrintOptimalSolution(int bestIndex)
    {
        Console.WriteLine("Optimal Product Solution:");
        foreach (var tuple in allDiffWeights[bestIndex])
        {
            if (productsAndWeights.ContainsKey(tuple))
            {
                Console.Write("{0}, ", productsAndWeights[tuple]);
            }
        }
        Console.WriteLine("the max price is {0}", maxPrice);
    }

    private static int FindTheMaxPrice()
    {
        int i = 0;
        int bestIndex = 0;
        foreach (var list in allDiffWeights)
        {
            int currentPrice = 0;
            foreach (var tuple in list)
            {
                currentPrice = currentPrice + tuple.Item2;
            }
            if (currentPrice > maxPrice)
            {
                maxPrice = currentPrice;
                bestIndex = i;
            }
            i++;
        }
        return bestIndex;
    }

    private static void ReloadTheAllDiffWeights()
    {
        int i = 0;
        int tempCurrentElementsSum = 0;
        foreach (var pair in productsAndWeights)
        {
            if (pair.Key.Item1 <= boarderM)
            {
                int tempCount = allDiffWeights.Count;
                for (int j = 0; j < tempCount; j++)
                {
                    if (j >= allDiffSums.Count)
                    {
                        tempCurrentElementsSum = CalculateSumOfListElements(allDiffWeights[j]) + pair.Key.Item1;
                    }
                    else
                    {
                        tempCurrentElementsSum = allDiffSums[j] + pair.Key.Item1;
                    }
                    if (tempCurrentElementsSum <= boarderM)
                    {
                        LoadCurrentElements(pair.Key.Item1, j, pair.Key.Item2);
                        allDiffSums.Add(tempCurrentElementsSum);
                    }
                }
                allDiffWeights.Add(new List<Tuple<int, int>>());
                allDiffWeights[allDiffWeights.Count - 1].Add(new Tuple<int, int>(pair.Key.Item1, pair.Key.Item2));
                allDiffSums.Add(pair.Key.Item1);
            }
            i++;
        }
    }

    private static void LoadCurrentElements(int currrentKey, int index, int value)
    {
        allDiffWeights.Add(new List<Tuple<int, int>>());
        allDiffWeights[allDiffWeights.Count - 1].Add(new Tuple<int, int>(currrentKey, value));
        foreach (var weigth in allDiffWeights[index])
        {
            allDiffWeights[allDiffWeights.Count - 1].Add(new Tuple<int, int>(weigth.Item1, weigth.Item2));
        }
    }

    private static int CalculateSumOfListElements(List<Tuple<int, int>> currentList)
    {
        int sum = 0;
        foreach (var weigth in currentList)
        {
            sum = sum + weigth.Item1;
        }
        return sum;
    }

    private static void ReloadTheSourseDictionary()
    {
        productsAndWeights.Add(new Tuple<int, int>(3, 2), "beer");
        productsAndWeights.Add(new Tuple<int, int>(8, 12), "vodka");
        productsAndWeights.Add(new Tuple<int, int>(4, 5), "cheese");
        productsAndWeights.Add(new Tuple<int, int>(1, 4), "nuts");
        productsAndWeights.Add(new Tuple<int, int>(2, 3), "ham");
        productsAndWeights.Add(new Tuple<int, int>(4, 3), "aaa");
        productsAndWeights.Add(new Tuple<int, int>(5, 3), "bbb");
        productsAndWeights.Add(new Tuple<int, int>(6, 6), "ccc");
        productsAndWeights.Add(new Tuple<int, int>(7, 10), "ddd");
        productsAndWeights.Add(new Tuple<int, int>(8, 15), "eee");
        productsAndWeights.Add(new Tuple<int, int>(9, 16), "yyy");
        productsAndWeights.Add(new Tuple<int, int>(1, 6), "hhh");
        productsAndWeights.Add(new Tuple<int, int>(1, 3), "fff");
        productsAndWeights.Add(new Tuple<int, int>(2, 19), "ddd");
        productsAndWeights.Add(new Tuple<int, int>(8, 21), "sss");
        productsAndWeights.Add(new Tuple<int, int>(11, 22), "vvv");
        productsAndWeights.Add(new Tuple<int, int>(13, 23), "fff");
        productsAndWeights.Add(new Tuple<int, int>(14, 23), "jjj");
        productsAndWeights.Add(new Tuple<int, int>(15, 25), "kkk");
        productsAndWeights.Add(new Tuple<int, int>(16, 23), "lll");
        productsAndWeights.Add(new Tuple<int, int>(12, 18), "ikki");
    }
}