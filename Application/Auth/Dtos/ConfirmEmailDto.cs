using System.ComponentModel.DataAnnotations;

namespace Application.Auth.Dtos
{
    public class ConfirmEmailDto
    {
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string UserEmail { get; set; }
        public string Token { get; set; }
    }
}
