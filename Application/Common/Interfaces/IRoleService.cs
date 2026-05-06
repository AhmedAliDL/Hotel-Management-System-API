namespace Application.Common.Interfaces
{
    public interface IRoleService : IServiceMarker
    {
        Task CreateRoleAsync(string roleName);
    }
}
