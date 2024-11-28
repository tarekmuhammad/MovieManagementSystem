using MovieSystem.Application.Repository.Interface;
using MovieSystem.Domain.Entities.Commen;
using MovieSystem.Infrastructure.Presistance.Data;

namespace MovieSystem.Infrastructure.Presistance.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {

        private readonly MovieContext _context;

        public CategoryRepository(MovieContext context) : base(context)
        {
            _context = context;
        }

    }
}
