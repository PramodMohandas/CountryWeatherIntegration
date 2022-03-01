using System;
using System.ComponentModel.DataAnnotations;

namespace CountryWeatherIntegration.Dtos
{
    public class CityWeatherCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public int TouristRating { get; set; }

        [Required]
        public DateTime EstablishedDate { get; set; }

        [Required]
        public int EstimatedPopulation { get; set; }

    }
}
