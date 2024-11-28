 namespace MovieSystem.Domain.Entities.Commen
{
    public class UserMovie : BaseEntity
    {
        //public int UserId { get; set; }
       // public Users User { get; set; }
        //public int MovieId { get; set; }
        //public Movie Movie { get; set; }
        public DateTime watchDate { get; set; }
        public DateTime lastSeen { get; set; }
    }
}
