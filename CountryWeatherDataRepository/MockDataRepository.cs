using CountryWeatherDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CountryWeatherDataRepository
{
    public class MockDataRepository : IDataRepository
    {
        public void CreateCity(CityWeather cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCity(CityWeather cmd)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<CityWeather>> GetAllCities()
        {
            throw new NotImplementedException();
        }

        public Task<IList<CityWeather>> GetAllCityByName(string countryName)
        {
            //return  new List<CountryWeather> { new CountryWeather { Id = 1, Name = "London", State = "London", Country = "UK" },
            //                                  new CountryWeather { Id = 2, Name = "Bristol;", State = "Bristol", Country = "UK" },
            //                                  new CountryWeather { Id = 3, Name = "Lancester;", State = "Lancester", Country = "UK" }
            //                                }.Where(p => p.Name.Contains(countryName)).ToList();
            throw new NotImplementedException();
        }

        public async Task<CityWeather> GetCityById(int id)
        {
            
            throw new NotImplementedException();
        }

        public Task<bool> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCity(CityWeather cmd)
        {
            throw new NotImplementedException();
        }
    }
}
