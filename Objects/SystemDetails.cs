/*
here is a template of all fields, for use when setting

    SystemDetails NewSystem = new SystemDetails
       {
           Ip4Address = "",
           Ip4Port = 0,
           SystemName = "Undefined"
                //optional, but if you want to actually ScanThisSystem you need these:
                PlatformIdentifier = ValidPlatformIdentifiers.PROXMOX,
                CurrentState = ValidCurrentStates.ACTIVE
     };
NewSystem.CpuCount = tofix;
NewSystem.CurrentState= tofix;
NewSystem.ExpectedState= tofix;
NewSystem.Functions= tofix;
NewSystem.SystemName= tofix;
NewSystem.SystemRole= tofix;
NewSystem.IdVirtual= tofix;
NewSystem.Ip4Address= tofix;
NewSystem.Ip4Port= tofix;
NewSystem.Ip6Address= tofix;
NewSystem.LastUpdated= tofix;
NewSystem.MacAddress= tofix;
NewSystem.Notes= tofix;
NewSystem.OsType= tofix;
NewSystem.OsVersion= tofix;
NewSystem.ParentName= tofix;
NewSystem.PlatformCategory= tofix;
NewSystem.PlatformIdentifier=v
NewSystem.PlatformVersion= tofix;
NewSystem.RamMaxMB= tofix;
NewSystem.RamUsedMB= tofix;
NewSystem.Reason= tofix;
NewSystem.Reservation=v
NewSystem.RdpLink= tofix;
NewSystem.SshLink= tofix;
NewSystem.StateInAssetTool= tofix;
NewSystem.StateInBookmarkTool= tofix;
NewSystem.StateInDhcpTool= tofix;
NewSystem.StateInDnsTool= tofix;
NewSystem.StateInMonitorTool= tofix;
NewSystem.StateInVirtualizationTool= tofix;
NewSystem.StorageMaxMB= tofix;
NewSystem.StorageUsedMB= tofix;
NewSystem.SwapMax= tofix;
NewSystem.SwapUsed= tofix;
NewSystem.VncLink= tofix;
NewSystem.WebLink= tofix;
NewSystem.WhichAssetTool= tofix;
NewSystem.WhichBookmarkTool= tofix;
NewSystem.WhichDhcpTool= tofix;
NewSystem.WhichDnsTool= tofix;
NewSystem.WhichMonitorTool= tofix;
NewSystem.WhichVirtualizationTool= tofix;
*/

namespace umanage_app
{
    using Enums;

    public class SystemDetails
    {
        // Unique identifier, e.g., "SystemName_IP_Port"
        //public string UniqueName { get; } = string.Empty;
        //function!

        // Basic system info
        public SystemName SystemName { get; set; }
        public Ip4Address Ip4Address { get; set; }
        public Ip4Port Ip4Port { get; set; }
        public SystemRole SystemRole = new SystemRole(EnumSystemRole.UNDEFINED); // Default_value for SystemRole
        public PlatformCategory PlatformCategory { get; set; } =
            new PlatformCategory(EnumPlatformCategory.UNDEFINED); // e.g., "Router", "VirtualHost"
        public PlatformIdentifier PlatformIdentifier = new PlatformIdentifier(
            EnumPlatformIdentifier.UNDEFINED
        ); // Default_value for SystemRole
        public PlatformVersion PlatformVersion { get; set; } = new PlatformVersion(""); // e.g., "2.0", "22.7"
        public ParentName ParentName { get; set; } = new ParentName("");
        public OsType OsType { get; set; } = new OsType(EnumOsType.UNDEFINED); // Default_value for SystemRole
        public OsVersion OsVersion { get; set; } = new OsVersion(""); // e.g., "Ubuntu 20.04", "Windows Server 2019"

        public MacAddress MacAddress { get; set; } = new MacAddress(""); // MAC address if available

        public List<SystemFunction> Functions { get; set; } = new List<SystemFunction>(); // Function or role of the system (network, monitoring, etc.)

        public ExpectedState ExpectedState { get; set; } =
            new ExpectedState(EnumExpectedState.UNDEFINED); //what should this be: running, stopped
        public CurrentState CurrentState { get; set; } =
            new CurrentState(EnumCurrentState.UNDEFINED); //what it actually is:

        // Additional links (web, ssh, etc.)
        public URI WebLink { get; set; } = new URI("");
        public URI SshLink { get; set; } = new URI("");
        public URI VncLink { get; set; } = new URI("");
        public URI RdpLink { get; set; } = new URI("");

        public string? Notes { get; set; } // Notes or user comments

        // Resources info
        public CpuCount CpuCount { get; set; } = new CpuCount(0);
        public Size RamMax { get; set; } = new Size(0);
        public Size RamUsed { get; set; } = new Size(0);
        public Size StorageMax { get; set; } = new Size(0);
        public Size StorageUsed { get; set; } = new Size(0);
        public Size SwapMax { get; set; } = new Size(0);
        public Size SwapUsed { get; set; } = new Size(0);

        // Timestamp of last update
        public DateTime LastUpdated { get; } = DateTime.UtcNow;

        public string? Reason { get; set; } //a place to store a reason for a state, like "Maintenance", "Decommissioned", etc.
        public bool? Reservation { get; set; } //is a reseervation set in DHCP?
        public Ip6Address Ip6Address { get; set; } = new Ip6Address("");

