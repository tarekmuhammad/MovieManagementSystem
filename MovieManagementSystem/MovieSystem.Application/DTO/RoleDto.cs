namespace MovieSystem.Application.DTO
{
    public class RoleDto
    {
    }


    public class RoleDetailsDto : BaseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<RoleUserDto> RoleUser { get; set; }
        public ICollection<PermissionDto> Permissions { get; set; }
    }

    public class RoleCreateDto : BaseDto
    {
        public string? Name { get; set; }
    }


    public class RoleUpdateDto : BaseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }


    public class RoleDeleteDto
    {
        public int Id { get; set; }
    }
}
