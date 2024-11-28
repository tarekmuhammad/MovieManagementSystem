namespace MovieSystem.Application.Repository.Interface
{
    public interface IAssignRepository
    {
        Task AssignUserToRole(string roleId, string userId);
        Task AssignUserToPermission(int permissionId, string userId);
        Task AssignRoleToPermission(string roleId, int permissionId);

        Task RevokeUserRole(string userId, string roleId);
        Task RevokeUserPermission(string userId, int permissionId);

        Task RevokeRolePermission(string roleId, int permissionId);
    }
}
