namespace umanage_app
{
    public interface ISystems
    {
        //public static abstract Task<SystemDetails> ScanThisSystem(string ip);
        public static abstract Task ScanThisSystem(SystemDetails details);

        public static abstract Task<bool> IsCorrectSystem(SystemDetails details);
    }
}
