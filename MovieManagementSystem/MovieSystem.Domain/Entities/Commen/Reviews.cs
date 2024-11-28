namespace MovieSystem.Domain.Entities.Commen
{
    public class Reviews : BaseEntity
    {

        public int Id { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
       // public Users User { get; set; }
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}
