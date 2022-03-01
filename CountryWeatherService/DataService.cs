using CountryWeatherDataModel;
using CountryWeatherDataRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json; 
using System.Linq;
using Microsoft.Extensions.Options;
using RESTCountries.Services;
namespace CountryWeatherService
{
    public class DataService : IDataService
    {
        public readonly IDataRepository _iDataRepository;
        private readonly AppSettings _appSettings;
        public DataService(IDataRepository iDataRepository, IOptions<AppSettings> appSettings) 
        { 
            _iDataRepository= iDataRepository;
            _appSettings = appSettings.Value;
        }
        public void CreateCity(CityWeather cw)
        {
            _iDataRepository.CreateCity(cw);
        }

        public void DeleteCity(CityWeather cw)
        {
            _iDataRepository.DeleteCity(cw);
        }

        public async Task<IList<CityWeather>> GetAllCities()
        {
            return await _iDataRepository.GetAllCities();
        }

        public async Task<IList<CityWeather>> GetAllCityByName(string countryName)
        {
            return await _iDataRepository.GetAllCityByName(countryName);
        }

        public async Task<CityWeather> GetCityById(int id)
        {
            return await (_iDataRepository.GetCityById(id));
        }

        public async Task<bool> SaveChanges()
        {
            return await _iDataRepository.SaveChanges();
        }

        public void UpdateCity(CityWeather cw)
        {
           _iDataRepository.UpdateCity(cw);
        }
        public async Task<CityWeather> GetCityWeatherDetails(CityWeather cw)
        {
            using (var client = new HttpClient())
            { 
                client.BaseAddress = new Uri(_appSettings.OpenWeatherApiUri);
                var response = await client.GetAsync($"/data/2.5/weather?q={cw.Name}&appid={_appSettings.OpenWeatherMapKey}&units=metric");
                response.EnsureSuccessStatusCode();

                var stringResult = await response.Content.ReadAsStringAsync();
                var rawWeather = JsonConvert.DeserializeObject<OpenWeatherResponse>(stringResult);
                cw.Temp = rawWeather.Main.Temp;
                cw.Summary = string.Join(",", rawWeather.Weather.Select(x => x.Main));
                var country = await RESTCountriesAPI.GetCountryByFullNameAsync(cw.Country);
                cw.CountryCode = country.CallingCodes[0].ToString();
                cw.CurrenyCode = country.Currencies[0].Code;
                return cw;
            }
        }
    }
}
