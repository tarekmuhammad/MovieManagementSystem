using MovieSystem.Application.DTO;

namespace MovieSystem.Application.Contracts.Interface
{
    public interface IReviewService
    {

        Task<IEnumerable<ReviewDetailsDto>> GetAllReviews();

        Task CreateReview(ReviewCreateDto model);
        Task UpdateReview(ReviewUpdateDto model);
        Task DeleteReview(int id);

    }
}
