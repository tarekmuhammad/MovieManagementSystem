 namespace MovieSystem.Application.DTO
{
    public class MovieDetailsDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }
        public bool IsFree { get; set; }
        public CategoryUpdateDto Category { get; set; }
        public ICollection<ReviewDetailsDto> Reviews { get; set; }
    }

    public class MovieCreateDto : BaseDto
    {
        public string  Name { get; set; }
        public string  Description { get; set; }
        public string  Image { get; set; }
        public string  Video { get; set; }
        public bool    IsFree { get; set; }
        public string  CategoryId { get; set; }
    }


    public class MovieUpdateDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }
        public bool   IsFree { get; set; }
        public string CategoryId { get; set; }
    }


    public class MovieDeleteDto 
    {
        public int Id { get; set; }
    }
    public class MovieReviewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }




}
