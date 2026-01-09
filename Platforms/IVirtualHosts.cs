namespace umanage_app
{
    public interface IVirtualHosts : ISystems
    {
        static abstract void Start();
        static abstract void Stop();
        static abstract void Restart();
        static abstract void Rename(string newValue);
        static abstract void Delete();
    }
}
