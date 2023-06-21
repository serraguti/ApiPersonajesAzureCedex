using Microsoft.EntityFrameworkCore;
using NugetSeriesPersonajes;

namespace ApiPersonajesAzureCedex.Data
{
    public class SeriesContext: DbContext
    {
        public SeriesContext(DbContextOptions<SeriesContext> options) : base(options) { }

        public DbSet<Serie> Series { get; set; }
        public DbSet<Personaje> Personajes { get; set; }
    }
}
