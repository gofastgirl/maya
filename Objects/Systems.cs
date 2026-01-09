using umanage_app;

public class Systems
{
    private List<SystemDetails> systems = new List<SystemDetails>();

    public List<SystemDetails> GetSystemsCopy()
    {
        return systems.ToList();
    }

    public void AddWithoutChecking(string ip)
    {
        Logger.ShowFunction();

        SystemDetails s = new SystemDetails(ip, 0, "Undefined");
        systems.Add(s);
    }

    public void AddOrUpdate(SystemDetails newsystem)
    {
        Logger.ShowFunction();

        SystemDetails? existing = Find(
            newsystem.Ip4Address.Value,
            newsystem.Ip4Port.Value,
            newsystem.SystemName.Value
        );

        if (existing == null)
        {
            Logger.Debug("Adding new system: " + newsystem.ToString_Short());
            systems.Add(newsystem);
        }
        else
        {
            Logger.Info(
                "Merging existing system: "
                    + existing.ToString_Short()
                    + " with new data: "
                    + newsystem.ToString_Short()
            );
            newsystem.Merge(existing);
            systems.Remove(existing);
            systems.Add(newsystem);
        }
    }

    public SystemDetails? Find(string ip, int port, string SystemName)
    {
        // Find a system by its IP address or IP address and name
        Logger.ShowFunction();
        //return systems.FirstOrDefault(s => s.IP4Address == ip && s.SystemName == SystemName);

        string ipNorm = ip?.Trim() ?? Constants.strEMPTY;
        string hostNorm = SystemName?.Trim() ?? Constants.strEMPTY;
        bool ipIsNull = ip == null;
        bool ipIsEmpty = ipNorm == Constants.strEMPTY;
        bool ipIsUndefined = ipNorm.Equals(
            Constants.strUNDEFINED,
            StringComparison.OrdinalIgnoreCase
        );

        bool portIsUndefined = port == 0;

        bool hostIsNull = SystemName == null;
        bool hostIsEmpty = hostNorm == Constants.strEMPTY;
        bool hostIsUndefined = hostNorm.Equals(
            Constants.strUNDEFINED,
            StringComparison.OrdinalIgnoreCase
        );

        // 27 unique combinations
        // 1. ip=null, port=UNDEFINED, SystemName=null
        if (ipIsNull && portIsUndefined && hostIsNull)
        { /* handle */
            return null;
        }

        // 2. ip=null, port=UNDEFINED, SystemName=Globals.EMPTY
        if (ipIsNull && portIsUndefined && hostIsEmpty)
        { /* handle */
            return null;
        }

        // 3. ip=null, port=UNDEFINED, SystemName=Globals.UNDEFINED
        if (ipIsNull && portIsUndefined && hostIsUndefined)
        { /* handle */
            return null;
        }

        // 4. ip=null, port=UNDEFINED, SystemName=valid
        if (ipIsNull && portIsUndefined && !(hostIsNull || hostIsEmpty || hostIsUndefined))
        { /* handle */
            return null;
        }

        // 5. ip=null, port=valid, SystemName=null
        if (ipIsNull && !portIsUndefined && hostIsNull)
        { /* handle */
            return null;
        }

        // 6. ip=null, port=valid, SystemName=Globals.EMPTY
        if (ipIsNull && !portIsUndefined && hostIsEmpty)
        { /* handle */
            return null;
        }

        // 7. ip=null, port=valid, SystemName=Globals.UNDEFINED
        if (ipIsNull && !portIsUndefined && hostIsUndefined)
        { /* handle */
            return null;
        }

        // 8. ip=null, port=valid, SystemName=valid
        if (ipIsNull && !portIsUndefined && !(hostIsNull || hostIsEmpty || hostIsUndefined))
        { /* handle */
            return null;
        }

        // 9. ip=Globals.EMPTY, port=UNDEFINED, SystemName=null
        if (ipIsEmpty && portIsUndefined && hostIsNull)
        { /* handle */
            return null;
        }

        // 10. ip=Globals.EMPTY, port=UNDEFINED, SystemName=Globals.EMPTY
        if (ipIsEmpty && portIsUndefined && hostIsEmpty)
        { /* handle */
            return null;
        }

        // 11. ip=Globals.EMPTY, port=UNDEFINED, SystemName=Globals.UNDEFINED
        if (ipIsEmpty && portIsUndefined && hostIsUndefined)
        { /* handle */
            return null;
        }

        // 12. ip=Globals.EMPTY, port=UNDEFINED, SystemName=valid
        if (ipIsEmpty && portIsUndefined && !(hostIsNull || hostIsEmpty || hostIsUndefined))
        { /* handle */
            return null;
        }

        // 13. ip=Globals.EMPTY, port=valid, SystemName=null
        if (ipIsEmpty && !portIsUndefined && hostIsNull)
        { /* handle */
            return null;
        }

        // 14. ip=Globals.EMPTY, port=valid, SystemName=Globals.EMPTY
        if (ipIsEmpty && !portIsUndefined && hostIsEmpty)
        { /* handle */
            return null;
        }

        // 15. ip=Globals.EMPTY, port=valid, SystemName=Globals.UNDEFINED
        if (ipIsEmpty && !portIsUndefined && hostIsUndefined)
        { /* handle */
            return null;
        }

        // 16. ip=Globals.EMPTY, port=valid, SystemName=valid
        if (ipIsEmpty && !portIsUndefined && !(hostIsNull || hostIsEmpty || hostIsUndefined))
        { /* handle */
            return null;
        }

        // 17. ip=Globals.UNDEFINED, port=UNDEFINED, SystemName=null
        if (ipIsUndefined && portIsUndefined && hostIsNull)
        { /* handle */
            return null;
        }

        // 18. ip=Globals.UNDEFINED, port=UNDEFINED, SystemName=Globals.EMPTY
        if (ipIsUndefined && portIsUndefined && hostIsEmpty)
        { /* handle */
            return null;
        }

        // 19. ip=Globals.UNDEFINED, port=UNDEFINED, SystemName=Globals.UNDEFINED
        if (ipIsUndefined && portIsUndefined && hostIsUndefined)
        { /* handle */
            return null;
        }

        // 20. ip=Globals.UNDEFINED, port=UNDEFINED, SystemName=valid
        if (ipIsUndefined && portIsUndefined && !(hostIsNull || hostIsEmpty || hostIsUndefined))
        { /* handle */
            return null;
        }

        // 21. ip=Globals.UNDEFINED, port=valid, SystemName=null
        if (ipIsUndefined && !portIsUndefined && hostIsNull)
        { /* handle */
            return null;
        }

        // 22. ip=Globals.UNDEFINED, port=valid, SystemName=Globals.EMPTY
        if (ipIsUndefined && !portIsUndefined && hostIsEmpty)
        { /* handle */
            return null;
        }

        // 23. ip=Globals.UNDEFINED, port=valid, SystemName=Globals.UNDEFINED
        if (ipIsUndefined && !portIsUndefined && hostIsUndefined)
        { /* handle */
            return null;
        }

        // 24. ip=Globals.UNDEFINED, port=valid, SystemName=valid
        if (ipIsUndefined && !portIsUndefined && !(hostIsNull || hostIsEmpty || hostIsUndefined))
        { /* handle */
            return null;
        }

        // 25. ip=valid, port=UNDEFINED, SystemName=null
        if (!(ipIsNull || ipIsEmpty || ipIsUndefined) && portIsUndefined && hostIsNull)
        { /* handle */
            return null;
        }

        // 26. ip=valid, port=UNDEFINED, SystemName=Globals.EMPTY
        if (!(ipIsNull || ipIsEmpty || ipIsUndefined) && portIsUndefined && hostIsEmpty)
        { /* handle */
            return null;
        }

        // 27. ip=valid, port=UNDEFINED, SystemName=Globals.UNDEFINED
        if (!(ipIsNull || ipIsEmpty || ipIsUndefined) && portIsUndefined && hostIsUndefined)
        { /* handle */
            return systems.FirstOrDefault(s => s.Ip4Address.Value == ip);
        }

        // 28. ip=valid, port=UNDEFINED, SystemName=valid
        if (
            !(ipIsNull || ipIsEmpty || ipIsUndefined)
            && portIsUndefined
            && !(hostIsNull || hostIsEmpty || hostIsUndefined)
        )
        { /* handle */
            return systems.FirstOrDefault(s =>
                s.Ip4Address.Value == ip && s.SystemName.Value == SystemName
            );
        }

        // 29. ip=valid, port=valid, SystemName=null
        if (!(ipIsNull || ipIsEmpty || ipIsUndefined) && !portIsUndefined && hostIsNull)
        { /* handle */
            return systems.FirstOrDefault(s => s.Ip4Address.Value == ip && s.Ip4Port.Value == port);
        }

        // 30. ip=valid, port=valid, SystemName=Globals.EMPTY
        if (!(ipIsNull || ipIsEmpty || ipIsUndefined) && !portIsUndefined && hostIsEmpty)
        { /* handle */
            return systems.FirstOrDefault(s => s.Ip4Address.Value == ip && s.Ip4Port.Value == port);
        }

        // 31. ip=valid, port=valid, SystemName=Globals.UNDEFINED
        if (!(ipIsNull || ipIsEmpty || ipIsUndefined) && !portIsUndefined && hostIsUndefined)
        { /* handle */
            return systems.FirstOrDefault(s => s.Ip4Address.Value == ip && s.Ip4Port.Value == port);
        }

        // 32. ip=valid, port=valid, SystemName=valid
        if (
            !(ipIsNull || ipIsEmpty || ipIsUndefined)
            && !portIsUndefined
            && !(hostIsNull || hostIsEmpty || hostIsUndefined)
        )
        {
            // This is the "all valid" case
            return systems.FirstOrDefault(s =>
                s.Ip4Address.Value == ipNorm
                && s.Ip4Port.Value == port
                && s.SystemName.Value == hostNorm
            );
        }

        // Default: not found
        return null;
    }

    public SystemDetails? Find(string ip, int port)
    {
        Logger.ShowFunction();
        // Find a system by its IP address or IP address and name
        if (string.IsNullOrWhiteSpace(ip))
        {
            return null;
        }

        return systems.FirstOrDefault(s => s.Ip4Address.Value == ip && s.Ip4Port.Value == port);
    }

    public SystemDetails? Find(SystemDetails details)
    {
        // Find a system by its details
        return Find(details.Ip4Address.Value, details.Ip4Port.Value, details.SystemName.Value);
    }

    public void PrintAll()
    {
        Logger.ShowFunction();
        foreach (var system in systems)
        {
            Logger.Info(system.ToString_Long());
        }
    }
}
