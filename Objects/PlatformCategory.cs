// File: EnumPlatformCategory.cs
using Enums;

public class PlatformCategory : BaseValue<EnumPlatformCategory>
{
    public PlatformCategory(EnumPlatformCategory newValue)
        : base(newValue) { }

    // Custom merge logic for PlatformCategory
    public new void Merge(EnumPlatformCategory newValue)
    {
        // Example: Do not allow merging to "Undefined" status
        if (newValue == EnumPlatformCategory.UNDEFINED)
        {
            return; // Don't update if it's "Undefined"
        }

        base.Merge(newValue); // Call base class Merge logic
    }
}
