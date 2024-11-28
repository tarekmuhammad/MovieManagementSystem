using MovieSystem.Application.DTO;
using MovieSystem.Domain.Entities.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Application.Repository.Interface
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
       // Task<IEnumerable <MovieDto>> GetMovieByCategory(int catId);
    }
}
