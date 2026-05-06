using Domain.Enums;
using System.Text.Json.Serialization;

namespace Application.Companies.Dtos
{
    public sealed record class CompanyDto
    {
        [JsonIgnore]
        public string? UserEmail { get; set; }
        public required string CompanyName { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Country Country { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public City City { get; set; }
        public required string Address { get; set; }

    }
}
