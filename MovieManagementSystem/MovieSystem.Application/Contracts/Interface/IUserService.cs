using MovieSystem.Application.DTO;

namespace MovieSystem.Application.Contracts.Interface
{
    public interface IUserService
    {
        Task CreateUser(UserCreateDto model);
        Task UpdateUser(UserUpdateDto model);
        Task DeleteUser(int id);
        Task<IEnumerable<UserDetailsDto>> GetAll();
        Task<UserDetailsDto> GetUser(string id);


        Task<LoginDto> Login();
        Task<RegistrationDto> Register();
        void Logout();
    }

}
