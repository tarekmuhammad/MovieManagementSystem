using MovieSystem.Domain.Entities.Commen;

namespace MovieSystem.Application.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {

        public IUserRepository UsersRepo    { get; }
        public IMovieRepository MovieRepo    { get; }
        public ICategoryRepository CategoryRepo { get; }
        public IBaseRepository<Roles> RolesRepo { get; }
        public IBaseRepository<Reviews> ReviewsRepo {get;}
        public IBaseRepository<Like> LikeRepo { get;}



        public IBaseRepository<Permissions> PermissionsRepo { get; }
       // public IBaseRepository<RoleUser> RoleUserRepo { get; }
        

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();



      

    }
}
