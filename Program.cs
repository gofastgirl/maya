// See https://aka.ms/new-console-template for more information
using System;
using System.Threading.Tasks;
using Enums;
using umanage_app;

class Program
{
    public static async Task Main(string[] args)
    {
        var program = new Program();
        await program.Run();
    }

    public async Task Run()
    {
        // This should be at the very top of your file to ensure it's set up early
        TaskScheduler.UnobservedTaskException += (sender, e) =>
        {
            Console.Error.WriteLine(
                $"*** UNCOUGHT ASYNC EXCEPTION (UnobservedTaskException): {e.Exception.Message}"
            );
            Console.Error.WriteLine($"  Full Exception: {e.Exception}");
            e.SetObserved(); // Mark the exception as observed to prevent the process from crashing
            // Consider logging this immediately
        };

        AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
        {
            Logger.Error($"Unhandled exception caught: {e.ExceptionObject}");
            // You might want to log this or display a more user-friendly message
            Environment.Exit(1); // Exit with a non-zero code to indicate an error
        };

        // TODO Read existing file into matrix
        //TODO I need to work on PlatformCategorys and PlatformIdentifiers
        //TODO then check the opnsense and proxmox constructors

        //this Section, that this specific system is at this specific IP
        //no testing/checking is done here
        //this is the system and it is at this IP
        Logger.Info("static machines");
        // matrix.AddOrUpdate(await OPNsense.CreateSystemDetails(CIDR + "1"));
        //matrix.PrintAll();
        SystemDetails s = await Proxmox.CreateSystemDetails(Globals.CIDR + "215");
        s.SystemName = new SystemName("215Isaac");
        Globals.MATRIX.AddOrUpdate(s);
        //matrix.PrintAll();
        s = await Proxmox.CreateSystemDetails(Globals.CIDR + "205");
        s.SystemName = new SystemName("205Psi");
        Globals.MATRIX.AddOrUpdate(s);
        //matrix.PrintAll();
        s = await OPNsense.CreateSystemDetails(Globals.CIDR + "1");
        s.SystemName = new SystemName("OPNsense");
        Globals.MATRIX.AddOrUpdate(s);

        Logger.Info("Ping scan starting");
        //now, let's scan the entire network to find active IP addresses
        for (int i = 1; i < 255; i++)
        {
            string ip = Globals.CIDR + i;
            if (await Utilities.IsIpActiveAsync(ip))
            {
                SystemDetails? newsys = Globals.MATRIX.Find(ip, 0); // Find by IP only
                if (newsys == null)
                {
                    newsys = new SystemDetails(ip, 0, "undefined");
                }
                newsys.CurrentState = new CurrentState(EnumCurrentState.ACTIVE);
                //Globals.MATRIX.AddOrUpdate(newsys);
            }
        }
        // Globals.MATRIX.PrintAll();

        //We can't directly use the MATRIX to loop through the systems
        //because we may be adding new systems as we go

        foreach (SystemDetails sys in Globals.MATRIX.GetSystemsCopy())
        {
            if (sys.CurrentState.Value == EnumCurrentState.ACTIVE)
            {
                // Scan the system to fill in details
                //HACK there must be a cleaner way to do this
                switch (sys.PlatformIdentifier.Value)
                {
                    case EnumPlatformIdentifier.UNDEFINED:
                        break;
                    case EnumPlatformIdentifier.OPNSENSE:
                        await OPNsense.ScanThisSystem(sys);
                        break;
                    case EnumPlatformIdentifier.PROXMOX:
                        try
                        {
                            await Proxmox.ScanThisSystem(sys);
                        }
                        catch (Exception ex)
                        {
                            Logger.Error($"Error scanning Proxmox system: {ex.Message}");
                        }
                        break;

                    default:
                        throw new NotImplementedException(
                            $"Platform {sys.PlatformIdentifier} not implemented."
                        );
                }
            }
        }

        Globals.MATRIX.PrintAll();

        //ok, I now have a list of active systems
        // TODO Save the file for next pass
    }
}
