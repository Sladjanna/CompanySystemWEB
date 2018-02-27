using Model;
using Model.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext() : base("name = Connection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new CompanyDbInitializer());
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }
}
