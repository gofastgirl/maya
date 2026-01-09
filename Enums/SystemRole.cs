namespace Enums
{
    public enum EnumSystemRole
    {
        UNDEFINED,
        GENERAL_PURPOSE_SERVER,
        APPLICATION_SERVER,
        WEB_SERVER,
        DATABASE_SERVER,
        MAIL_SERVER,
        DNS_SERVER,
        DHCP_SERVER,
        AUTHENTICATION_SERVER,
        MONITORING_SERVER,
        LOGGING_SERVER,
        BACKUP_SERVER,
        FILE_SERVER,
        PRINT_SERVER,
        VIRTUALIZATION_HOST,
        VIRTUAL_MACHINE,
        VIRTUAL_CONTAINER,
        NETWORKING,
        ROUTER,
        FIREWALL,
        SWITCH,
        ACCESS_POINT,
        LOAD_BALANCER,
        PROXY_SERVER,
        VPN_SERVER,
        DNS_RESOLVER,
        DNS_SINK,
        STORAGE,
        NETWORK_ATTACHED_STORAGE, // NAS
        STORAGE_AREA_NETWORK, // SAN
        END_USER_DEVICES,
        WORKSTATION,
        THIN_CLIENT,
        IOT_DEVICE,
        SPECIALIZED,
        DEVELOPMENT_ENVIRONMENT,
        TESTING_ENVIRONMENT,
        STAGING_ENVIRONMENT,
        MANAGEMENT_SERVER,
        MEDIA_SERVER,
        VOIP_SERVER, // Voice Over IP
        IOT_GATEWAY,
        BUILD_SERVER,
        CI_CD_SERVER, // Continuous Integration / Continuous Deployment
        NETWORK_APPLIANCE,
    }
    /*
    public class ValidSystemRoles
    {
        public const string UNDEFINED = "UNDEFINED";
        public const string GENERAL_PURPOSE_SERVER = "GENERAL PURPOSE SERVER";
        public const string APPLICATION_SERVER = "APPLICATION SERVER";
        public const string WEB_SERVER = "WEB SERVER";
        public const string DATABASE_SERVER = "DATABASE SERVER";/*

        public const string MAIL_SERVER = "MAIL SERVER";
        public const string DNS_SERVER = "DNS SERVER";
        public const string DHCP_SERVER = "DHCP SERVER";
        public const string AUTHENTICATION_SERVER = "AUTHENTICATION SERVER";
        public const string MONITORING_SERVER = "MONITORING SERVER";
        public const string LOGGING_SERVER = "LOGGING SERVER";
        public const string BACKUP_SERVER = "BACKUP SERVER";
        public const string FILE_SERVER = "FILE SERVER";
        public const string PRINT_SERVER = "PRINT SERVER";
        public const string VIRTUALIZATION_HOST = "VIRTUALIZATION HOST";
        public const string VIRTUAL_MACHINE = "VIRTUAL MACHINE";
        public const string VIRTUAL_CONTAINER = "VIRTUAL CONTAINER";
        public const string NETWORKING = "NETWORKING";
        public const string ROUTER = "ROUTER";
        public const string FIREWALL = "FIREWALL";
        public const string SWITCH = "SWITCH";
        public const string ACCESS_POINT = "ACCESS POINT";
        public const string LOAD_BALANCER = "LOAD BALANCER";
        public const string PROXY_SERVER = "PROXY SERVER";
        public const string VPN_SERVER = "VPN SERVER";
        public const string DNS_RESOLVER = "DNS RESOLVER";
        public const string DNS_SINK = "DNS SINK";
        public const string STORAGE = "STORAGE";
        public const string NETWORK_ATTACHED_STORAGE = "NETWORK ATTACHED STORAGE (NAS)";
        public const string STORAGE_AREA_NETWORK = "STORAGE AREA NETWORK (SAN)";
        public const string END_USER_DEVICES = "END-USER DEVICES";
        public const string WORKSTATION = "WORKSTATION";
        public const string THIN_CLIENT = "THIN CLIENT";
        public const string IOT_DEVICE = "IOT DEVICE";
        public const string SPECIALIZED = "SPECIALIZED";
        public const string DEVELOPMENT_ENVIRONMENT = "DEVELOPMENT ENVIRONMENT";
        public const string TESTING_ENVIRONMENT = "TESTING ENVIRONMENT";
        public const string STAGING_ENVIRONMENT = "STAGING ENVIRONMENT";
        public const string MANAGEMENT_SERVER = "MANAGEMENT SERVER";
        public const string MEDIA_SERVER = "MEDIA SERVER";
        public const string VOIP_SERVER = "VOICE OVER IP (VOIP) SERVER";
        public const string IOT_GATEWAY = "IOT GATEWAY";
        public const string BUILD_SERVER = "BUILD SERVER";
        public const string CI_CD_SERVER = "CI/CD SERVER";
        public const string NETWORK_APPLIANCE = "NETWORK APPLIANCE";

        static List<string> validStrings = new List<string>
        {
            UNDEFINED,
            GENERAL_PURPOSE_SERVER,
            APPLICATION_SERVER,
            WEB_SERVER,
            DATABASE_SERVER,
            MAIL_SERVER,
            DNS_SERVER,
            DHCP_SERVER,
            AUTHENTICATION_SERVER,
            MONITORING_SERVER,
            LOGGING_SERVER,
            BACKUP_SERVER,
            FILE_SERVER,
            PRINT_SERVER,
            VIRTUALIZATION_HOST,
            VIRTUAL_MACHINE,
            VIRTUAL_CONTAINER,
            NETWORKING,
            ROUTER,
            FIREWALL,
            SWITCH,
            ACCESS_POINT,
            LOAD_BALANCER,
            PROXY_SERVER,
            VPN_SERVER,
            DNS_RESOLVER,
            DNS_SINK,
            STORAGE,
            NETWORK_ATTACHED_STORAGE,
            STORAGE_AREA_NETWORK,
            END_USER_DEVICES,
            WORKSTATION,
            THIN_CLIENT,
            IOT_DEVICE,
            SPECIALIZED,
            DEVELOPMENT_ENVIRONMENT,
            TESTING_ENVIRONMENT,
            STAGING_ENVIRONMENT,
            MANAGEMENT_SERVER,
            MEDIA_SERVER,
            VOIP_SERVER,
            IOT_GATEWAY,
            BUILD_SERVER,
            CI_CD_SERVER,
            NETWORK_APPLIANCE,
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
