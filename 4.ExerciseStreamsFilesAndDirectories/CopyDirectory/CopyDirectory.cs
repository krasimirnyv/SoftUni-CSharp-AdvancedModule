using System;
using System.IO;

namespace CopyDirectory
{
    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath =  Console.ReadLine();
            string outputPath = Console.ReadLine();

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath)) 
                Directory.Delete(outputPath, true);
            
            Directory.CreateDirectory(outputPath);
            
            foreach (var pathToSourceFile in Directory.EnumerateFiles(inputPath))
            {
                string fileName = Path.GetFileName(pathToSourceFile);
                string pathToDestinationFile = Path.Combine(outputPath, fileName);
                
                File.Copy(pathToSourceFile, pathToDestinationFile);
            }
        }
    }
}
