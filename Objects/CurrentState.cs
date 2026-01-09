// File: EnumCurrentState.cs
using Enums;

public class CurrentState : BaseValue<EnumCurrentState>
{
    public CurrentState(EnumCurrentState newValue)
        : base(newValue) { }

    // Custom merge logic for CurrentState
    public new void Merge(EnumCurrentState newValue)
    {
        // Example: Do not allow merging to "Undefined" status
        if (newValue == EnumCurrentState.UNDEFINED)
        {
            return; // Don't update if it's "Undefined"
        }

        base.Merge(newValue); // Call base class Merge logic
    }
}
