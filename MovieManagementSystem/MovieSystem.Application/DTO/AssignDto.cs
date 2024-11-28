
namespace MovieSystem.Application.DTO
{
 

    public class AssignUserRoleDto : BaseDto
    {
        public string userId { get; set; }
        public string roleId { get; set; }
    }

    public class AssignUserPermissionDto : BaseDto
    {
        public string userId { get; set; }
        public int permissionId { get; set; }
    }


    public class AssignRolePermissionDto : BaseDto
    {
        public string roleId { get; set; }
        public int permissionId { get; set; }
    }

}
