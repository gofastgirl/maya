// File: OsType.cs
using Enums;

public class OsType : BaseValue<EnumOsType>
{
    public OsType(EnumOsType newValue)
        : base(newValue) { }

    // Custom merge logic for OsType
    public new void Merge(EnumOsType newValue)
    {
        // Example: Do not allow merging to "Undefined" status
        if (newValue == EnumOsType.UNDEFINED)
        {
            return; // Don't update if it's "Undefined"
        }

        base.Merge(newValue); // Call base class Merge logic
    }
}
