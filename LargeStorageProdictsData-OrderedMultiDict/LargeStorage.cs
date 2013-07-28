using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using Wintellect.PowerCollections;

class LargeStorage
{
    static OrderedMultiDictionary<decimal, Article> productsCatalog;

    static void Main()
    {
        // 1. generate a text file
        LoadTextFile();

        // 2. fill the bag
        FillingTheBag();
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("bg-BG");

        // 3. test for price search
        Console.WriteLine("Providing the searches, please wait..");
        StreamWriter streamWriter = new StreamWriter(@"..\..\OutputProductsLists.txt");
        int testsCount = 2; // cound be more than 100 000 searches
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

    #region RangeSearch
    private static void TestForPriceSearches(int lower, int upper, StreamWriter streamWriter)
    {
        var result = productsCatalog.Range( lower,  true,  upper, true);
        // you can uncomment for printing but reduce the testsCount number
        streamWriter.WriteLine("===========================new search============================");
        foreach (var pair in result)
        {
            foreach (var product in pair.Value)
            {
                streamWriter.WriteLine("{0} {1:C2} {2} {3}", product.Title, product.Price, product.Vendor, product.Barcode);
                //Console.WriteLine("{0} {1:C2} {2} {3}", product.Title, product.Price, product.Vendor, product.Barcode);
            }
        }
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
    #endregion

    #region FillTheBag
    private static void fillTheBagWithProducts(string product, decimal price, string vendor, string barcode)
    {
        productsCatalog.Add(price, new Article(product, price, vendor, barcode));
    }

    private static void FillingTheBag()
    {
        Console.Write("Filing the bag, please wait... ");
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("nl-NL");
        productsCatalog = new OrderedMultiDictionary<decimal, Article>(true);
        StreamReader reader = new StreamReader(@"..\..\BigProguctList.txt");
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] items = line.Split('|');

                string product = items[0].Trim(' ');
                string vendor = items[3].Trim(' ');
                string barcode = items[2].Trim(' ');
                string[] priceItems = items[1].Trim().Split(' ');
                decimal price = decimal.Parse(priceItems[0].Trim());

                fillTheBagWithProducts(product, price, vendor, barcode);
                line = reader.ReadLine();
            }
        }
        Console.WriteLine("Done");
    }
    #endregion

    #region TextFileGeneration
    static void LoadTextFile()
    {
        Console.WriteLine("Writing a text file with 1 000 000 products, please wait...");
        ulong rows = 1000000; //ulong.Parse(Console.ReadLine());
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
                    textStringBuilder.Append(string.Format("{0:C2} | {1} |   SomeCompanyName", price, RandomNumberBarcode()));
                    textStringBuilder.AppendLine();
                    break;
                case 2:
                    textStringBuilder.Append("sugar | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2} | {1} |   SomeCompanyName", price, RandomNumberBarcode()));
                    textStringBuilder.AppendLine();
                    break;
                case 3:
                    textStringBuilder.Append("ice cream | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2} | {1} |   SomeCompanyName", price, RandomNumberBarcode()));
                    textStringBuilder.AppendLine();
                    break;
                case 4:
                    textStringBuilder.Append("cheese | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2} | {1} |   SomeCompanyName", price, RandomNumberBarcode()));
                    textStringBuilder.AppendLine();
                    break;
                case 5:
                    textStringBuilder.Append("pork meat | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2} | {1} |   SomeCompanyName", price, RandomNumberBarcode()));
                    textStringBuilder.AppendLine();
                    break;
                case 6:
                    textStringBuilder.Append("yogurt | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2} | {1} |   SomeCompanyName", price, RandomNumberBarcode()));
                    textStringBuilder.AppendLine();
                    break;
                case 7:
                    textStringBuilder.Append("pudding | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2} | {1} |   SomeCompanyName", price, RandomNumberBarcode()));
                    textStringBuilder.AppendLine();
                    break;
                case 8:
                    textStringBuilder.Append("eggs | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2} | {1} |   SomeCompanyName", price, RandomNumberBarcode()));
                    textStringBuilder.AppendLine();
                    break;
                case 9:
                    textStringBuilder.Append("butter | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2} | {1} |   SomeCompanyName", price, RandomNumberBarcode()));
                    textStringBuilder.AppendLine();
                    break;
                case 10:
                    textStringBuilder.Append("beef | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2} | {1} |   SomeCompanyName", price, RandomNumberBarcode()));
                    textStringBuilder.AppendLine();
                    break;
                case 11:
                    textStringBuilder.Append("pork | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2} | {1} |   SomeCompanyName", price, RandomNumberBarcode()));
                    textStringBuilder.AppendLine();
                    break;
                case 12:
                    textStringBuilder.Append("chicken | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2} | {1} |   SomeCompanyName", price, RandomNumberBarcode()));
                    textStringBuilder.AppendLine();
                    break;
                case 13:
                    textStringBuilder.Append("bacon | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2} | {1} |   SomeCompanyName", price, RandomNumberBarcode()));
                    textStringBuilder.AppendLine();
                    break;
                case 14:
                    textStringBuilder.Append("cucumbers | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2} | {1} |   SomeCompanyName", price, RandomNumberBarcode()));
                    textStringBuilder.AppendLine();
                    break;
                case 15:
                    textStringBuilder.Append("mushrooms | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2} | {1} |   SomeCompanyName", price, RandomNumberBarcode()));
                    textStringBuilder.AppendLine();
                    break;
                case 16:
                    textStringBuilder.Append("potatoes | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2} | {1} |   SomeCompanyName", price, RandomNumberBarcode()));
                    textStringBuilder.AppendLine();
                    break;
                case 17:
                    textStringBuilder.Append("ananas | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2} | {1} |   SomeCompanyName", price, RandomNumberBarcode()));
                    textStringBuilder.AppendLine();
                    break;
                case 18:
                    textStringBuilder.Append("apples | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2} | {1} |   SomeCompanyName", price, RandomNumberBarcode()));
                    textStringBuilder.AppendLine();
                    break;
                case 19:
                    textStringBuilder.Append("oranges | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2} | {1} |   SomeCompanyName", price, RandomNumberBarcode()));
                    textStringBuilder.AppendLine();
                    break;
                case 20:
                    textStringBuilder.Append("chips | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2} | {1} |   SomeCompanyName", price, RandomNumberBarcode()));
                    textStringBuilder.AppendLine();
                    break;
                case 21:
                    textStringBuilder.Append("fish | "); price = (RandomNumber() / 2.38m);
                    textStringBuilder.Append(string.Format("{0:C2} | {1} |   SomeCompanyName", price, RandomNumberBarcode()));
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

    static int RandomNumberBarcode()
    {
        Random rnd = new Random();
        //Thread.Sleep(1);
        int random = rnd.Next(100000000, 900000000);
        return random;
    }
    #endregion
}

