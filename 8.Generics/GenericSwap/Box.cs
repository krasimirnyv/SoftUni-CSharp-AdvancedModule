namespace GenericBox;

public class Box<TValue>
{
    public TValue Value { get; set; }

    public Box(TValue value)
    {
        this.Value = value;
    }

    public override string ToString()
        => $"{typeof(TValue).FullName}: {Value}";
}