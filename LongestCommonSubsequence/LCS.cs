using System;
using System.Collections.Generic;

class LCS
{
    static string firstStr = "enveloped";
    static string secondStr = "developer";
    static int[,] lcs = new int[firstStr.Length + 1, secondStr.Length + 1];
    static List<char> lcsLetters;

    static void Main()
    {
        int lcsNumber = CalcLCS();
        Console.WriteLine(lcsNumber);
        lcsLetters = new List<char>();
        LoadLCS(firstStr.Length, secondStr.Length);
        PrintLCS();
    }

    private static void PrintLCS()
    {
        foreach (var ch in lcsLetters)
        {
            Console.Write("{0} ", ch);
        }
    }

    static int CalcLCS()
    {
        for (int i = 1; i <= firstStr.Length; i++)
        {
            for (int j = 1; j <= secondStr.Length; j++)
            {
                char tempOne = firstStr[i - 1];
                char tempTwo = secondStr[j - 1];

                if (secondStr[j - 1] == firstStr[i - 1])
                {
                    lcs[i, j] = lcs[i - 1, j - 1] + 1;
                }
                else
                {
                    lcs[i, j] = Math.Max(lcs[i,j - 1], lcs[i - 1, j]);
                }
            }
        }
        return lcs[firstStr.Length, secondStr.Length];
    }

    static void LoadLCS(int i, int j)
    {
        if (i == 0 || j == 0)
        { 
            return; 
        }
        if (firstStr[i - 1] == secondStr[j - 1])
        {
            LoadLCS(i - 1, j - 1);
            lcsLetters.Add(firstStr[i - 1]);
        }
        else if (lcs[i,j] == lcs[i - 1,j])
        {
            LoadLCS(i - 1, j);
        }
        else
        {
            LoadLCS(i, j - 1);
        }
    }
}
