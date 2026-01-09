namespace Enums
{
    public enum EnumPlatformCategory
    {
        UNDEFINED,
        HARDWARE_PLATFORMS,
        PHYSICAL_SERVER,
        DESKTOP_PC,
        LAPTOP,
        NETWORK_APPLIANCE, // Dedicated firewalls, routers, switches
        SINGLE_BOARD_COMPUTER, // e.g., Raspberry Pi
        STORAGE_APPLIANCE, // e.g., NAS, SAN controllers
        OPERATING_SYSTEMS,
        LINUX_DISTRIBUTION, // e.g., Ubuntu, Debian, CentOS
        WINDOWS_SERVER_OS,
        WINDOWS_DESKTOP_OS,
        MACOS,
        BSD_VARIANTS, // FreeBSD, OpenBSD, NetBSD
        NETWORK_OPERATING_SYSTEM, // Router/Switch OS like Cisco IOS, Junos
        VIRTUALIZATION_TECHNOLOGIES,
        HYPERVISOR, // Proxmox, VMware ESXi, Hyper-V, KVM
        CONTAINER_RUNTIME, // Docker, containerd
        CONTAINER_ORCHESTRATOR, // Kubernetes, OpenShift
        VDI, // Virtual Desktop Infrastructure
        RELATIONAL_DATABASE, // PostgreSQL, MySQL, SQL Server
        NOSQL_DATABASE, // MongoDB, Redis, Cassandra
        TIME_SERIES_DATABASE, // InfluxDB
        WEB_APPLICATION_SERVERS,
        WEB_SERVER_SOFTWARE, // Apache, Nginx, Caddy
        APPLICATION_SERVER_SOFTWARE, // Tomcat, JBoss, Node.js
        STORAGE_TECHNOLOGIES,
        DISTRIBUTED_FILESYSTEM, // CephFS, GlusterFS
        SOFTWARE_DEFINED_STORAGE, // Software Defined Storage (SDS)
        ZFS_FILESYSTEM,
        CLOUD_ORCHESTRATION,
        PRIVATE_CLOUD_PLATFORM, // e.g., OpenStack
        SECURITY_APPLIANCE_OS, // pfSense, OPNsense
        IDENTITY_MANAGEMENT, // FreeIPA, Keycloak
        MONITORING_SOFTWARE, // Prometheus, Graf
    }
    /*
    public class ValidPlatformCategorys
    {
        public const string UNDEFINED = "UNDEFINED";
        public const string HARDWARE_PLATFORMS = "HARDWARE PLATFORMS";
        public const string PHYSICAL_SERVER = "PHYSICAL SERVER";
        public const string DESKTOP_PC = "DESKTOP PC";
        public const string LAPTOP = "LAPTOP";
        public const string NETWORK_APPLIANCE = "NETWORK APPLIANCE"; // Dedicated firewalls, routers, switches
        public const string SINGLE_BOARD_COMPUTER = "SINGLE BOARD COMPUTER"; // e.g., Raspberry Pi
        public const string STORAGE_APPLIANCE = "STORAGE APPLIANCE"; // e.g., NAS, SAN controllers
        public const string OPERATING_SYSTEMS = "OPERATING SYSTEMS";
        public const string LINUX_DISTRIBUTION = "LINUX DISTRIBUTION (E.G., UBUNTU, DEBIAN, CENTOS)";
        public const string WINDOWS_SERVER_OS = "WINDOWS SERVER OS";
        public const string WINDOWS_DESKTOP_OS = "WINDOWS DESKTOP OS";
        public const string MACOS = "MACOS";
        public const string BSD_VARIANTS = "FREEBSD / OPENBSD / NETBSD (BSD VARIANTS)";
        public const string NETWORK_OPERATING_SYSTEM = "NETWORK OPERATING SYSTEM"; // Router/Switch OS like Cisco IOS, Junos
        public const string VIRTUALIZATION_TECHNOLOGIES = "VIRTUALIZATION TECHNOLOGIES";
        public const string HYPERVISOR = "HYPERVISOR"; // Proxmox, VMware ESXi, Hyper-V, KVM
        public const string CONTAINER_RUNTIME = "CONTAINER RUNTIME"; // Docker, containerd
        public const string CONTAINER_ORCHESTRATOR = "CONTAINER ORCHESTRATOR"; // Kubernetes, OpenShift
        public const string VDI = "VIRTUAL DESKTOP INFRASTRUCTURE (VDI)";
        public const string RELATIONAL_DATABASE = "RELATIONAL DATABASE"; // PostgreSQL, MySQL, SQL Server
        public const string NOSQL_DATABASE = "NOSQL DATABASE"; // MongoDB, Redis, Cassandra
        public const string TIME_SERIES_DATABASE = "TIME-SERIES DATABASE"; // InfluxDB
        public const string WEB_APPLICATION_SERVERS = "WEB & APPLICATION SERVERS";
        public const string WEB_SERVER_SOFTWARE = "WEB SERVER SOFTWARE"; // Apache, Nginx, Caddy
        public const string APPLICATION_SERVER_SOFTWARE = "APPLICATION SERVER SOFTWARE"; // Tomcat, JBoss, Node.js
        public const string STORAGE_TECHNOLOGIES = "STORAGE TECHNOLOGIES";
        public const string DISTRIBUTED_FILESYSTEM = "DISTRIBUTED FILESYSTEM"; // CephFS, GlusterFS
        public const string SOFTWARE_DEFINED_STORAGE = "SOFTWARE DEFINED STORAGE (SDS)";
        public const string ZFS_FILESYSTEM = "ZFS FILESYSTEM";
        public const string CLOUD_ORCHESTRATION = "CLOUD/ORCHESTRATION";
        public const string PRIVATE_CLOUD_PLATFORM = "PRIVATE CLOUD PLATFORM"; // e.g., OpenStack
        public const string SECURITY_APPLIANCE_OS = "SECURITY APPLIANCE OS"; // pfSense, OPNsense
        public const string IDENTITY_MANAGEMENT = "IDENTITY MANAGEMENT"; // FreeIPA, Keycloak
        public const string MONITORING_SOFTWARE = "MONITORING SOFTWARE"; // Prometheus, Grafana, Zabbix
        public const string LOG_MANAGEMENT = "LOG MANAGEMENT"; // ELK Stack
        public const string BACKUP_SOFTWARE = "BACKUP SOFTWARE";

        private static readonly List<string> validStrings = new List<string>
        {
            UNDEFINED,
            HARDWARE_PLATFORMS,
            PHYSICAL_SERVER,
            DESKTOP_PC,
            LAPTOP,
            NETWORK_APPLIANCE,
            SINGLE_BOARD_COMPUTER,
            STORAGE_APPLIANCE,
            OPERATING_SYSTEMS,
            LINUX_DISTRIBUTION,
            WINDOWS_SERVER_OS,
            WINDOWS_DESKTOP_OS,
            MACOS,
            BSD_VARIANTS,
            NETWORK_OPERATING_SYSTEM,
            VIRTUALIZATION_TECHNOLOGIES,
            HYPERVISOR,
            CONTAINER_RUNTIME,
            CONTAINER_ORCHESTRATOR,
            VDI,
            RELATIONAL_DATABASE,
            NOSQL_DATABASE,
            TIME_SERIES_DATABASE,
            WEB_APPLICATION_SERVERS,
            WEB_SERVER_SOFTWARE,
            APPLICATION_SERVER_SOFTWARE,
            STORAGE_TECHNOLOGIES,
            DISTRIBUTED_FILESYSTEM,
            SOFTWARE_DEFINED_STORAGE,
            ZFS_FILESYSTEM,
            CLOUD_ORCHESTRATION,
            PRIVATE_CLOUD_PLATFORM,
            SECURITY_APPLIANCE_OS,
            IDENTITY_MANAGEMENT,
            MONITORING_SOFTWARE,
            LOG_MANAGEMENT,
            BACKUP_SOFTWARE,
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