        public CurrentState DhcpState { get; set; } = new CurrentState(EnumCurrentState.UNDEFINED);
        public Provider DhcpProvider { get; set; } = new Provider(""); //is it in DHCP system: ISC, Dnsmasq, Cloudflare
        public CurrentState DnsState { get; set; } = new CurrentState(EnumCurrentState.UNDEFINED);
        public Provider DnsProvider { get; set; } = new Provider(""); //is it in DNS system: BIND, Active Directory, Cloudflare
        public CurrentState VirtualizationState { get; set; } =
            new CurrentState(EnumCurrentState.UNDEFINED);
        public Provider VirtualizationProvider { get; set; } = new Provider(""); //is it in virtualization system: Proxmox, VMware, Hyper-V

        public string? IdVirtual { get; set; } //leave generic

        public CurrentState MonitorState { get; set; } =
            new CurrentState(EnumCurrentState.UNDEFINED);
        public Provider MonitorProvider { get; set; } = new Provider(""); //is it in monitoring system: Zabbix, Prometheus
        public CurrentState AssetState { get; set; } = new CurrentState(EnumCurrentState.UNDEFINED);
        public Provider AssetProvider { get; set; } = new Provider(""); //Is it in asset library: Snipe-IT, NetBox
        public CurrentState BookmarkState { get; set; } =
            new CurrentState(EnumCurrentState.UNDEFINED);
        public Provider BookmarkProvider { get; set; } = new Provider(""); //links library: LinkWarden, Homarr

        public void StartButton() { }

        public void StopButton() { }

        public void DeleteButton() { }

        public void RenameButton() { }

        public SystemDetails(string ip, int port, string sysname)
        {
            Ip4Address = new Ip4Address(ip);
            Ip4Port = new Ip4Port(port);
            SystemName = new SystemName(sysname);
        }

        public CIDR CIDR
        {
            get
            {
                string s = Constants.strHTTPS;
                s += Constants.strCOLON + Constants.strSLASH + Constants.strSLASH;
                s += Ip4Address;

                if (Ip4Port.Value > 0)
                {
                    s += Constants.strCOLON + Ip4Port;
                }
                return new CIDR(s);
            }
        }

        public string UniqueName
        {
            get
            {
                string s = string.Empty;
                if (!string.IsNullOrWhiteSpace(SystemName.Value))
                {
                    s += SystemName + Constants.strGREATERTHAN;
                }
                if (!string.IsNullOrWhiteSpace(Ip4Address.Value))
                {
                    s += Ip4Address;
                }

                if (Ip4Port.Value > 0)
                {
                    s += Constants.strCOLON + Ip4Port;
                }

                return s;
            }
        }

        public string ToString_Short()
        {
            string s = UniqueName;
            return s;
        }

        public string ToString_Long()
        {
            string s =
                PlatformIdentifier
                + Constants.strGREATERTHAN
                + UniqueName
                + Constants.strGREATERTHAN
                + CurrentState;
            return s;
        }

        public void Merge(SystemDetails newValue)
        {
            Logger.ShowFunction();
            // Merge properties from newValue system details
            if (newValue == null)
                return;

            // Unique identifier, e.g., "SystemName_IP_Port"
            //public string UniqueName { get; } = string.Empty;
            //function!

            // Basic system info
            {
                ExpectedState.Merge(newValue.ExpectedState.Value);
                CurrentState.Merge(newValue.CurrentState.Value);
                OsType.Merge(newValue.OsType.Value);
                SystemRole.Merge(newValue.SystemRole.Value);
                CpuCount.Merge(newValue.CpuCount.Value);
                SystemRole.Merge(newValue.SystemRole.Value);
                OsType.Merge(newValue.OsType.Value);
                PlatformCategory.Merge(newValue.PlatformCategory.Value);
                PlatformIdentifier.Merge(newValue.PlatformIdentifier.Value);

                SystemName.Merge(newValue.SystemName.Value);

                PlatformVersion.Merge(newValue.PlatformVersion.Value);
                ParentName.Merge(newValue.ParentName.Value);
                OsVersion.Merge(newValue.OsVersion.Value);

                Ip4Address.Merge(newValue.Ip4Address.Value);
                Ip4Port.Merge(newValue.Ip4Port.Value);

                MacAddress.Merge(newValue.MacAddress.Value);

                // Function or role of the system (network, monitoring, etc.)
                foreach (var function in newValue.Functions)
                {
                    if (!Functions.Contains(function))
                    {
                        Functions.Add(function);
                    }
                }

                // Status or expected state

                // Additional links (web, ssh, etc.)
                WebLink.Merge(newValue.WebLink.Value);
                SshLink.Merge(newValue.SshLink.Value);
                VncLink.Merge(newValue.VncLink.Value);
                RdpLink.Merge(newValue.RdpLink.Value);

                // Notes or user comments
                Notes = newValue.Notes + Constants.strSPACE + Notes;

                // Resources info
                RamMax.Merge(newValue.RamMax.Value);
                RamUsed.Merge(newValue.RamUsed.Value);
                StorageMax.Merge(newValue.StorageMax.Value);
                StorageUsed.Merge(newValue.StorageUsed.Value);

                SwapMax.Merge(newValue.SwapMax.Value);
                SwapUsed.Merge(newValue.SwapUsed.Value);
            }
        }
    }
}
