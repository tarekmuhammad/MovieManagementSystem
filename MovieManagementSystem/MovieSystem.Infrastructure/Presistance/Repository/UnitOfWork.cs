using MovieSystem.Application.Repository.Interface;
using MovieSystem.Domain.Entities.Commen;
using MovieSystem.Infrastructure.Presistance.Data;
using MovieSystem.Infrastructure.Presistance.Models;

namespace MovieSystem.Infrastructure.Presistance.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly MovieContext _moviecontext;


        public IUserRepository     UsersRepo { get; private set; }
        public ICategoryRepository CategoryRepo { get; private set; }
        public IMovieRepository    MovieRepo { get; private set; }


        public IBaseRepository<Roles> RolesRepo { get; private set; }
        public IBaseRepository<Reviews> ReviewsRepo  { get; private set; }
        public IBaseRepository<Like> LikeRepo { get; private set; }




        public IBaseRepository<Permissions> PermissionsRepo => throw new NotImplementedException();
       // public IBaseRepository<RoleUser> RoleUserRepo => throw new NotImplementedException();

 


        public UnitOfWork(MovieContext context)
        {
            _moviecontext = context;
            UsersRepo =    new UserRepository(_moviecontext);
            RolesRepo =    new BaseRepository<Roles>(_moviecontext);
            CategoryRepo=  new CategoryRepository(_moviecontext);
            MovieRepo =    new MovieRepository(_moviecontext);
            ReviewsRepo =  new BaseRepository<Reviews>(_moviecontext);
            LikeRepo =     new BaseRepository<Like>(_moviecontext);
        }




        public async Task BeginTransactionAsync()
        {
            await _moviecontext.Database.BeginTransactionAsync();
        }


        public async Task CommitAsync()
        {
            await _moviecontext.Database.CommitTransactionAsync();
        }


        public async Task RollbackAsync()
        {
            await _moviecontext.Database.RollbackTransactionAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            int id = await _moviecontext.SaveChangesAsync();
            return id;
        }


        public void Dispose()
        {
            // Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _moviecontext.Dispose();
                }
            }
            this.disposed = true;
        }

    }
}
