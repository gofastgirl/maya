using umanage_app;

public class ParentName : BaseValue<string>
{
    // Constructor to initialize SystemName with a string value
    public ParentName(string newValue)
        : base(newValue) { }

    // Override the Value property to validate the string (ensure it's not empty or whitespace)
    public new string Value
    {
        get { return base.Value; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("ParentName cannot be empty.");
            base.Value = value; // Use base class logic for assignment
        }
    }
}
