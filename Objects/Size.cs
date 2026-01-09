using umanage_app;

public class Size : BaseValue<long>
{
    // Constructor to initialize Size with a long value
    public Size(long newValue)
        : base(newValue) { }

    // Override the Value property if needed for additional validation
    public new long Value
    {
        get { return base.Value; }
        set
        {
            if (value == 0)
                throw new ArgumentException("Size cannot be zero.");
            base.Value = value; // Use base class logic for assignment
        }
    }
}
