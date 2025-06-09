namespace Cars;

public class Tires
{ 
    public Tires(double pressure, uint age)
    {
        Pressure = pressure;
        Age = age;
    }
    public double Pressure { get; set; }
    public uint Age { get; set; }
}