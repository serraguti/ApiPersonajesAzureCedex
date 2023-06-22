using ApiPersonajesAzureCedex.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using NugetSeriesPersonajes;

namespace ApiPersonajesAzureCedex.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;

        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }

        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await this.context.Series.ToListAsync();
        }

        public async Task<Serie> FindSerieAsync(int id)
        {
            return await this.context.Series.FirstOrDefaultAsync(x => x.IdSerie == id);
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje> FindPersonajeAsync(int id)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == id);
        }

        public async Task<List<Personaje>> GetPersonajesSerieAsync(int idserie)
        {
            return await this.context.Personajes.Where
                (z => z.IdSerie == idserie).ToListAsync();
        }

        private async Task<int> GetMaxIdPersonajeAsync()
        {
            if (this.context.Personajes.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await this.context.Personajes.MaxAsync(x => x.IdPersonaje) + 1;
            }
        }

        public async Task CreatePersonajeAsync(string nombre, string imagen, int idserie)
        {
            Personaje personaje = new Personaje();
            personaje.IdPersonaje = await this.GetMaxIdPersonajeAsync();
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.IdSerie = idserie;
            this.context.Personajes.Add(personaje);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonajeSerieAsync(int idpersonaje, int idserie)
        {
            Personaje personaje = await this.FindPersonajeAsync(idpersonaje);
            personaje.IdSerie = idserie;
            await this.context.SaveChangesAsync();
        }
    }
}
