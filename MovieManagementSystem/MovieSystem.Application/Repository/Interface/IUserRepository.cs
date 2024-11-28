using MovieSystem.Application.DTO;
using MovieSystem.Domain.Entities.Commen;

namespace MovieSystem.Application.Repository.Interface
{
    public interface IUserRepository : IBaseRepository<Users>
    {
        Task<LoginDto> Login();
        Task<RegistrationDto> Register();
        void Logout();
        void Details();
    }
}
