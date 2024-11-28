namespace MovieSystem.Domain.Entities.Commen
{
    public class MovieCast : BaseEntity
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
       
        public int CastId { get; set; }
        public Cast Cast { get; set; }
    }
}
