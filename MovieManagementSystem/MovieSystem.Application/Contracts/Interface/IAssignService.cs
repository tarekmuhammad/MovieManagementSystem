 namespace MovieSystem.Application.Contracts.Interface
{
    public interface IAssignService
    {
        Task AssignUserToRole(string roleId, string userId);
        Task RevokeUserRole(string userId, string roleId);


        Task AssignUserToPermission(int permissionId, string userId);
        Task RevokeUserPermission(string userId, int permissionId);

        Task AssignRoleToPermission(string roleId, int permissionId);
        Task RevokeRolePermission(string roleId, int permissionId);
    }
}
 