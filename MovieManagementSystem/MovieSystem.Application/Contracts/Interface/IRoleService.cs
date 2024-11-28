using MovieSystem.Application.DTO;

namespace MovieSystem.Application.Contracts.Interface
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDetailsDto>> GetAllRoles();
 
        Task<RoleDetailsDto> GetRole(int id);
 
        Task CreateRole(RoleCreateDto model);
        Task UpdateRole(RoleUpdateDto model);
        Task DeleteRole(int id);
 
    }
}
