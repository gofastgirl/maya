// File: EnumSystemFunction.cs
using Enums;

public class SystemFunction : BaseValue<EnumSystemFunction>
{
    public SystemFunction(EnumSystemFunction newValue)
        : base(newValue) { }

    // Custom merge logic for SystemFunction
    public new void Merge(EnumSystemFunction newValue)
    {
        // Example: Do not allow merging to "Undefined" status
        if (newValue == EnumSystemFunction.UNDEFINED)
        {
            return; // Don't update if it's "Undefined"
        }

        base.Merge(newValue); // Call base class Merge logic
    }
}
