using System;
using System.Collections.Generic;

class PermitationsWithRepetitionsSet
{
    static void Main()
    {
        string itemsStr = "15555555555555555555";
        char[] digits = itemsStr.ToCharArray();

        long sequencesCounter = CountSequences(digits);
        Console.WriteLine("Total permutations: " + sequencesCounter);
    }

    private static long CountSequences(char[] digits)
    {
        HashSet<string> sequences = new HashSet<string>();
        GeneratePermutations(digits, 0, sequences);
        foreach (var s in sequences)
        {
            Console.WriteLine(s);
        }
        return sequences.Count;
    }

    private static void GeneratePermutations(char[] digits, int start, HashSet<string> sequences)
    {
        if (start == digits.Length - 1)
        {
            sequences.Add(new String(digits));
            return;
        }
        GeneratePermutations(digits, start + 1, sequences);
        for (int i = start; i < digits.Length; i++)
        {
            if (digits[start] != digits[i]) // if true for all the perminations
            {
                Swap(ref digits[start], ref digits[i]);
                GeneratePermutations(digits, start + 1, sequences);
                Swap(ref digits[start], ref digits[i]);
            }

        }
    }

    private static void Swap<T>(ref T first, ref T second)
    {
        T old = first;
        first = second;
        second = old;
    }
}
