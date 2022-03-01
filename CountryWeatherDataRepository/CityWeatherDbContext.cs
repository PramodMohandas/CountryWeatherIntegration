using CountryWeatherDataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryWeatherDataRepository
{
    public class CityWeatherDbContext:DbContext
    {
        public CityWeatherDbContext(DbContextOptions<CityWeatherDbContext> opt) : base(opt)
        {

        }
        public DbSet<CityWeather> CityWeather { get; set; }
    }
}
