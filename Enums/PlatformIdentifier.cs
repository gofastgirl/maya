namespace Enums
{
    public enum EnumPlatformIdentifier
    {
        UNDEFINED,
        PROXMOX,
        VMWARE_ESXI,
        MICROSOFT_HYPER_V,
        KVM,
        VIRTUALBOX,
        XEN,
        UBUNTU_SERVER,
        UBUNTU_DESKTOP,
        DEBIAN,
        CENTOS,
        ROCKY,
        ALMA,
        FEDORA,
        ARCH,
        ALPINE,
        WINDOWS_SERVER,
        WINDOWS_DESKTOP,
        CISCO_CATALYST,
        UBIQUITI_EDGEROUTER,
        UBIQUITI_UNIFI,
        PFSENSE,
        OPNSENSE,
        SOPHOS_XG,
        POSTGRESQL,
        MYSQL,
        MARIADB,
        MICROSOFT_SQL_SERVER,
        SQLITE,
        MONGODB,
        REDIS,
        APACHE_CASSANDRA,
        APACHE_HTTP_SERVER,
        NGINX,
        CADDY,
        KUBERNETES,
        DOCKER,
        OPENSHIFT,
        DELL_SERVER,
        HP_SERVER,
        SUPERMICRO_SERVER,
        RASPBERRY_PI,
    }

    /*
    public class ValidPlatformIdentifiers
    {
        public const string UNDEFINED = "UNDEFINED";
        public const string PROXMOX = "PROXMOX";
        public const string VMWARE_ESXI = "VMWARE ESXI";
        public const string MICROSOFT_HYPER_V = "MICROSOFT HYPER-V";
        public const string KVM = "KVM";
        public const string VIRTUALBOX = "VIRTUALBOX";
        public const string XEN = "XEN";
        public const string UBUNTU_SERVER = "UBUNTU SERVER";
        public const string UBUNTU_DESKTOP = "UBUNTU DESKTOP";
        public const string DEBIAN = "DEBIAN";
        public const string CENTOS = "CENTOS";
        public const string ROCKY = "ROCKY";
        public const string ALMA = "ALMA";
        public const string FEDORA = "FEDORA";
        public const string ARCH = "ARCH";
        public const string ALPINE = "ALPINE";
        public const string WINDOWS_SERVER = "WINDOWS SERVER";
        public const string WINDOWS_DESKTOP = "WINDOWS DESKTOP";
        public const string CISCO_CATALYST = "CISCO CATALYST";
        public const string UBIQUITI_EDGEROUTER = "UBIQUITI EDGEROUTER";
        public const string UBIQUITI_UNIFI = "UBIQUITI UNIFI";
        public const string PFSENSE = "PFSENSE";
        public const string OPNSENSE = "OPNSENSE";
        public const string SOPHOS_XG = "SOPHOS XG";
        public const string POSTGRESQL = "POSTGRESQL";
        public const string MYSQL = "MYSQL";
        public const string MARIADB = "MARIADB";
        public const string MICROSOFT_SQL_SERVER = "MICROSOFT SQL SERVER";
        public const string SQLITE = "SQLITE";
        public const string MONGODB = "MONGODB";
        public const string REDIS = "REDIS";
        public const string APACHE_CASSANDRA = "APACHE CASSANDRA";
        public const string APACHE_HTTP_SERVER = "APACHE HTTP SERVER";
        public const string NGINX = "NGINX";
        public const string CADDY = "CADDY";
        public const string KUBERNETES = "KUBERNETES";
        public const string DOCKER = "DOCKER";
        public const string OPENSHIFT = "OPENSHIFT";
        public const string DELL_SERVER = "DELL SERVER";
        public const string HP_SERVER = "HP SERVER";
        public const string SUPERMICRO_SERVER = "SUPERMICRO SERVER";
        public const string RASPBERRY_PI = "RASPBERRY PI";

        private static readonly List<string> validStrings = new List<string>
        {
            UNDEFINED,
            PROXMOX,
            VMWARE_ESXI,
            MICROSOFT_HYPER_V,
            KVM,
            VIRTUALBOX,
            XEN,
            UBUNTU_SERVER,
            UBUNTU_DESKTOP,
            DEBIAN,
            CENTOS,
            ROCKY,
            ALMA,
            FEDORA,
            ARCH,
            ALPINE,
            WINDOWS_SERVER,
            WINDOWS_DESKTOP,
            CISCO_CATALYST,
            UBIQUITI_EDGEROUTER,
            UBIQUITI_UNIFI,
            PFSENSE,
            OPNSENSE,
            SOPHOS_XG,
            POSTGRESQL,
            MYSQL,
            MARIADB,
            MICROSOFT_SQL_SERVER,
            SQLITE,
            MONGODB,
            REDIS,
            APACHE_CASSANDRA,
            APACHE_HTTP_SERVER,
            NGINX,
            CADDY,
            KUBERNETES,
            DOCKER,
            OPENSHIFT,
            DELL_SERVER,
            HP_SERVER,
            SUPERMICRO_SERVER,
            RASPBERRY_PI,
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
