namespace _10.Crossroads;

class Program
{
    static void Main(string[] args)
    {
        int greenLightDuration = int.Parse(Console.ReadLine());
        int freeWindowDuration = int.Parse(Console.ReadLine());

        Queue<string> cars = new Queue<string>();
        int passedCars = 0;
        
        string input = default;
        while ((input = Console.ReadLine()) != "END")
        {
            if (input != "green")
            {
                cars.Enqueue(input);
                continue;
            }

            if (cars.Count == 0) 
                continue;
            
            int currentGreen = greenLightDuration;
            while (cars.Count > 0 && currentGreen > 0)
            {
                string car = cars.Peek();
                int timeNeeded = car.Length;

                if (timeNeeded <= currentGreen)
                {
                    currentGreen -= timeNeeded;
                    cars.Dequeue();
                    passedCars++;
                }
                else
                {
                    int remaining = timeNeeded - currentGreen;
                    if (remaining <= freeWindowDuration)
                    {
                        cars.Dequeue();
                        passedCars++;
                    }
                    else
                    {
                        int hitIndex = currentGreen + freeWindowDuration;
                        
                        Console.WriteLine($"A crash happened!\n" + 
                                          $"{car} was hit at {car[hitIndex]}.");
                        return;
                    }
                    
                    break;
                }
            }
        }

        Console.WriteLine($"Everyone is safe.\n" +
                          $"{passedCars} total cars passed the crossroads.");
    }
}
