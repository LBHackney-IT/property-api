using Microsoft.EntityFrameworkCore;
using property_api.V1.Data.Entities;

namespace property_api.V1.Data
{
    public class UhContext : DbContext, IUHContext
    {
        public UhContext(DbContextOptions options) : base(options) {}

        public DbSet<UhPropertyEntity> UhPropertys { get; set; }
    }
}
