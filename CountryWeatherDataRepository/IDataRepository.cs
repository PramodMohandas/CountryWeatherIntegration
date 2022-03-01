using CountryWeatherDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryWeatherDataRepository
{
    public interface IDataRepository
    {
        Task<bool> SaveChanges();
        Task<IList<CityWeather>> GetAllCities();
        Task<IList<CityWeather>> GetAllCityByName(string countryName);
        Task<CityWeather> GetCityById(int id);
        void CreateCity(CityWeather cw);
        void UpdateCity(CityWeather cw);
        void DeleteCity(CityWeather cw);
    }
}
