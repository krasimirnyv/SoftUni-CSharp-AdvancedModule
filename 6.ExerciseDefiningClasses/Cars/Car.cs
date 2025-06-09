using System.Text;

namespace Cars;

public class Car
{
    public Car(string model, Engine engine)
    {
        Model = model;
        Engine = engine;
        Weight = -1;
        Color = "n/a";       
    }
    
    public Car(string model, Engine engine, int weight)
        :this(model, engine)
    {
        Weight = weight;
        Color = "n/a";
    }
    
    public Car(string model, Engine engine, string color)
        :this(model, engine)
    {
        Weight = -1;
        Color = color;
    }
    
    public Car(string model, Engine engine, int weight, string color)
    :this(model, engine, weight)
    {
        Color = color;
    }

    public string Model { get; set; }
    public Engine Engine { get; set; }
    public int Weight { get; set; }
    public string Color { get; set; }
    
    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"{Model}:");
        result.AppendLine($"{Engine}");
        
        if (Weight == -1)
            result.AppendLine($"  Weight: n/a");
        else 
            result.AppendLine($"  Weight: {Weight}");

        if (Color == "n/a")
            result.Append($"  Color: n/a");
        else 
            result.Append($"  Color: {Color}");
        
        return result.ToString();
    }
}
