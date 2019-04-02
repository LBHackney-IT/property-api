using Microsoft.EntityFrameworkCore;
using property_api.V1.Domain;

namespace property_api.V1.Infrastructure
{
    public interface IUHContext
    {
        DbSet<UhPropertyEntity> UhPropertys { get; set; }
    }
}
