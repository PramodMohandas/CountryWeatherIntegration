
using CountryWeatherDataModel;
using CountryWeatherDataRepository;
using CountryWeatherService;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CountryWeatherIntegrationTest
{
    public class CityWeatherServiceTest
    {
        private readonly Mock<IDataRepository> _mockRepo;
        private readonly DataService _dataService;
        private readonly Mock<IOptions<AppSettings>> _mockAppSettings;
        public CityWeatherServiceTest()
        {
            _mockRepo = new Mock<IDataRepository>();
            _mockAppSettings = new Mock<IOptions<AppSettings>>();
            _dataService = new DataService(_mockRepo.Object, _mockAppSettings.Object);
        }
        [Fact]
        public async Task GetCityById_CityWeather_WIthIdMatching()
        {

            //Arrange
            CityWeather cw = new CityWeather()
            {
                Id = 1,
                Name = "London",
                State = "London",
                Country = "United Kingdom of Great Britain and Northern Ireland",
                EstablishedDate = DateTime.Now,
                EstimatedPopulation = 5000
            
            };
            _mockRepo.Setup(c => c.GetCityById(cw.Id)).ReturnsAsync(cw);
           
            //Act
            
            var result = await _dataService.GetCityById(cw.Id);

         
            //Assert
         
            Assert.Equal(cw.Name, result.Name);
            Assert.Equal(cw.State, result.State);
            Assert.Equal(cw.Country, result.Country);


        }
    }
}
