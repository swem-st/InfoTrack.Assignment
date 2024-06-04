using InfoTrack.Assignment.Application.DTO.SearchEngineOptimizationDomain;
using InfoTrack.Assignment.Application.ServicesAbstraction.SearchEngineOptimization;
using InfoTrack.Assignment.Core.Exceptions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace InfoTrack.Assignment.API.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("[controller]")]
    public class SeoController : ControllerBase
    {

        private readonly ILogger<SeoController> _logger;
        public ISeoService _seoService { get; set; }

        public SeoController(ILogger<SeoController> logger, ISeoService seoService)
        {
            _logger = logger;
            _seoService = seoService;
        }

        /// <summary>
        /// Fetch search statistics
        /// </summary>
        /// <remarks>Returns a List of Integer</remarks>
        /// <response code="200">Successful operation.</response>
        /// <response code="400">Unsuccessful operation.</response>

        [HttpPost("fetch/search-statistic")]
        public async Task<ICollection<int>> FetchSearchStatistic(SearchRequestDTO searchRequestDTO)
        {
            try
            {
                var result = await _seoService.FetchSearchStatistic(searchRequestDTO);

                return result;
            }
            catch (Exception ex)
            {
                //Add Logging for genuine exception.
                throw HttpExceptions.StandardInternalError("I'm afraid we failed to fetch the search statistic.");
            }
         
        }
    }
}