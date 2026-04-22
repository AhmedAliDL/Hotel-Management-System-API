namespace Application.Auth.Dtos
{
    public sealed record UserProfileDto
    {
        public string Email { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }

    }
}
