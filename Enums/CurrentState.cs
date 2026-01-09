namespace Enums
{
    // Enum version for type safety
    public enum EnumCurrentState
    {
        UNDEFINED,
        ACTIVE,
        STOPPED,
        PAUSED,
        FAILED,
        NOT_PRESENT,
    }

    /*
    // Old class version (commented out)
    public class ValidCurrentStates
    {
        public const string ACTIVE = "ACTIVE";
        public const string STOPPED = "STOPPED";
        public const string PAUSED = "PAUSED";
        public const string FAILED = "FAILED";
        public const string NOT_PRESENT = "NOT_PRESENT";
        public const string UNDEFINED = "UNDEFINED";

        static List<string> validStrings = new List<string>
        {
            UNDEFINED,
            ACTIVE,
            STOPPED,
            PAUSED,
            FAILED,
            NOT_PRESENT,
        };

        public static string GetValidString(string instr)
        {
            string test = instr.ToUpper().Trim();
            if (validStrings.Contains(test))
            {
                return test;
            }
            throw new ArgumentException("The string is not a valid choice.", nameof(instr));
        }
    }
    */
}
