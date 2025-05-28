using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = Path.Combine("..", "..", "..", "text.txt");
            string outputFilePath = Path.Combine("..", "..", "..", "output.txt");

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            
            for (int i = 0; i < lines.Length; i++)
            {
                string currentLine = lines[i];
                int lettersCount = 0,
                    puntuationCount = 0;
                
                foreach (char symbol in currentLine)
                {
                    if (char.IsLetter(symbol))
                        lettersCount++;
                    else if (char.IsPunctuation(symbol))
                        puntuationCount++;
                }

                lines[i] = $"Line {i + 1}: {lines[i]} ({lettersCount})({puntuationCount})";
            }
            
            File.WriteAllLines(outputFilePath, lines);
        }
    }
}
