using umanage_app;

public class Ip4Address : BaseValue<string>
{
    // Constructor to initialize SystemName with a string value
    public Ip4Address(string newValue)
        : base(newValue) { }

    // Override the Value property to validate the string (ensure it's not empty or whitespace)
    public new string Value
    {
        get { return base.Value; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Ip4Address cannot be empty.");
            base.Value = value; // Use base class logic for assignment
        }
    }
}
