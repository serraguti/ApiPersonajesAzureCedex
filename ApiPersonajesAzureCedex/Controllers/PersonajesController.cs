using ApiPersonajesAzureCedex.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NugetSeriesPersonajes;
using System.Security.Cryptography.X509Certificates;

namespace ApiPersonajesAzureCedex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositorySeries repo;

        public PersonajesController(RepositorySeries repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>> FindPersonaje(int id)
        {
            return await this.repo.FindPersonajeAsync(id);
        }

        [HttpGet]
        [Route("[action]/{idserie}")]
        public async Task<ActionResult<List<Personaje>>> PersonajesSerie(int idserie)
        {
            return await this.repo.GetPersonajesSerieAsync(idserie);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePersonaje(Personaje personaje)
        {
            await this.repo.CreatePersonajeAsync
                (personaje.Nombre, personaje.Imagen, personaje.IdSerie);
            return Ok();
        }

        [HttpPut]
        [Route("[action]/{idpersonaje}/{idserie}")]
        public async Task<ActionResult> UpdatePersonaje(int idpersonaje, int idserie)
        {
            await this.repo.UpdatePersonajeSerieAsync(idpersonaje, idserie);
            return Ok();
        }
    }
}
