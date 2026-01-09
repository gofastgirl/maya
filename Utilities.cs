using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks; // For async/await

public class Utilities
{
    /// <summary>
    /// Pings an IP address or SystemName and returns true if it's active (responds).
    /// </summary>
    /// <param name="IP4AddressOrSystemName">The IP address or SystemName string to ping.</param>
    /// <param name="timeoutMs">The maximum time to wait for a reply, in milliseconds. Default is 5000 ms (5 seconds).</param>
    /// <returns>True if the host is reachable and responds, false otherwise.</returns>
    public static bool IsIpActive(string IP4AddressOrSystemName, int timeoutMs = 50)
    {
        Logger.ShowFunction();
        if (string.IsNullOrWhiteSpace(IP4AddressOrSystemName))
        {
            Logger.Error("Error: IP address or SystemName cannot be empty.");
            return false;
        }

        try
        {
            using (Ping pingSender = new Ping())
            {
                PingOptions options = new PingOptions();
                // Use a small TTL (Time To Live) to prevent packets from looping indefinitely.
                // A common_value is 128 for Windows, 64 for Linux/macOS.
                // We'll use a small_value as we just need a response.
                options.Ttl = 128;
                options.DontFragment = true; // Prevents fragmentation of the packet

                // Send the ping asynchronously to avoid blocking the UI thread if called from a UI application.
                // Although this method is sync, the underlying Ping.Send can be blocking.
                // For a truly non-blocking call in a sync context, consider Ping.SendAsync and await its result.
                PingReply reply = pingSender.Send(IP4AddressOrSystemName, timeoutMs);

                // Check if the ping was successful
                if (reply.Status == IPStatus.Success)
                {
                    Logger.Debug($"Ping to {IP4AddressOrSystemName} successful.");
                    //Logger.Info($"Address: {reply.Address}");
                    //Logger.Info($"RoundTrip time: {reply.RoundtripTime} ms");
                    //Logger.Info($"Time to live: {reply.Options.Ttl}");
                    //Logger.Info($"Don't fragment: {reply.Options.DontFragment}");
                    //Logger.Info($"Buffer size: {reply.Buffer.Length}");
                    return true;
                }
                else
                {
                    Logger.Debug($"Ping to {IP4AddressOrSystemName} failed: {reply.Status}");
                    return false;
                }
            }
        }
        catch (PingException ex)
        {
            // This catches specific ping-related errors like "No such host is known"
            Logger.Error($"Ping exception for {IP4AddressOrSystemName}: {ex.Message}");
            return false;
        }
        catch (Exception ex)
        {
            // Catch any other unexpected errors
            Logger.Error(
                $"An unexpected error occurred while pinging {IP4AddressOrSystemName}: {ex.Message}"
            );
            return false;
        }
    }

    /// <summary>
    /// Asynchronously pings an IP address or SystemName and returns true if it's active (responds).
    /// This is the preferred method for modern async C# applications.
    /// </summary>
    /// <param name="IP4AddressOrSystemName">The IP address or SystemName string to ping.</param>
    /// <param name="timeoutMs">The maximum time to wait for a reply, in milliseconds. Default is 5000 ms (5 seconds).</param>
    /// <returns>A Task<bool> that will be true if the host is reachable and responds, false otherwise.</returns>
    public static async Task<bool> IsIpActiveAsync(
        string IP4AddressOrSystemName,
        int timeoutMs = 50
    )
    {
        //Logger.ShowFunction();
        if (string.IsNullOrWhiteSpace(IP4AddressOrSystemName))
        {
            Logger.Error("Error: IP address or SystemName cannot be empty.");
            return false;
        }

        try
        {
            using (Ping pingSender = new Ping())
            {
                PingOptions options = new PingOptions();
                options.Ttl = 128;
                options.DontFragment = true;

                PingReply reply = await pingSender.SendPingAsync(IP4AddressOrSystemName, timeoutMs);

                if (reply.Status == IPStatus.Success)
                {
                    Logger.Info($"Async Ping to {IP4AddressOrSystemName} successful.");
                    //Logger.Info($"Address: {reply.Address}");
                    //Logger.Info($"RoundTrip time: {reply.RoundtripTime} ms");
                    return true;
                }
                else
                {
                    //not an error, just nothing there :)
                    //Logger.Error($"Async Ping to {IP4AddressOrSystemName} failed: {reply.Status}");
                    return false;
                }
            }
        }
        catch (PingException ex)
        {
            Logger.Error($"Async Ping exception for {IP4AddressOrSystemName}: {ex.Message}");
            return false;
        }
        catch (Exception ex)
        {
            Logger.Error(
                $"An unexpected error occurred while async pinging {IP4AddressOrSystemName}: {ex.Message}"
            );
            return false;
        }
    }
    /*
        public static string MergeString(string? newString, string? existing)
        {
            Logger.ShowFunction();
            // Both null or whitespace
            if (string.IsNullOrWhiteSpace(newString) && string.IsNullOrWhiteSpace(existing))
                return string.Empty;
    
            // Only newString is null or whitespace
            if (string.IsNullOrWhiteSpace(newString))
                return existing ?? string.Empty;
    
            // Only existing is null or whitespace
            if (string.IsNullOrWhiteSpace(existing))
                return newString ?? string.Empty;
    
            // Both are non-empty and equal
            if (newString == existing)
                return existing;
    
            if (newString == Constants.strUNDEFINED)
                return existing;
    
            if (existing == Constants.strUNDEFINED)
                return newString;
    
            // Both are non-empty and different
            // So we will go with newstring
            return newString;
        }
    
        public static T MergeEnums<T>(T newValue, T existing)
            where T : struct, Enum
        {
            Logger.ShowFunction();
    
            // If both are equal, return either
            if (EqualityComparer<T>.Default.Equals(newValue, existing))
                return existing;
    
            // If newValue is UNDEFINED, return existing
            if (newValue.ToString().Equals("UNDEFINED", StringComparison.OrdinalIgnoreCase))
                return existing;
    
            // If existing is UNDEFINED, return newValue
            if (existing.ToString().Equals("UNDEFINED", StringComparison.OrdinalIgnoreCase))
                return newValue;
    
            // Otherwise, prefer newValue
            return newValue;
        }
    
        public static int MergeInt(int? newValue, int? existing)
        {
            Logger.ShowFunction();
            // Both null
            if (!newValue.HasValue && !existing.HasValue)
                return 0;
    
            // Only newValue is null
            if (!newValue.HasValue)
                return existing ?? 0;
    
            // Only existing is null
            if (!existing.HasValue)
                return newValue.PublicValue;
    
            // Both have_values and are equal
            if (newValue.PublicValue == existing.PublicValue)
                return existing.PublicValue;
    
            if (newValue == 0)
                return existing.PublicValue;
    
            if (newValue == 0)
                return newValue.PublicValue;
    
            // Both have_values and are different
            // Here we return newValue, but you can customize this logic
            return newValue.PublicValue;
        }
    
      
        */
}
