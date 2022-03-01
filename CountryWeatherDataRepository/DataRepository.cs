using CountryWeatherDataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryWeatherDataRepository
{
    public class DataRepository : IDataRepository
    {
        private readonly CityWeatherDbContext _context;

        public DataRepository(CityWeatherDbContext context)
        {
            _context = context;
        }

        public void CreateCity(CityWeather cw)
        {
            if (cw == null)
            {
                throw new ArgumentException(nameof(cw));
            }
            _context.CityWeather.Add(cw);
        }

        public void DeleteCity(CityWeather cw)
        {
            if (cw == null)
            {
                throw new ArgumentException(nameof(cw));
            }
            _context.CityWeather.Remove(cw);
        }

        public async Task<IList<CityWeather>> GetAllCities()
        {
            return await _context.CityWeather.ToListAsync();
        }

        public async Task<IList<CityWeather>> GetAllCityByName(string countryName)
        {
             var cityWeather = await _context.CityWeather.ToListAsync();
             return cityWeather.Where(p => p.Name.Contains(countryName)).ToList();
        }

        public async Task<CityWeather> GetCityById(int id)
        {
            return await _context.CityWeather.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public void UpdateCity(CityWeather cw)
        {
            //throw new NotImplementedException();
        }
    }
}
