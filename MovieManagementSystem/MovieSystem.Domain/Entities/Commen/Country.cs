 
namespace MovieSystem.Domain.Entities.Commen
{
    public class Country : BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public ICollection<Cast> Cast { get; set; }
    }
}
