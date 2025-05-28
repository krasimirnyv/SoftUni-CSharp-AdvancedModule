using System;
using System.IO;
using System.Linq;
using System.Text;

namespace EvenLines
{
    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = Path.Combine("..", "..", "..", "text.txt");

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using StreamReader reader = new StreamReader(inputFilePath);
            
            StringBuilder result = new StringBuilder();
            bool isEven = true;
            while (!reader.EndOfStream)
            {
                string currentLine = reader.ReadLine();
                if (isEven)
                {
                    string[] words = currentLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    result.Append(string.Join(' ', words.Select(x => ReplacePuntuation(x)).Reverse()));
                }

                isEven = !isEven;
            }

            return result.ToString();
        }

        private static string ReplacePuntuation(string word)
        {
            string result = word;
            foreach (char characterToReplace in punctuatuion)
            {
                result = result.Replace(characterToReplace, replacement);
            }

            return result;
        }

        private static readonly char[] punctuatuion = new char[] { '-', ',', '.', '!', '?' };
        private const char replacement = '@';
    }
}
