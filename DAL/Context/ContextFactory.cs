namespace DAL.Context
{
    public class ContextFactory
    {
        public static CompanyDbContext Create()
        {
            return new CompanyDbContext();
        }
    }
}
