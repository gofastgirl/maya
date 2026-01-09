namespace Enums
{
    public enum EnumSystemFunction
    {
        UNDEFINED,
        NETWORK,
        ASSETS,
        IDENTITY,
        AUTHENTICATION,
        MONITORING,
        PROJECT,
        STORAGE,
        KNOWLEDGE,
        REMOTE_ACCESS,
        BOOKMARK,
        AUTOMATION,
        DASHBOARD,
        VIRTUALIZATION,
        LEARNING,
        MEDIA,
        DATABASE,
        DEVELOPMENT,
        DEVICE,
        ANALYTICS,
        BACKUPS,
        CALENDAR,
        EMAIL,
        COMM_TEXT,
        COMM_VIDEO,
        CONT_INTEGRATION,
        CONT_DEPLOYMENT,
        DIAGRAMS,
        DOCUMENTATION,
        FINANCE,
        GAMING,
        PHOTOS,
        SOCIAL,
        SYNCING,
        RSS,
        FIREWALL,
        SWITCH,
        DNS,
        DHCP,
        NOTES,
        ADBLOCK,
        CUSTOMER_RELATIONSHIP,
        ENT_RELATIONSHIP,
        CONTENT,
        WEB_SERVICES,
    }

    /*
    public class ValidFunctions
    {
        public const string UNDEFINED = "UNDEFINED";
        public const string NETWORK = "NETWORK";
        public const string ASSETS = "ASSETS";
        public const string IDENTITY = "IDENTITY";
        public const string AUTHENTICATION = "AUTHENTICATION";
        public const string MONITORING = "MONITORING";
        public const string PROJECT = "PROJECT";
        public const string STORAGE = "STORAGE";
        public const string KNOWLEDGE = "KNOWLEDGE";
        public const string REMOTE_ACCESS = "REMOTE_ACCESS";
        public const string BOOKMARK = "BOOKMARK";
        public const string AUTOMATION = "AUTOMATION";
        public const string DASHBOARD = "DASHBOARD";
        public const string VIRTUALIZATION = "VIRTUALIZATION";
        public const string LEARNING = "LEARNING";
        public const string MEDIA = "MEDIA";
        public const string DATABASE = "DATABASE";
        public const string DEVELOPMENT = "DEVELOPMENT";
        public const string DEVICE = "DEVICE";
        public const string ANALYTICS = "ANALYTICS";
        public const string BACKUPS = "BACKUPS";
        public const string CALENDAR = "CALENDAR";
        public const string EMAIL = "EMAIL";
        public const string COMM_TEXT = "COMM_TEXT";
        public const string COMM_VIDEO = "COMM_VIDEO";
        public const string CONT_INTEGRATION = "CONT_INTEGRATION";
        public const string CONT_DEPLOYMENT = "CONT_DEPLOYMENT";
        public const string DIAGRAMS = "DIAGRAMS";
        public const string DOCUMENTATION = "DOCUMENTATION";
        public const string FINANCE = "FINANCE";
        public const string GAMING = "GAMING";
        public const string PHOTOS = "PHOTOS";
        public const string SOCIAL = "SOCIAL";
        public const string SYNCING = "SYNCING";
        public const string RSS = "RSS";
        public const string FIREWALL = "FIREWALL";
        public const string SWITCH = "SWITCH";
        public const string DNS = "DNS";
        public const string DHCP = "DHCP";
        public const string NOTES = "NOTES";
        public const string ADBLOCK = "ADBLOCK";
        public const string CUSTOMER_RELATIONSHIP = "CUSTOMER_RELATIONSHIP";
        public const string ENT_RELATIONSHIP = "ENT_RELATIONSHIP";
        public const string CONTENT = "CONTENT";
        public const string WEB_SERVICES = "WEB_SERVICES";

        private static readonly List<string> validStrings = new List<string>
        {
            UNDEFINED,
            NETWORK,
            ASSETS,
            IDENTITY,
            AUTHENTICATION,
            MONITORING,
            PROJECT,
            STORAGE,
            KNOWLEDGE,
            REMOTE_ACCESS,
            BOOKMARK,
            AUTOMATION,
            DASHBOARD,
            VIRTUALIZATION,
            LEARNING,
            MEDIA,
            DATABASE,
            DEVELOPMENT,
            DEVICE,
            ANALYTICS,
            BACKUPS,
            CALENDAR,
            EMAIL,
            COMM_TEXT,
            COMM_VIDEO,
            CONT_INTEGRATION,
            CONT_DEPLOYMENT,
            DIAGRAMS,
            DOCUMENTATION,
            FINANCE,
            GAMING,
            PHOTOS,
            SOCIAL,
            SYNCING,
            RSS,
            FIREWALL,
            SWITCH,
            DNS,
            DHCP,
            NOTES,
            ADBLOCK,
            CUSTOMER_RELATIONSHIP,
            ENT_RELATIONSHIP,
            CONTENT,
            WEB_SERVICES,
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
