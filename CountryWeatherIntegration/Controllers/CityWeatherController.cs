using AutoMapper;
using CountryWeatherDataModel;
using CountryWeatherIntegration.Dtos;
using CountryWeatherService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Options;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CountryWeatherIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityWeatherController : ControllerBase
    {
        private readonly IDataService _iDataService;
        private readonly IMapper _imapper;
        private readonly AppSettings _appSettings;
        public CityWeatherController(IDataService iDataService, IMapper imapper, IOptions<AppSettings> appSettings)
        {
            _iDataService = iDataService;
            _imapper = imapper;
            _appSettings = appSettings.Value;
        }
        // GET: api/<CityWeatherController>
        // Return all cities in database
        [HttpGet]
        public async Task<ActionResult<IList<CityWeatherReadDto>>> GetAllCities()
        {
            var cityWeatherList = await _iDataService.GetAllCities();
            foreach (var item in cityWeatherList)
            {
                try
                {
                    await _iDataService.GetCityWeatherDetails(item);
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
                }
            }
            if (cityWeatherList.Count > 0)
            {
                return Ok(_imapper.Map<IList<CityWeatherReadDto>>(cityWeatherList));
            }
            return NotFound();
        }

        // GET api/<CityWeatherController>/Cities/L
        // Returns city list contains search key
        [HttpGet("Cities/{cityname}", Name = "GetAllCityByName")]
        public async Task<ActionResult<IList<CityWeatherReadDto>>> GetAllCityByName(string cityname)
        {
            var cityWeather = await _iDataService.GetAllCityByName(cityname);
            foreach (var item in cityWeather)
            {
                try
                {
                    await _iDataService.GetCityWeatherDetails(item);
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
                }
            }
            if (cityWeather.Count > 0)
            {
                return Ok(_imapper.Map<IList<CityWeatherReadDto>>(cityWeather));
            }
            return NotFound();

        }
        // GET api/<CityWeatherController>/City/L
        //Retuns Single city
        [HttpGet("City/{id}", Name = "GetCityById")]
        public async Task<ActionResult<CityWeatherReadDto>> GetCityById(int id)
        {
            var cityWeather = await _iDataService.GetCityById(id);
            if (cityWeather != null)
            {
                try
                {
                    await _iDataService.GetCityWeatherDetails(cityWeather);
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
                }
                return Ok(_imapper.Map<CityWeatherReadDto>(cityWeather));
            }
            return NotFound();

        }

        // POST api/<CountryWeatherController>
        [HttpPost]
        public async Task<ActionResult<CityWeatherCreateDto>> CreateCity(CityWeatherCreateDto cityyWeatherCreateDto)
        {
            var cityWeatherModel = _imapper.Map<CityWeather>(cityyWeatherCreateDto);
            _iDataService.CreateCity(cityWeatherModel);
            await _iDataService.SaveChanges();

            //return Ok(cityWeatherModel);
            var cityWeatherReadDto = _imapper.Map<CityWeatherReadDto>(cityWeatherModel);
            return CreatedAtRoute(nameof(GetCityById), new { id = cityWeatherReadDto.Id }, cityWeatherReadDto);
        }

        // PUT api/<CityWeatherController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCity(int id, CityWeatherUpdateDto cityWeatherUpdateDto)
        {
            var cwModelFromRepo = await _iDataService.GetCityById(id);
            if (cwModelFromRepo == null)
            {
                return NotFound();
            }
            _imapper.Map(cityWeatherUpdateDto, cwModelFromRepo);// This will sync entity framework countryweather model with incoming update dto property values
            //_iDataService.UpdateCountry(cwModelFromRepo);// Not really necessary as above step already accomplised model update
            await _iDataService.SaveChanges();
            return NoContent();
        }

        // DELETE api/<CityWeatherController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cwModelFromRepo = await _iDataService.GetCityById(id);
            if (cwModelFromRepo == null)
            {
                return NotFound();
            }
            _iDataService.DeleteCity(cwModelFromRepo);
            await _iDataService.SaveChanges();
            return NoContent();
        }
    }
}

