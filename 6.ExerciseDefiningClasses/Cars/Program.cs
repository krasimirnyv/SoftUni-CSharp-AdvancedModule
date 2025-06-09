namespace Cars;

class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
        
        int lines = int.Parse(Console.ReadLine());
        while (lines-- > 0)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Engine engine = default;
            string model = input[0];
            uint power = uint.Parse(input[1]);
            switch (input.Length)
            {
                case 3:
                    int displacement = default;
                    string efficiency = default;
                    
                    bool isInt = int.TryParse(input[2], out displacement);
                    if (!isInt)
                        efficiency = input[2];

                    if (displacement != default) 
                        engine = new Engine(model, power, displacement);
                    else if (efficiency != default)
                        engine = new Engine(model, power, efficiency);
                    
                    break;
                case 4:
                    displacement = int.Parse(input[2]);
                    efficiency = input[3];
                    engine = new Engine(model, power, displacement, efficiency);
                    break;
                default:
                    engine = new Engine(model, power);
                    break;
            }
            
            engines.Add(model, engine);
        }
        
        lines = int.Parse(Console.ReadLine());
        while (lines-- > 0)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Car car  = default;
            string model = input[0];
            string engineModel = input[1];
            switch (input.Length)
            {
                case 3:
                    int weight = default;
                    string color = default;
                    
                    bool isInt = int.TryParse(input[2], out weight);
                    if (!isInt)
                        color = input[2];

                    if (weight != default) 
                        car = new Car(model, engines[engineModel], weight);
                    else if (color != default)
                        car = new Car(model, engines[engineModel], color);
                    
                    break;
                case 4:
                    weight = int.Parse(input[2]); 
                    color = input[3];
                    car = new Car(model, engines[engineModel], weight, color);
                    break;
                default:
                    car = new Car(model, engines[engineModel]);
                    break;
            }
            
            cars.Add(car);
        }

        foreach (Car car in cars)
            Console.WriteLine(car);
    }
}
