using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;

namespace Mm.DataAccessLayer
{
    public static class DbContextExtensions
    {
        public static ObjectContext ToObjectContext(this DbContext dbContext)
        {
            return (dbContext as IObjectContextAdapter).ObjectContext;
        }
    }
}
