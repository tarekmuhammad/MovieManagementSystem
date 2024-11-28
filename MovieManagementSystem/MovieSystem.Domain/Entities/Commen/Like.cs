namespace MovieSystem.Domain.Entities.Commen
{
    public class Like
    {
        public int Id { get; set; }
        //public int UserId { get; set; }
        //public Users? User { get; set; }
        public int Reviewid { get; set; }
        public Reviews? Review { get; set; }
        public int isLiked { get; set; }

    }
}
