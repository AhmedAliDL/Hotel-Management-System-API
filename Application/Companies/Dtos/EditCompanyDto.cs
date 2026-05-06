using Domain.Enums;
using System.Text.Json.Serialization;

namespace Application.Companies.Dtos
{
    public record EditCompanyDto
    {
        public string? CompanyName { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Country? Country { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public City? City { get; set; }
        public string? Address { get; set; }
    }
}
