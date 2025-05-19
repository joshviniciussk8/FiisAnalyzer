using FiiAnalyzer.Core;
using FiiAnalyzer.Infrastructure;
using FiiAnalyzer.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FiiAnalyzer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FiisController : ControllerBase
    {
        [HttpGet(Name = "GetFiis")]
        public IEnumerable<FiiDto> GetFiis()
        {
            FiiScraper scraper = new FiiScraper();
            List<FiiDto> fiis = scraper.ObterLista();

            var filtro = new FiiFilter();
            var filtrados = filtro.FiltroDefault(fiis, 8);
            return filtrados;
        }
    }
}
