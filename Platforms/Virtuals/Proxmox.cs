using System.Runtime.InteropServices;
using System.Text.Json;
using Enums;
using static Secrets;

namespace umanage_app
{
    public class Proxmox : IVirtualHosts
    {
        //HASK MUST FIX PASSWORD STORAGE

        public static async Task<SystemDetails> CreateSystemDetails(string ip)
        {
            // Logger.ShowFunction();
            SystemDetails s = new SystemDetails(ip, 8006, "Undefined");
            s.PlatformIdentifier = new PlatformIdentifier(EnumPlatformIdentifier.PROXMOX);
            s.CurrentState = new CurrentState(EnumCurrentState.ACTIVE);
            bool flag = await IsCorrectSystem(s);
            Globals.MATRIX.AddOrUpdate(s);
            //ScanThisSystem is a separate step! After pinging network
            // SystemDetails news = await ScanThisSystem(s);
            return s;
        }

        /*  public static async Task<SystemDetails> ScanThisSystem(string IP4Address)
         {
             Logger.ShowFunction();
             // Simulate scanning logic for Proxmox
             Logger.Info($"Scanning Proxmox at {IP4Address}...");
             // Return a dummy SystemDetails object for demonstration purposes
             SystemDetails s = new SystemDetails(IP4Address, 8006, "Proxmox");
             s.PlatformIdentifier = "V_HOST";
 
             return s;
         } */

