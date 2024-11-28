using MovieSystem.Application.DTO;

namespace MovieSystem.Application.Contracts.Interface
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDetailsDto>> GetAllMovies();
        Task<IEnumerable<MovieDetailsDto>> GetAllWithCategory();
        Task<MovieDetailsDto> GetMovie(int id);
        Task<IEnumerable<MovieDetailsDto>> GetMovieByCategory(int catId);


        Task CreateMovie(MovieCreateDto model);
        Task UpdateMovie(MovieUpdateDto model);
        Task DeleteMovie(MovieDeleteDto model);

    }
}
