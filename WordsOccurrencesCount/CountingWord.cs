using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Wintellect.PowerCollections;

class CountingWord
{
    private static HashSet<string> wordsToCount;
    private static Dictionary<string, int> testWordsDictionary;
    private static OrderedMultiDictionary<int,string> countedWords;

    static void Main()
    {
        // reading and splitting the text file
        string fileName = @"..\..\giventext.txt";
        string[] wordsFromText = WordsExtract(fileName);

        // reading and splitting the text file with the words that will be checked
        string testName = @"..\..\test.txt";
        string[] wordsTest = WordsExtract(testName);

        // loading the words HashSet and Dictionary
        LoadTheWordsStructures(wordsFromText, wordsTest);

        // load the output OrderedMultidictionary - <int,string> - sorted by key
        LoadOutputStructure();

        // providing the result to txt file
        WriteResult();
    }

    #region Load words ordering advanced structures
    private static void LoadOutputStructure()
    {
        countedWords = new OrderedMultiDictionary<int, string>(true);
        foreach (var word in wordsToCount)
        {
            if (testWordsDictionary.ContainsKey(word))
            {
                countedWords.Add(testWordsDictionary[word],word);
            }
            else
            {
                countedWords.Add(0, word);
            }
        }
    }

    private static void LoadTheWordsStructures(string[] wordsFromText, string[] wordsTest)
    {
        // get only unique words from words.txt in the HashSet
        wordsToCount = new HashSet<string>();
        for (int i = 0; i < wordsFromText.Length; i++)
        {
            if (!wordsToCount.Contains(wordsFromText[i]))
            {
                wordsToCount.Add(wordsFromText[i]); 
            }
        }
        // get all words and their number of occurence from test.txt in the OrderedMultidictionary
        Array.Sort(wordsTest);
        testWordsDictionary = new Dictionary<string, int>();
        int counter = 1;
        for (int i = 0; i < wordsTest.Length - 1; i++)
        {
            if (wordsTest[i] == wordsTest[i+1])
            {
                counter++;
            }
            else
            {
                testWordsDictionary.Add(wordsTest[i], counter);
                counter = 1;
            }
        }
        if (wordsTest[wordsTest.Length - 1] == wordsTest[wordsTest.Length - 2])
        {
            testWordsDictionary.Add(wordsTest[wordsTest.Length - 1], counter);
        }
        else
        {
            testWordsDictionary.Add(wordsTest[wordsTest.Length - 1], 1);
        }
    }
    #endregion

    #region Load the words from both files in array of strings
    static string[] WordsExtract(string fileName)
    {
        StreamReader reader = new StreamReader(fileName, Encoding.GetEncoding("windows-1251"));

        string text;
        try
        {
            using (reader)
            {
                text = reader.ReadToEnd();
            }
        }
        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine("Directory not found");
            throw new DirectoryNotFoundException(e.Message);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("File not found");
            throw new FileNotFoundException(e.Message);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("The path is null");
            throw new ArgumentNullException();
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("The path is a zero-length string, contains only white space, or contains one or more invalid characters");
            throw new ArgumentException(e.Message);
        }
        string[] words = text.Split(new char[] { (char)9, '-', '+', ' ', '.', ';', ':', ',', '(', ')', '"', '!', '?', '@', '&', '#', '$', '%', '^', '*', '{', '}', '[', ']', '`', '~', '/', '|', '\\', '<', '>', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }, StringSplitOptions.RemoveEmptyEntries);
        return words;
    }
    #endregion

    #region Load the output text file
    static void WriteResult()
    {
        string fileName = @"..\..\result.txt";
        StreamWriter streamWriter = new StreamWriter(fileName);

        using (streamWriter)
        {
            foreach (var pair in countedWords.Reversed())
            {
                streamWriter.WriteLine(string.Format("{0,12} - {1} times", pair.Value, pair.Key));
            }
        }
        Console.WriteLine("The finish file is written!");
    }
    #endregion
}

