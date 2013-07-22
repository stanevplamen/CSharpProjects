using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class RecurciveFolderSearch
{
    static void DirSearch(string sDir)
    {
        try
        {
            foreach (string directory in Directory.GetDirectories(sDir))
            {
                Console.WriteLine(directory);
                DirSearch(directory);
            }
            foreach (string file in Directory.GetFiles(sDir))
            {
                Console.WriteLine(file);
            }
        }
        catch (System.Exception exc)
        {
            Console.WriteLine(exc.Message);
        }
    }

    static void Main(string[] args)
    {
        DirSearch("C:\\ATI");
    }
}



