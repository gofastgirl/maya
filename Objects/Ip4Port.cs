public class Ip4Port : BaseValue<int>
{
    public Ip4Port(int newValue)
        : base(newValue) { }

    // Override the Value property for additional validation (if needed)
    public new int Value
    {
        get { return base.Value; }
        set
        {
            // You can apply custom validation logic here
            if (value < 0)
                throw new ArgumentException("Ip4Port cannot be negative.");
            base.Value = value; // Use base class logic
        }
    }
}
