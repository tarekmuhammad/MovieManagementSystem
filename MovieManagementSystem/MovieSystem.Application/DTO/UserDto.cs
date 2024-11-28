using MovieSystem.Domain.Entities.Commen;

namespace MovieSystem.Application.DTO
{ 

    public class UserDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Type { get; set; }
        public ICollection<RoleUserDto> RoleUser { get; set; }
        public ICollection<ReviewDetailsDto> Reviews { get; set; }
        public ICollection<Like> Likes { get; set; }
    }

    public class UserCreateDto : BaseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Type { get; set; }
    }


 

    public class UserUpdateDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Type { get; set; }
    }


    public class UserDeleteDto
    {
        public int Id { get; set; }
    }


    public class UserReviewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
