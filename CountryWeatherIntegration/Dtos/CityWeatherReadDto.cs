using System;

namespace CountryWeatherIntegration.Dtos
{
    public class CityWeatherReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int TouristRating { get; set; }
        public DateTime EstablishedDate { get; set; }
        public int EstimatedPopulation { get; set; }
        public string CurrenyCode { get; set; }
        public string CountryCode { get; set; }
        public string Temp { get; set; }
        public string Summary { get; set; }
    }
}
