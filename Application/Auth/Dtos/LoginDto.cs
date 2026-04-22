using System.ComponentModel.DataAnnotations;

namespace Application.Auth.Dtos
{
    public sealed record LoginDto
    {
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
