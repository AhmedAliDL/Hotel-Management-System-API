using System.Text.Json.Serialization;

namespace Application.Auth.Dtos
{
    public sealed record RefreshTokenDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        [JsonIgnore]
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
