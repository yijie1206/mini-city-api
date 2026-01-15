using Microsoft.EntityFrameworkCore;
using MiniCityApi.DomainModel;

namespace MiniCityApi.Data
{
    public class CityDbContext : DbContext
    {
        public DbSet<CityModel>Cities{get; set;}

        public CityDbContext(DbContextOptions<CityDbContext>options):base (options)
        { 
        
        }
    }
}
