using Microsoft.EntityFrameworkCore;
using MovieSystem.Application.DTO;
using MovieSystem.Application.Repository.Interface;
using MovieSystem.Domain.Entities.Commen;
using MovieSystem.Infrastructure.Presistance.Data;

namespace MovieSystem.Infrastructure.Presistance.Repository
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {


        protected readonly DbSet<Movie> _dbSet;


        public MovieRepository(MovieContext context) : base(context)
        {

            _dbSet = context.Set<Movie>();
        }

        //public Task<IEnumerable<MovieDto>> GetMovieByCategory(int catId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
