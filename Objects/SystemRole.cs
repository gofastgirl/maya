// File: EnumSystemRole.cs
using Enums;

public class SystemRole : BaseValue<EnumSystemRole>
{
    public SystemRole(EnumSystemRole newValue)
        : base(newValue) { }

    // Custom merge logic for SystemRole
    public new void Merge(EnumSystemRole newValue)
    {
        // Example: Do not allow merging to "Undefined" status
        if (newValue == EnumSystemRole.UNDEFINED)
        {
            return; // Don't update if it's "Undefined"
        }

        base.Merge(newValue); // Call base class Merge logic
    }
}
