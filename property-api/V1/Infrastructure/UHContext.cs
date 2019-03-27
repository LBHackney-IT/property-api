using Microsoft.EntityFrameworkCore;
using property_api.V1.Domain;

namespace property_api.V1.Infrastructure
{
    public class UhContext : DbContext, IUHContext
    {
        public UhContext(DbContextOptions options) : base(options) {}

        public DbSet<UhProperty> UhPropertys { get; set; }
    }
}
