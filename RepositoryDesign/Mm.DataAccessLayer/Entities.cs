namespace Mm.DataAccessLayer
{
    using DomainModel;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=SchoolDBEntities")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
