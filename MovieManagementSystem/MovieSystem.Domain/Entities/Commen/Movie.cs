namespace MovieSystem.Domain.Entities.Commen
{
    public class Movie : BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string Video { get; set; } 
        public bool IsFree { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeOnly Duration { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
        public ICollection<MovieCast> MovieCast { get; set; }
        //public ICollection<UserMovie> History { get; set; }
    }
}
