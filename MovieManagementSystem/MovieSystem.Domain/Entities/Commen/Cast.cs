using MovieSystem.Domain.Helper;

namespace MovieSystem.Domain.Entities.Commen
{
    public class Cast : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CastType? Type { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<MovieCast> MovieCast { get; set; }
    }
}

  
  