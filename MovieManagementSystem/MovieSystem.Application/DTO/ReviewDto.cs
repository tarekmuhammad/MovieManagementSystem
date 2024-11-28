using MovieSystem.Domain.Entities.Commen;

namespace MovieSystem.Application.DTO
{
    public class ReviewDetailsDto : BaseDto
    {

        public int Id { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
        public DateTime Date { get; set; }
        public UserReviewDto User { get; set; }
        public MovieReviewDto Movie { get; set; }
        public ICollection<Like> Likes { get; set; }

    }



 

    public class ReviewCreateDto : BaseDto
    {
        public string Content { get; set; }
        public int Rate { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }


 


    public class ReviewUpdateDto : BaseDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }


    public class ReviewDeleteDto
    {
        public int Id { get; set; }
    }
}
