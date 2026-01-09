namespace Enums
{
    public enum EnumOsType
    {
        UNDEFINED,
        WINDOWS,
        UBUNTU,
        REDHAT,
        DEBIAN,
        FEDORA,
        ARCH,
        ALPINE,
        MACOS,
        CHROMEOS,
        FREEBSD,
        OPENBSD,
        NETBSD,
        SOLARIS,
        VMWARE_ESXI,
        QNAP_QTS,
        SYNOLOGY_DSM,
        CISCO_IOS,
        JUNIPER_JUNOS,
        PFSENSE,
        OPNSENSE,
        ANDROID,
        IOS,
    }
    /*
    public class ValidOsTypes
    {
        public const string UNDEFINED = "UNDEFINED";
        public const string WINDOWS = "WINDOWS";
        public const string UBUNTU = "UBUNTU";
        public const string REDHAT = "REDHAT";
        public const string DEBIAN = "DEBIAN";
        public const string FEDORA = "FEDORA";
        public const string ARCH = "ARCH";
        public const string ALPINE = "ALPINE";
        public const string MACOS = "MACOS";
        public const string CHROMEOS = "CHROMEOS";
        public const string FREEBSD = "FREEBSD";
        public const string OPENBSD = "OPENBSD";
        public const string NETBSD = "NETBSD";
        public const string SOLARIS = "SOLARIS";
        public const string VMWARE_ESXI = "VMWARE_ESXI";
        public const string QNAP_QTS = "QNAP_QTS";
        public const string SYNOLOGY_DSM = "SYNOLOGY_DSM";
        public const string CISCO_IOS = "CISCO_IOS";
        public const string JUNIPER_JUNOS = "JUNIPER_JUNOS";
        public const string PFSENSE = "PFSENSE";
        public const string OPNSENSE = "OPNSENSE";
        public const string ANDROID = "ANDROID";
        public const string IOS = "IOS";

        static List<string> validStrings = new List<string>
        {
            UNDEFINED,
            WINDOWS,
            UBUNTU,
            REDHAT,
            DEBIAN,
            FEDORA,
            ARCH,
            ALPINE,
            MACOS,
            CHROMEOS,
            FREEBSD,
            OPENBSD,
            NETBSD,
            SOLARIS,
            VMWARE_ESXI,
            QNAP_QTS,
            SYNOLOGY_DSM,
            CISCO_IOS,
            JUNIPER_JUNOS,
            PFSENSE,
            OPNSENSE,
            ANDROID,
            IOS,
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
