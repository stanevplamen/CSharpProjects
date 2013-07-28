using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Wintellect.PowerCollections;

class ThreeItemsSortedDictionary
{
    static SortedDictionary<string, OrderedBag<Pair<string, string>>> threeItemsDict;

    static void Main()
    {
        threeItemsDict = new SortedDictionary<string, OrderedBag<Pair<string, string>>>();

        ReadTheFileContents();

        PrintResult();
    }

    private static void PrintResult()
    {
        foreach (var pair in threeItemsDict)
        {
            Console.Write("{0} - ", pair.Key);
            foreach (var two in pair.Value)
            {
                Console.Write("| {0}, {1} |", two.First, two.Second);
            }
            Console.WriteLine();
        }
    }

    private static OrderedBag<Pair<string, string>> testBag = new OrderedBag<Pair<string, string>>();

    private static void LoadTheDictionary(string[] words)
    {

        if (threeItemsDict.ContainsKey(words[2]))
        {
            Pair<string, string> testPair = new Pair<string, string>(words[1], words[0]);
            threeItemsDict[words[2]].Add(testPair);
        }
        else
        {
            testBag = new OrderedBag<Pair<string, string>>();
            testBag.Add(new Pair<string, string>(words[1], words[0]));
            threeItemsDict.Add(words[2], testBag);
        }
    }

    private static void ReadTheFileContents()
    {
        StreamReader reader = new StreamReader(@"..\..\students.txt", Encoding.GetEncoding("windows-1251"));
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] words = line.Split('|');
                for (int i = 0; i < words.Length; i++)
                {
                    words[i] = words[i].Trim(' ', ' ');
                }
                LoadTheDictionary(words);
                line = reader.ReadLine();
            }
        }
    }
}

