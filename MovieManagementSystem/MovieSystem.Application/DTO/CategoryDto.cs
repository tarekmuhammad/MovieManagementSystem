namespace MovieSystem.Application.DTO
{
    public class CategoryDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public ICollection<MovieDetailsDto> Movies { get; set; }
    }

    public class ParentCategoryDto : BaseDto
    {
        public string Name { get; set; }
    }


    public class SubCategoryDto : BaseDto
    {
        public string Name { get; set; }
        public int ParentId { get; set; }
    }


    public class CategoryUpdateDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }


    public class CategoryDeleteDto
    {
        public int Id { get; set; }
    }

}