        public static async Task ScanThisSystem(SystemDetails details)
        {
            Logger.ShowFunction("Proxmox", "ScanThisSystem");
            // Simulate scanning logic for Proxmox with existing details
            Logger.Info($"Scanning Proxmox with details: {details.UniqueName}...");
            // get data from Proxmox
            string json;
            List<ProxmoxMachine> allmachines = new List<ProxmoxMachine>();
            List<ProxmoxMachine>? tempmachines = new List<ProxmoxMachine>();
            var authenticator = new ProxmoxAuthenticator(
                Secrets.PROXMOX_USER,
                Secrets.PROXMOX_PASSWORD
            );

            using (
                APIcall api = new APIcall(
                    details.Ip4Address.Value,
                    8006,
                    true,
                    authenticator,
                    ignoreInvalidCerts: true
                )
            )
            {
                //TODO get list of VMs
                //VMs at /api2/json/nodes/{node}/qemu
                //Containers at /api2/json/nodes/{node}/lxc
                //node names are 205Psi & 215Isaac
                Globals.TICKET_HEADER = "PVEAuthCookie";
                Globals.TOKEN_HEADER = "CSRFPreventionToken:";

                try
                {
                    json = await api.GetJsonData(
                        details.CIDR + "/api2/json/nodes/" + details.SystemName + "/qemu",
                        new List<Action<HttpRequestMessage>>
                        {
                            //req => req.Headers.Add("CSRFPreventionToken", Globals.TOKEN),
                            req => req.Headers.Add("Cookie", $"PVEAuthCookie={Globals.TICKET}"),
                        }
                    );
                }
                catch (Exception ex)
                {
                    Logger.Error("Error during Proxmox scan: " + ex.Message);
                    return;
                }
                using (var doc = JsonDocument.Parse(json))
                {
                    var dataElement = doc.RootElement.GetProperty("data");
                    // Use GetRawText() to get the JSON array string
                    tempmachines = JsonSerializer.Deserialize<List<ProxmoxMachine>>(
                        dataElement.GetRawText()
                    );
                    if (tempmachines != null)
                    {
                        foreach (ProxmoxMachine pm in tempmachines)
                        {
                            allmachines.Add(pm);
                        }
                    }
                }

                json = await api.GetJsonData(
                    details.CIDR + "/api2/json/nodes/" + details.SystemName + "/lxc",
                    new List<Action<HttpRequestMessage>>
                    {
                        //req => req.Headers.Add("CSRFPreventionToken", Globals.TOKEN),
                        req => req.Headers.Add("Cookie", $"PVEAuthCookie={Globals.TICKET}"),
                    }
                );
                using (var doc = JsonDocument.Parse(json))
                {
                    var dataElement = doc.RootElement.GetProperty("data");
                    // Use GetRawText() to get the JSON array string
                    tempmachines = JsonSerializer.Deserialize<List<ProxmoxMachine>>(
                        dataElement.GetRawText()
                    );
                    if (tempmachines != null)
                    {
                        foreach (ProxmoxMachine pm in tempmachines)
                        {
                            allmachines.Add(pm);
                        }
                    }
                }

                foreach (ProxmoxMachine vm in allmachines)
                {
                    SystemDetails thisvm = new SystemDetails("", 0, "Undefined");
                    thisvm.CurrentState = new CurrentState(EnumCurrentState.ACTIVE);
                    //details.ExpectedState = api.GetValue(json, "");
                    thisvm.Functions.Add(new SystemFunction(EnumSystemFunction.VIRTUALIZATION));
                    thisvm.SystemRole = new SystemRole(EnumSystemRole.VIRTUALIZATION_HOST);
                    thisvm.SystemName = new SystemName(vm.name);
                    thisvm.OsType = new OsType(EnumOsType.DEBIAN);
                    thisvm.OsVersion = new OsVersion("");
                    ;
                    thisvm.ParentName = new ParentName(details.SystemName.Value);
                    thisvm.PlatformCategory = new PlatformCategory(
                        EnumPlatformCategory.VIRTUALIZATION_TECHNOLOGIES
                    );
                    thisvm.PlatformIdentifier = new PlatformIdentifier(
                        EnumPlatformIdentifier.PROXMOX
                    );
                    thisvm.Notes = api.GetValue(json, "");

                    thisvm.RdpLink = new URI(api.GetValue(json, ""));
                    thisvm.SshLink = new URI(api.GetValue(json, ""));
                    thisvm.VncLink = new URI(api.GetValue(json, ""));
                    thisvm.WebLink = new URI(api.GetValue(json, ""));

                    thisvm.CpuCount = new CpuCount(Convert.ToInt16(vm.cpus));
                    thisvm.RamMax = new Size(Convert.ToInt64(vm.maxmem));
                    thisvm.RamUsed = new Size(Convert.ToInt64(vm.mem));

                    //TODO group these based on json endpoint
                    // json = await api.GetJsonData("/api2/json/nodes/" + vm + "/storage");
                    thisvm.StorageMax = new Size(Convert.ToInt64(vm.maxdisk));
                    thisvm.StorageUsed = new Size(Convert.ToInt64(vm.disk));

                    //  json = await api.GetJsonData("/api2/json/version/data");
                    //details.PlatformVersion = api.GetValue(json, "release");

                    // json = await api.GetJsonData("/api2/json/nodes/{node}/network");
                    json = await api.GetJsonData(
                        details.CIDR + "/api2/json/nodes/" + details.SystemName + "/network",
                        new List<Action<HttpRequestMessage>>
                        {
                            req => req.Headers.Add("CSRFPreventionToken", Globals.TOKEN),
                            req => req.Headers.Add("Cookie", $"PVEAuthCookie={Globals.TICKET}"),
                        }
                    );
                    thisvm.Ip4Address = new Ip4Address(api.GetValue(json, "address"));
                    ;

                    thisvm.IdVirtual = Convert.ToString(vm.vmid);
                    thisvm.Ip4Port = new Ip4Port(0);
                    thisvm.Ip6Address = new Ip6Address("");
                    thisvm.MacAddress = new MacAddress("");
                    thisvm.Notes = "";
                    thisvm.PlatformVersion = new PlatformVersion("");
                    thisvm.Reason = "";
                    thisvm.Reservation = null;
                    thisvm.RdpLink = new URI("");
                    thisvm.SshLink = new URI("");
                    thisvm.AssetState = new CurrentState(EnumCurrentState.UNDEFINED);
                    thisvm.BookmarkState = new CurrentState(EnumCurrentState.UNDEFINED);
                    thisvm.DhcpState = new CurrentState(EnumCurrentState.UNDEFINED);
                    thisvm.DnsState = new CurrentState(EnumCurrentState.UNDEFINED);
                    thisvm.MonitorState = new CurrentState(EnumCurrentState.UNDEFINED);
                    thisvm.VirtualizationState = new CurrentState(EnumCurrentState.UNDEFINED);
                    thisvm.SwapMax = new Size(vm.maxswap);
                    thisvm.SwapUsed = new Size(vm.swap);
                    thisvm.VncLink = new URI("");
                    thisvm.WebLink = new URI("");
                    thisvm.AssetProvider = new Provider("");
                    thisvm.BookmarkProvider = new Provider("");
                    thisvm.DhcpProvider = new Provider("");
                    thisvm.DnsProvider = new Provider("");
                    thisvm.MonitorProvider = new Provider("");
                    thisvm.VirtualizationProvider = new Provider("");

                    Globals.MATRIX.AddOrUpdate(thisvm);
                }
            }
        }

