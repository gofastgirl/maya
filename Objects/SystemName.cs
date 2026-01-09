using umanage_app;

public class SystemName : BaseValue<string>
{
    // Constructor to initialize SystemName with a string value
    public SystemName(string newValue)
        : base(newValue) { }

    // Override the Value property to validate the string (ensure it's not empty or whitespace)
    public new string Value
    {
        get { return base.Value; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("SystemName cannot be empty.");
            base.Value = value; // Use base class logic for assignment
        }
    }

    public void Merge(string newValue)
    {
        if (string.IsNullOrWhiteSpace(newValue))
        {
            return; // Don't update if the new value is empty or whitespace
        }

        base.Merge(newValue); // Call base class Merge logic
    }
}
