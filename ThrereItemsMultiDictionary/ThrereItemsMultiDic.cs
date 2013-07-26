using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Wintellect.PowerCollections;

class ThreeItemsMulti
{
    static MultiDictionary<string, Dictionary<string, string>> threeItemsDict;
    private static void AddGrade(string[] words)
    {
        threeItemsDict.Add(words[0], new Dictionary<string, string>() { { words[1], words[2] },});       
    }

    static void Main()
    {
        threeItemsDict = new MultiDictionary<string, Dictionary<string, string>>(true);
        StreamReader reader = new StreamReader(@"..\..\GivenFile.txt", Encoding.GetEncoding("windows-1251"));
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
                AddGrade(words);
                line = reader.ReadLine();
            }
        }

        string findByName = "Mimi Shmatkata";

        Console.WriteLine("Searching by name: {0}", findByName);
        if (threeItemsDict.ContainsKey(findByName))
        {           
            var theValue = threeItemsDict[findByName];
            foreach (var firstKeyValues in theValue)
            {
                foreach (var item in firstKeyValues)
	            {
                    Console.WriteLine("Found: {0}, from: {1}, tel.: {2}", findByName, item.Key, item.Value);
	            }
            }
        }
        else
        {
            Console.WriteLine("Not found");
        }

        string findByNameAnd = "Bat Gancho";
        string findByTown = "Sofia";

        Console.WriteLine("Searching by name: {0}, and town {1}", findByNameAnd, findByTown);
        if (threeItemsDict.ContainsKey(findByNameAnd))
        {
            var theValue = threeItemsDict[findByNameAnd];
            foreach (var firstKeyValues in theValue)
            {
                if (firstKeyValues.ContainsKey(findByTown))
                {
                    foreach (var item in firstKeyValues)
                    {
                        Console.WriteLine("Found: {0}, from: {1}, tel.: {2}", findByNameAnd, item.Key, item.Value);
                    }                  
                }
            }
        }
        else
        {
            Console.WriteLine("Not found");
        }
    }
}