        public static async Task<bool> IsCorrectSystem(SystemDetails details)
        {
            Logger.ShowFunction();
            var authenticator = new ProxmoxAuthenticator(
                Secrets.PROXMOX_USER,
                Secrets.PROXMOX_PASSWORD
            );

            using (
                APIcall api = new APIcall(
                    details.Ip4Address.Value,
                    8006,
                    true,
                    authenticator,
                    ignoreInvalidCerts: true
                )
            )
            {
                var payload = new Dictionary<string, string>
                {
                    { "username", Secrets.PROXMOX_USER },
                    { "password", Secrets.PROXMOX_PASSWORD },
                };
                var content = new FormUrlEncodedContent(payload);

                string url =
                    $"https://{details.Ip4Address}:{details.Ip4Port}/api2/json/access/ticket";
                var response = await api._httpClient.PostAsync(url, content);
                string json = await response.Content.ReadAsStringAsync();

                Logger.Debug(json); // Log raw response

                string? ticket = api.GetValue(json, "data.ticket");
                string? csrfToken = api.GetValue(json, "data.CSRFPreventionToken");

                Globals.TICKET = ticket ?? Constants.strEMPTY;
                Globals.TOKEN = csrfToken ?? Constants.strEMPTY;
                Globals.TOKENID = Globals.TOKEN.Substring(0, Globals.TOKEN.IndexOf(':'));

                //Globals.TICKET = Globals.TICKET.Replace("PVE:", "PVEAPIToken=");
                //Globals.TICKET = Globals.TICKET.Replace("@pam:", "@pam!");
                //Globals.TICKET = Globals.TICKET.Replace("::", "=");
                return ticket != null;
            }
        }

        public static void Start() { /* Implementation */
        }

        public static void Stop() { /* Implementation */
        }

        public static void Restart() { /* Implementation */
        }

        public static void Rename(
            string newValue
        ) { /* Implementation */
        }

        public static void Delete() { /* Implementation */
        }
    }
}

public class ProxmoxMachine
{
    // Common identifiers
    public int vmid { get; set; }
    public string name { get; set; } = "";
    public string Type { get; set; } = "";
    public string status { get; set; } = "";

    // Resources
    public int cpus { get; set; }
    public long maxmem { get; set; }
    public long mem { get; set; }
    public long maxdisk { get; set; }
    public long disk { get; set; }
    public long maxswap { get; set; }
    public long swap { get; set; }
    public double cpu { get; set; } // as percentage
    public long uptime { get; set; }

    // IO stats
    public long DiskRead { get; set; }
    public long DiskWrite { get; set; }
    public long NetIn { get; set; }
    public long NetOut { get; set; }

    // Metadata
    public string tags { get; set; } = "";

    // QEMU-only fields (nullable, not always present)
    public int? pid { get; set; }

    //public string? lock { get; set; }
    public bool? template { get; set; }

    // LXC-only fields (nullable, not always present)
    public string? ostype { get; set; }
    public string? rootfs { get; set; }
}
