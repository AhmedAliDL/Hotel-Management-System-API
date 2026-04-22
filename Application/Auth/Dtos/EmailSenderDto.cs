using Domain.Entities.User;
using System.ComponentModel.DataAnnotations;

namespace Application.Auth.Dtos
{
    public sealed record EmailSenderDto
    {
        [MaxLength(40)]
        [MinLength(3)]
        public string Subject { get; set; }
        [MinLength(3)]
        public string Body { get; set; }

        public ApplicationUser? User { get; set; }
    }
}
