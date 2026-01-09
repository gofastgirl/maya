// File: EnumExpectedState.cs
using Enums;

public class ExpectedState : BaseValue<EnumExpectedState>
{
    public ExpectedState(EnumExpectedState newValue)
        : base(newValue) { }

    // Custom merge logic for ExpectedState
    public new void Merge(EnumExpectedState newValue)
    {
        // Example: Do not allow merging to "Undefined" status
        if (newValue == EnumExpectedState.UNDEFINED)
        {
            return; // Don't update if it's "Undefined"
        }

        base.Merge(newValue); // Call base class Merge logic
    }
}
