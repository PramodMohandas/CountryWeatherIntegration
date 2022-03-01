using CountryWeatherDataModel;
using CountryWeatherService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CountryWeatherIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityWeatherUnitTestController : ControllerBase
    {
        private readonly IDataService _iDataService;
        public CityWeatherUnitTestController(IDataService iDataService)
        {
            _iDataService = iDataService;

        }
        // GET api/<CityWeatherController>/City/L
        //Retuns Single city
        [HttpGet("City/{id}", Name = "GetCityByIdFromValues")]
        public async Task<ActionResult<CityWeather>> GetCityByIdFromValues(int id)
        {
            var cityWeather = await _iDataService.GetCityById(id);
            if (cityWeather != null)
            {
                return Ok(cityWeather);
            }
            return NotFound();

        }
    }
}
