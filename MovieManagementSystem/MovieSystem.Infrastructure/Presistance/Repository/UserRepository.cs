using Microsoft.EntityFrameworkCore;
using MovieSystem.Application.DTO;
using MovieSystem.Application.Repository.Interface;
using MovieSystem.Domain.Entities.Commen;
using MovieSystem.Infrastructure.Presistance.Data;

namespace MovieSystem.Infrastructure.Presistance.Repository
{
    public class UserRepository : BaseRepository<Users>,IUserRepository
    {



        protected readonly DbSet<Users> _dbSet;

        public UserRepository(MovieContext context) : base(context)
        {
            _dbSet = context.Set<Users>();
        }

        public void Details()
        {
            throw new NotImplementedException();
        }

        public Task<LoginDto> Login()
        {
            throw new NotImplementedException();
        }

        public Task<RegistrationDto> Register()
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public void Logoutsssss()
        {
            throw new NotImplementedException();
        }

    }
}
