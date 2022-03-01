using System;
using System.ComponentModel.DataAnnotations;

namespace CountryWeatherDataModel
{
    public class CityWeather
    {
        [Key]
        public int Id { get; set; }

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

        public string CurrenyCode { get; set; }

        public string CountryCode { get; set; }

        public string Temp { get; set; }

        public string Summary { get; set; }



    }
}
