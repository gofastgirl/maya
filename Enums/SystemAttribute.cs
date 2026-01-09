namespace Enums
{
    public enum EnumSystemAttribute
    {
        UNDEFINED,
        NAME_UNIQUE, // read only, name_system + ip4_address + ip4_port
        NAME_SYSTEM, // name of the system
        WHICH_SYSTEM, // which system identified/discovered this system
        NAME_PARENT, // parent system (if any)
        FUNCTION, // what kind of tasks this system takes care of
        OS_TYPE,
        TYPE,
        STATE,
        STATUS,
        REASON,
        NOTES,
        RESERVATION,
        IP4_ADDRESS,
        IP4_PORT,
        IP6_ADDRESS,
        MAC_ADDRESS,
        LINK_WEB,
        LINK_SSH,
        LINK_VNC,
        LINK_RDP,
        EXPECTED_STATE,
        STATE_DHCP,
        WHICH_DHCP,
        STATE_DNS,
        WHICH_DNS,
        STATE_VIRTUAL,
        WHICH_VIRTUAL,
        ID_VIRTUAL,
        STATE_MONITOR,
        WHICH_MONITOR,
        STATE_ASSET,
        WHICH_ASSET,
        STATE_BOOK,
        WHICH_BOOK,
        CPU_COUNT,
        RAM_MAX,
        RAM_USED,
        STORAGE_MAX,
        STORAGE_USED,
        SWAP_MAX,
        SWAP_USED,
        BUTTON_START,
        BUTTON_STOP,
        BUTTON_DELETE,
        BUTTON_RENAME,
        LAST_INDEX,
    }

    /*
    public class ValidSystemAttributes
    {
        public const string NAME_UNIQUE = "NAME_UNIQUE"; // read only, name_system + ip4_address + ip4_port
        public const string NAME_SYSTEM = "NAME_SYSTEM"; // name of the system
        public const string WHICH_SYSTEM = "WHICH_SYSTEM"; // which system identified/discovered this system
        public const string NAME_PARENT = "NAME_PARENT"; // parent system (if any)
        public const string FUNCTION = "FUNCTION"; // what kind of tasks this system takes care of
        public const string OS_TYPE = "OS_TYPE";
        public const string TYPE = "TYPE";
        public const string STATE = "STATE";
        public const string STATUS = "STATUS";
        public const string REASON = "REASON";
        public const string NOTES = "NOTES";
        public const string RESERVATION = "RESERVATION";
        public const string IP4_ADDRESS = "IP4_ADDRESS";
        public const string IP4_PORT = "IP4_PORT";
        public const string IP6_ADDRESS = "IP6_ADDRESS";
        public const string MAC_ADDRESS = "MAC_ADDRESS";
        public const string LINK_WEB = "LINK_WEB";
        public const string LINK_SSH = "LINK_SSH";
        public const string LINK_VNC = "LINK_VNC";
        public const string LINK_RDP = "LINK_RDP";
        public const string EXPECTED_STATE = "EXPECTED_STATE";
        public const string STATE_DHCP = "STATE_DHCP";
        public const string WHICH_DHCP = "WHICH_DHCP";
        public const string STATE_DNS = "STATE_DNS";
        public const string WHICH_DNS = "WHICH_DNS";
        public const string STATE_VIRTUAL = "STATE_VIRTUAL";
        public const string WHICH_VIRTUAL = "WHICH_VIRTUAL";
        public const string ID_VIRTUAL = "ID_VIRTUAL";
        public const string STATE_MONITOR = "STATE_MONITOR";
        public const string WHICH_MONITOR = "WHICH_MONITOR";
        public const string STATE_ASSET = "STATE_ASSET";
        public const string WHICH_ASSET = "WHICH_ASSET";
        public const string STATE_BOOK = "STATE_BOOK";
        public const string WHICH_BOOK = "WHICH_BOOK";
        public const string CPU_COUNT = "CPU_COUNT";
        public const string RAM_MAX = "RAM_MAX";
        public const string RAM_USED = "RAM_USED";
        public const string STORAGE_MAX = "STORAGE_MAX";
        public const string STORAGE_USED = "STORAGE_USED";
        public const string SWAP_MAX = "SWAP_MAX";
        public const string SWAP_USED = "SWAP_USED";
        public const string BUTTON_START = "BUTTON_START";
        public const string BUTTON_STOP = "BUTTON_STOP";
        public const string BUTTON_DELETE = "BUTTON_DELETE";
        public const string BUTTON_RENAME = "BUTTON_RENAME";
        public const string LAST_INDEX = "LAST_INDEX";

        private static readonly List<string> validStrings = new List<string>
        {
            NAME_UNIQUE,
            NAME_SYSTEM,
            WHICH_SYSTEM,
            NAME_PARENT,
            FUNCTION,
            OS_TYPE,
            TYPE,
            STATE,
            STATUS,
            REASON,
            NOTES,
            RESERVATION,
            IP4_ADDRESS,
            IP4_PORT,
            IP6_ADDRESS,
            MAC_ADDRESS,
            LINK_WEB,
            LINK_SSH,
            LINK_VNC,
            LINK_RDP,
            EXPECTED_STATE,
            STATE_DHCP,
            WHICH_DHCP,
            STATE_DNS,
            WHICH_DNS,
            STATE_VIRTUAL,
            WHICH_VIRTUAL,
            ID_VIRTUAL,
            STATE_MONITOR,
            WHICH_MONITOR,
            STATE_ASSET,
            WHICH_ASSET,
            STATE_BOOK,
            WHICH_BOOK,
            CPU_COUNT,
            RAM_MAX,
            RAM_USED,
            STORAGE_MAX,
            STORAGE_USED,
            SWAP_MAX,
            SWAP_USED,
            BUTTON_START,
            BUTTON_STOP,
            BUTTON_DELETE,
            BUTTON_RENAME,
            LAST_INDEX,
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
