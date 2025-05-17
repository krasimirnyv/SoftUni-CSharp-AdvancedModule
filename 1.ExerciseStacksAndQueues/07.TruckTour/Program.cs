namespace _07.TruckTour;

class Program
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());

        Queue<(int petrol, int distance)> pumps = new Queue<(int, int)>();
        
        for (int i = 0; i < lines; i++)
        {
            int[] data = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            int petrol = data[0], distance = data[1];
            pumps.Enqueue((petrol, distance));
        }
        
        int startIndex = 0;
        while (startIndex < lines)
        {
            int fuel = 0;
            bool completedTour = true;

            foreach ((int petrol, int distance) pump in pumps)
            {
                fuel += pump.petrol;

                if (fuel < pump.distance)
                {
                    completedTour = false;
                    break;
                }

                fuel -= pump.distance;
            }

            if (completedTour)
            {
                Console.WriteLine(startIndex);
                break;
            }
            
            pumps.Enqueue(pumps.Dequeue());
            startIndex++;
        }
    }
}