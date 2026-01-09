using System.ComponentModel.Design;

namespace Enums
{
    // Enum version
    public enum EnumExpectedState
    {
        UNDEFINED,
        ACTIVE,
        DECOMMISSIONING,
        MAINTENANCE,
        DISABLED,
        RETIRED,
        REDUNDANT_ONLINE,
        REDUNDANT_OFFLINE,
        STANDBY_ONLINE,
        STANDBY_OFFLINE,
        RESEARCHING,
        TESTING,
        BACKUP,
        ARCHIVAL,
        DEPRECATED,
        UNDER_REPAIR,
        SUSPENDED,
    }

    /*
    // Old class version (commented out)
    public class ValidExpectedStates
    {
        public const string UNDEFINED = "UNDEFINED";
        public const string ACTIVE = "ACTIVE";
        public const string DECOMMISSIONING = "DECOMMISSIONING";
        public const string MAINTENANCE = "MAINTENANCE";
        public const string DISABLED = "DISABLED";
        public const string RETIRED = "RETIRED";
        public const string REDUNDANT_ONLINE = "REDUNDANT_ONLINE";
        public const string REDUNDANT_OFFLINE = "REDUNDANT_OFFLINE";
        public const string STANDBY_ONLINE = "STANDBY_ONLINE";
        public const string STANDBY_OFFLINE = "STANDBY_OFFLINE";
        public const string RESEARCHING = "RESEARCHING";
        public const string TESTING = "TESTING";
        public const string BACKUP = "BACKUP";
        public const string ARCHIVAL = "ARCHIVAL";
        public const string DEPRECATED = "DEPRECATED";
        public const string UNDER_REPAIR = "UNDER_REPAIR";
        public const string SUSPENDED = "SUSPENDED";

        static List<string> validStrings = new List<string>
        {
            UNDEFINED,
            ACTIVE,
            DECOMMISSIONING,
            MAINTENANCE,
            DISABLED,
            RETIRED,
            REDUNDANT_ONLINE,
            REDUNDANT_OFFLINE,
            STANDBY_ONLINE,
            STANDBY_OFFLINE,
            RESEARCHING,
            TESTING,
            BACKUP,
            ARCHIVAL,
            DEPRECATED,
            UNDER_REPAIR,
            SUSPENDED,
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
