using System.Text;

namespace Cars;

public class Engine
{
    public Engine(string model, uint power)
    {
        Model = model;
        Power = power;
        Displacement = -1;
        Efficiency = "n/a";
    }

    public Engine(string model, uint power, int displacement)
    :this(model, power)
    {
        Displacement = displacement;
        Efficiency = "n/a";       
    }
    
    public Engine(string model, uint power, string efficiency)
        :this(model, power)
    {
        Displacement = -1;
        Efficiency = efficiency;       
    }
    public Engine(string model, uint power, int displacement, string efficiency)
    :this(model, power, displacement)
    {
        Efficiency = efficiency;
    }
    
    public string Model { get; set; }
    public uint Power { get; set; }
    public int Displacement { get; set; }
    public string Efficiency { get; set; }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"  {Model}:");
        result.AppendLine($"    Power: {Power}");

        if (Displacement == -1)
            result.AppendLine($"    Displacement: n/a");
        else 
            result.AppendLine($"    Displacement: {Displacement}");

        if (Efficiency == "n/a")
            result.Append($"    Efficiency: n/a");
        else 
            result.Append($"    Efficiency: {Efficiency}");
        
        return result.ToString();
    }
}
