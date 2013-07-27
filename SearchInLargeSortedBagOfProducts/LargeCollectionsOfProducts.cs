using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using Wintellect.PowerCollections;

class LargeCollectionsOfProducts
{   
    static OrderedBag<Item> orderedBagOfProducts;

    static void Main()
    {
        // 1. generate a text file
        LoadTextFile();

        // 2. fill the bag
        FillingTheBag();       
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("bg-BG");

        // 3. test for 10 000 price searches
        Console.WriteLine("Providing the 10000 searches, please wait..");
        StreamWriter streamWriter = new StreamWriter(@"..\..\OutputProductsLists.txt");
        int testsCount = 10000;
        int lower; int upper;
        using (streamWriter)
        {
            for (int i = 1; i <= testsCount; i++)
            {
                lower = RandomNumberLower();
                upper = RandomNumberUpper();
                TestForPriceSearches(lower, upper, streamWriter);
            } 
        }
        Console.WriteLine("The searches have been provided!");
    }

    private static void TestForPriceSearches(int lower, int upper, StreamWriter streamWriter)
    {
        var result = orderedBagOfProducts.Range(new Item("searchItem", lower), true, new Item("searchItem", upper), true);
        // you can uncomment for printing bur reduce the testsCount number
        //streamWriter.WriteLine("===========================new search============================");
        //foreach (var product in result)
        //{
        //    streamWriter.WriteLine("{0} {1:C2}", product.Name, product.Price);
        //}    
    }

    static int RandomNumberLower()
    {
        Random rnd = new Random();
        //Thread.Sleep(1);
        int random = rnd.Next(5, 6);
        return random;
    }
    static int RandomNumberUpper()
    {
        Random rnd = new Random();
        //Thread.Sleep(1);
        int random = rnd.Next(6, 7);
        return random;
    }

    private static void fillTheBagWithProducts(string product, decimal price)
    {
        orderedBagOfProducts.Add(new Item(product, price));
    }

    private static void FillingTheBag()
    {
        Console.Write("Filing the bag: ");
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("nl-NL");
        orderedBagOfProducts = new OrderedBag<Item>();
        StreamReader reader = new StreamReader(@"..\..\BigProguctList.txt");
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] items = line.Split('|');

                string product = items[0].Trim(' ');
                string[] priceItems = items[1].Trim().Split(' ');
                decimal price = decimal.Parse(priceItems[0].Trim());

                fillTheBagWithProducts(product, price);
                line = reader.ReadLine();
            }
        }
        Console.WriteLine("Done");
    }

    static void LoadTextFile()
    {
        Console.WriteLine("Writing a text file with 500 000 products, please wait...");
        ulong rows = 500000; //ulong.Parse(Console.ReadLine());
        StringBuilder textStringBuilder = new StringBuilder();
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("bg-BG");
        for (ulong i = 1; i <= rows; i++)
        {
            int custom = RandomNumber();
            decimal price = 0;
            switch (custom)
            {
                case 1:
                    textStringBuilder.Append("milk | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2}", price));
                    textStringBuilder.AppendLine();
                    break;
                case 2:
                    textStringBuilder.Append("sugar | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2}", price));
                    textStringBuilder.AppendLine();
                    break;
                case 3:
                    textStringBuilder.Append("ice cream | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2}", price));
                    textStringBuilder.AppendLine();
                    break;
                case 4:
                    textStringBuilder.Append("cheese | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2}", price));
                    textStringBuilder.AppendLine();
                    break;
                case 5:
                    textStringBuilder.Append("pork meat | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2}", price));
                    textStringBuilder.AppendLine();
                    break;
                case 6:
                    textStringBuilder.Append("yogurt | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2}", price));
                    textStringBuilder.AppendLine();
                    break;
                case 7:
                    textStringBuilder.Append("pudding | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2}", price));
                    textStringBuilder.AppendLine();
                    break;
                case 8:
                    textStringBuilder.Append("eggs | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2}", price));
                    textStringBuilder.AppendLine();
                    break;
                case 9:
                    textStringBuilder.Append("butter | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2}", price));
                    textStringBuilder.AppendLine();
                    break;
                case 10:
                    textStringBuilder.Append("beef | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2}", price));
                    textStringBuilder.AppendLine();
                    break;
                case 11:
                    textStringBuilder.Append("pork | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2}", price));
                    textStringBuilder.AppendLine();
                    break;
                case 12:
                    textStringBuilder.Append("chicken | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2}", price));
                    textStringBuilder.AppendLine();
                    break;
                case 13:
                    textStringBuilder.Append("bacon | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2}", price));
                    textStringBuilder.AppendLine();
                    break;
                case 14:
                    textStringBuilder.Append("cucumbers | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2}", price));
                    textStringBuilder.AppendLine();
                    break;
                case 15:
                    textStringBuilder.Append("mushrooms | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2}", price));
                    textStringBuilder.AppendLine();
                    break;
                case 16:
                    textStringBuilder.Append("potatoes | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2}", price));
                    textStringBuilder.AppendLine();
                    break;
                case 17:
                    textStringBuilder.Append("ananas | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2}", price));
                    textStringBuilder.AppendLine();
                    break;
                case 18:
                    textStringBuilder.Append("apples | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2}", price));
                    textStringBuilder.AppendLine();
                    break;
                case 19:
                    textStringBuilder.Append("oranges | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2}", price));
                    textStringBuilder.AppendLine();
                    break;
                case 20:
                    textStringBuilder.Append("chips | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2}", price));
                    textStringBuilder.AppendLine();
                    break;
                case 21:
                    textStringBuilder.Append("fish | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2}", price));
                    textStringBuilder.AppendLine();
                    break;
                default:
                    break;
            }
        }

        string overallString = textStringBuilder.ToString();
        string textFile = @"..\..\BigProguctList.txt";
        StreamWriter streamWriter = new StreamWriter(textFile);

        using (streamWriter)
        {
            streamWriter.Write(overallString);
        }
        Console.WriteLine("The file is written!");
    }

    static int RandomNumber()
    {
        Random rnd = new Random();
        //Thread.Sleep(1);
        int random = rnd.Next(1, 22);
        return random;
    }
}
