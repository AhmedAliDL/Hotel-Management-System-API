using System.ComponentModel.DataAnnotations;

namespace Application.Auth.Dtos
{
    public class EditProfileDto
    {
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        public string Email { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
    }
}
