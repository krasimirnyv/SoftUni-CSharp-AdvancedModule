namespace Cars;

public class Cargo
{
    public Cargo(uint weight, string type)
    {
        Weight = weight;
        Type = type;
    }

    public uint Weight { get; set; }
    public string Type { get; set; }
}