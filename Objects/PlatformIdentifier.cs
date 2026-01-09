// File: EnumPlatformIdentifier.cs
using Enums;

public class PlatformIdentifier : BaseValue<EnumPlatformIdentifier>
{
    public PlatformIdentifier(EnumPlatformIdentifier newValue)
        : base(newValue) { }

    // Custom merge logic for PlatformIdentifier
    public new void Merge(EnumPlatformIdentifier newValue)
    {
        // Example: Do not allow merging to "Undefined" status
        if (newValue == EnumPlatformIdentifier.UNDEFINED)
        {
            return; // Don't update if it's "Undefined"
        }

        base.Merge(newValue); // Call base class Merge logic
    }
}
