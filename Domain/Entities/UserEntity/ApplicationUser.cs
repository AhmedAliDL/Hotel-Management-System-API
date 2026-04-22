using Domain.Entities.BranchEntity;
using Domain.Entities.CompanyEntity;
using Domain.Entities.SystemEmployeeEntity;
using Domain.Entities.UserEntity;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.User
{
    public class ApplicationUser : IdentityUser<Guid>
    {

        public string Fname { get; set; }
        public string Lname { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime LastLoginAt { get; set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; set; }

        public ICollection<Company> Companies { get; set; }
        public ICollection<SystemEmployee> SystemEmployees { get; set; }
        public ICollection<Branch> Branches { get; set; }
        public ICollection<RefreshToken>? RefreshTokens { get; set; }
    }
}
