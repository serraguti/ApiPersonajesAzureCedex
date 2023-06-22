using ApiPersonajesAzureCedex.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NugetSeriesPersonajes;

namespace ApiPersonajesAzureCedex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private RepositorySeries repo;

        public SeriesController(RepositorySeries repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Serie>>> GetSeries()
        {
            return await this.repo.GetSeriesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Serie>> FindSerie(int id)
        {
            return await this.repo.FindSerieAsync(id);
        }
    }
}
