using System.ComponentModel.DataAnnotations;

namespace Application.Auth.Dtos
{
    public sealed record RegisterDto
    {
        [MaxLength(30, ErrorMessage = "First name must be less than 31")]
        [MinLength(3, ErrorMessage = "First name must be greater than 2")]
        public string Fname { get; set; }
        [MaxLength(30, ErrorMessage = "Last name must be less than 31")]
        [MinLength(3, ErrorMessage = "Last name must be greater than 2")]
        public string Lname { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email form enter for example : ex@gmail.com")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirmed Password must match Password")]
        public string ConfirmPassword { get; set; }

    }
}
