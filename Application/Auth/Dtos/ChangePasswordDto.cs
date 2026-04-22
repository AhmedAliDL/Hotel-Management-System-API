using System.ComponentModel.DataAnnotations;

namespace Application.Auth.Dtos
{
    public sealed record ChangePasswordDto
    {
        [EmailAddress(ErrorMessage = "Invalide email address syntax")]
        public string UserEmail { get; set; }
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Confirm Password must be as new password")]
        public string ConfirmNewPassword { get; set; }
    }
}
