using System;
using System.ComponentModel.DataAnnotations;

namespace CountryWeatherIntegration.Dtos
{
    public class CityWeatherUpdateDto
    {

        [Required]
        public int TouristRating { get; set; }

        [Required]
        public DateTime EstablishedDate { get; set; }

        [Required]
        public int EstimatedPopulation { get; set; }
    }
}
