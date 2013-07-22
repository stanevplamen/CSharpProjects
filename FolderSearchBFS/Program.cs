using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class TraverseDir
{
    static void Main(string[] args)
    {
        string[] interestingDirNames = {
            "microsoft",
            "dx",
            "directx",
            "sdk",
            "utilities",
            "bin",
            "x86" };

        List<string> startDirs = new List<string>();

        startDirs.Add(@"c:\ATI");

        string result = IntelligentSearch(
            "plm_supertap.txt",
            false,
            interestingDirNames,
            startDirs.ToArray(),
            TimeSpan.FromMilliseconds(50000.0));
    }

    public static string IntelligentSearch(
        string targetName, bool targetIsDirectory,
        string[] interestingDirNames, string[] startDirs, TimeSpan timeout)
    {
        DateTime endTime = DateTime.Now + timeout;

        // Paths to process
        LinkedList<string> PathQueue = new LinkedList<string>();
        // Path already processed in form Key=Path, Value="1"
        System.Collections.Specialized.StringDictionary Processed =
            new System.Collections.Specialized.StringDictionary();

        foreach (string startDir in startDirs)
            PathQueue.AddLast(startDir);

        // Processing loop - berform breadth first search (BFS) algorithm
        while (PathQueue.Count > 0)
        {
            // Get directory to process
            string Dir = PathQueue.First.Value;
            //  get and write filenames
            DirectoryInfo directory = new DirectoryInfo(Dir);
            FileInfo[] files = directory.GetFiles();
            for (int index = 0; index < files.Length; index++)
            {
                Console.WriteLine(files[index].FullName);
            }
            
            //
            Console.WriteLine(Dir);
            PathQueue.RemoveFirst();
            // Already processed
            if (Processed.ContainsKey(Dir))
                continue;
            // Add to processed
            Processed.Add(Dir, "1");

            try
            {
                string targetPath = Path.Combine(Dir, targetName);
                if (targetIsDirectory)
                {
                    if (Directory.Exists(targetPath))
                        return targetPath;
                }
                else
                {
                    if (File.Exists(targetPath))
                        return targetPath;
                }

                foreach (string SubDir in Directory.GetDirectories(Dir))
                {
                    bool dirIsInteresting = false;
                    if (interestingDirNames != null && interestingDirNames.Length > 0)
                    {
                        string subDirName = Path.GetFileName(SubDir);
                        foreach (string interestingName in interestingDirNames)
                        {
                            if (subDirName.IndexOf(interestingName, StringComparison.InvariantCultureIgnoreCase) != -1)
                            {
                                dirIsInteresting = true;
                                break;
                            }
                        }
                    }

                    if (dirIsInteresting)
                        PathQueue.AddFirst(SubDir);
                    else
                        PathQueue.AddLast(SubDir);
                }
            }
            catch (Exception) { }

            if (DateTime.Now > endTime)
                return null;
        }
        return null;
    }
}


