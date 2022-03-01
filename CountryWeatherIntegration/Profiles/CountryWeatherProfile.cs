using AutoMapper;
using CountryWeatherDataModel;
using CountryWeatherIntegration.Dtos;

namespace CountryWeatherIntegration.Profiles
{
    public class CountryWeatherProfile: Profile
    {
        public CountryWeatherProfile() 
        {
            CreateMap<CityWeather, CityWeatherReadDto>();
            CreateMap<CityWeatherCreateDto, CityWeather>();
            CreateMap<CityWeatherUpdateDto, CityWeather>();
        }
    }
}
