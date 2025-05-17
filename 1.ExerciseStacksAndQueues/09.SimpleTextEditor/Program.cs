using System.Text;

namespace _09.SimpleTextEditor;

class Program
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        
        StringBuilder text = new StringBuilder();
        Stack<string> history = new Stack<string>();
        
        for (int i = 0; i < lines; i++)
        {
            string[] data = Console.ReadLine().Split();

            string command = data[0];
            switch (command)
            {
                case "1":
                    string addText = data[1];
                    history.Push(text.ToString());
                    text.Append(addText);
                    break;
                
                case "2":
                    int count = int.Parse(data[1]);
                    history.Push(text.ToString());
                    text.Remove(text.Length - count, count);
                    break;
                
                case "3":
                    int index = int.Parse(data[1]) - 1;
                    Console.WriteLine(text[index]);
                    break;
                
                case "4":
                    if (history.Count > 0)
                        text = new StringBuilder(history.Pop());
                    break;
            }
        }
    }
}
