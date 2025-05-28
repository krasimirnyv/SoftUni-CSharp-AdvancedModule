using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace DirectoryTraversal
{
    using System;
    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Path.Combine(Console.ReadLine());
            string reportFileName = "report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(inputFolderPath);
           
            // extensions -> list of files
            Dictionary<string, List<FileInfo>> filesByExtension = new Dictionary<string, List<FileInfo>>();
            
            foreach (FileInfo file in directoryInfo.EnumerateFiles())
            {
                if (!filesByExtension.ContainsKey(file.Extension))
                {
                    filesByExtension[file.Extension] = new List<FileInfo>();
                }
                
                filesByExtension[file.Extension].Add(file);
            }

            StringBuilder result = new StringBuilder();
            foreach (var (extension, files) in filesByExtension
                         .OrderByDescending(x => x.Value.Count)
                         .ThenBy(x => x.Key))
            {
                result.AppendLine(extension);
                foreach (FileInfo file in files.OrderBy(x => x.Length))
                {
                    double fileSizeInKb = file.Length / 1024.0;
                    result.AppendLine($"--{file.Name} - {fileSizeInKb}kb");
                }
            }

            return result.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string pathToDesctop = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
            string fullPathToReport = Path.Combine(pathToDesctop, reportFileName);
            
            File.WriteAllText(fullPathToReport, textContent);
        }
    }
}
