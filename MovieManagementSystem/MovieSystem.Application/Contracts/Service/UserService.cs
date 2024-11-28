using AutoMapper;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.DTO;
using MovieSystem.Application.Repository.Interface;
using MovieSystem.Domain.Entities.Commen;
using System.Linq.Expressions;
 
namespace MovieSystem.Application.Contracts.Service
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

       public UserService(IUnitOfWork unitOfWork  , IMapper mapper) 
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        public async Task<IEnumerable<UserDetailsDto>> GetAll()
        {
 
            var data = await _unitOfWork.UsersRepo.GetAsync(
                includeProperties: new List<Expression<Func<Users, object>>>
                {
                  a => a.Reviews ,
                 // a => a.RoleUser,
                  a => a.Likes
                } ,
                criteria: null
                );
            var result = _mapper.Map<IEnumerable<UserDetailsDto>>(data);
            return result;
        }

        public async Task<UserDetailsDto> GetUser(string id)
        {
            var data = await _unitOfWork.UsersRepo.GetAsync(
                includeProperties: new List<Expression<Func<Users, object>>>
                {
                  a => a.Reviews ,
                  //a => a.RoleUser,
                  a => a.Likes
                },
                criteria: a => a.Id == id);
            var result = _mapper.Map<UserDetailsDto>(data);
            return result;
        }




        public async Task CreateUser(UserCreateDto model)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                var result = _mapper.Map<Users>(model);
                await _unitOfWork.UsersRepo.AddAsync(result);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
            }
        }


        public async Task UpdateUser(UserUpdateDto model)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                var result = _mapper.Map<Users>(model);
                 _unitOfWork.UsersRepo.Update(result);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
            }
        }


        public async Task DeleteUser(int id)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                var result = _mapper.Map<Users>(id);
                _unitOfWork.UsersRepo.Delete(result);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
            }
        }


        public Task<LoginDto> Login()
        {
            throw new NotImplementedException();
        }


        public void Logout()
        {
            throw new NotImplementedException();
        }


        public Task<RegistrationDto> Register()
        {
            throw new NotImplementedException();
        }


    }
}
