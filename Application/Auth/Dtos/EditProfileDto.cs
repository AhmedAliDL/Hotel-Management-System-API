using System.Text.Json.Serialization;

namespace Application.Auth.Dtos
{
    public class EditProfileDto
    {
        [JsonIgnore]
        public string Email { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
    }
}
