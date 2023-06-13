namespace Trashtalk.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(TrashTalkDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
