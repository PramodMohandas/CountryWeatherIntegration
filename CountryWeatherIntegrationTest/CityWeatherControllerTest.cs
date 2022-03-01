using AutoMapper;
using CountryWeatherDataModel;
using CountryWeatherDataRepository;
using CountryWeatherIntegration.Controllers;
using CountryWeatherService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CountryWeatherIntegrationTest
{
    public class CityWeatherControllerTest
    { 
        private readonly Mock<IDataService> _iDataService;
        private readonly CityWeatherUnitTestController valuesController;
        public CityWeatherControllerTest()
        {
           
            _iDataService = new Mock<IDataService>();
            valuesController = new CityWeatherUnitTestController(_iDataService.Object);
        }
        [Fact]
        public async Task GetCityByIdFromController_CityWeather_WIthIdMatching()
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
            _iDataService.Setup(c => c.GetCityById(cw.Id)).ReturnsAsync(cw);

            //Act

            var result = await  valuesController.GetCityByIdFromValues(cw.Id) ;


            //Assert
            Assert.IsType<ActionResult<CityWeather>>(result);
            Assert.Equal(cw.Name, ((CityWeather)((ObjectResult)result.Result).Value).Name);
            Assert.Equal(cw.State, ((CityWeather)((ObjectResult)result.Result).Value).State);
            Assert.Equal(cw.Country,((CityWeather)((ObjectResult)result.Result).Value).Country);


        }


    }
}
