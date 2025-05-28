using System.IO.Compression;

namespace ZipAndExtract
{
    using System;
    using System.IO;
    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFile = Path.Combine("..", "..", "..", "copyMe.png");
            string zipArchiveFile = Path.Combine("..", "..", "..", "archive.zip");
            string extractedFile = Path.Combine("..", "..", "..", "extracted.png");
            
            ZipFileToArchive(inputFile, zipArchiveFile);

            string fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            if (File.Exists(zipArchiveFilePath))
                File.Delete(zipArchiveFilePath);
            
            using ZipArchive archive = ZipFile.Open(inputFilePath, ZipArchiveMode.Create);

            string inputFileName = Path.GetFileName(inputFilePath);
            archive.CreateEntryFromFile(inputFilePath, inputFileName);
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            using ZipArchive archive = ZipFile.OpenRead(zipArchiveFilePath);
            ZipArchiveEntry entry = archive.GetEntry(fileName);
            entry.ExtractToFile(outputFilePath, overwrite: true);
        }
    }
}
