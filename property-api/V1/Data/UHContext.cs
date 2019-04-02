using Microsoft.EntityFrameworkCore;

namespace property_api.V1.Infrastructure
{
    public class UhContext : DbContext, IUHContext
    {
        public UhContext(DbContextOptions options) : base(options) {}

        public DbSet<UhPropertyEntity> UhPropertys { get; set; }
    }
}
