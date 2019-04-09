using Microsoft.EntityFrameworkCore;
using property_api.V1.Data.Entities;

namespace property_api.V1.Data
{
    public interface IUHContext
    {
        DbSet<UhPropertyEntity> UhPropertys { get; set; }
    }
}
