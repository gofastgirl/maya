// File: EnumSystemAttribute.cs
using Enums;

public class SystemAttribute : BaseValue<EnumSystemAttribute>
{
    public SystemAttribute(EnumSystemAttribute newValue)
        : base(newValue) { }

    // Custom merge logic for SystemAttribute
    public new void Merge(EnumSystemAttribute newValue)
    {
        // Example: Do not allow merging to "Undefined" status
        if (newValue == EnumSystemAttribute.UNDEFINED)
        {
            return; // Don't update if it's "Undefined"
        }

        base.Merge(newValue); // Call base class Merge logic
    }
}
