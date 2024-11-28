using AutoMapper;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.DTO;
using MovieSystem.Application.Repository.Interface;
using MovieSystem.Domain.Entities.Commen;

namespace MovieSystem.Application.Contracts.Service
{
    public class RoleService : IRoleService
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<RoleDetailsDto>> GetAllRoles()
        {
            var data = await _unitOfWork.RolesRepo.GetAsync(
                    includeProperties: null,
                    criteria: null);

            var result = _mapper.Map<IEnumerable<RoleDetailsDto>>(data);
            return result;
        }

        public async Task<RoleDetailsDto> GetRole(int id)
        {
            var data = await _unitOfWork.RolesRepo.GetAsync(
                //criteria: a => a.Id == id,
                includeProperties: null
                //new List<Expression<Func<Roles, object>>>
                // {
                //   a => a.
                // }
                );
              var result = _mapper.Map<RoleDetailsDto>(data);
              return result;

        }




        public async Task CreateRole(RoleCreateDto model)
        {
            try
            {
                model.EntryDate = DateTime.Now;
                model.EnteredBy = "UserID";
                await _unitOfWork.BeginTransactionAsync();
                var result = _mapper.Map<Roles>(model);
                await _unitOfWork.RolesRepo.AddAsync(result);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
            }
        }

        public async Task UpdateRole(RoleUpdateDto model)
        {
            try
            {
                var q = _unitOfWork.RolesRepo.GetById(model.Id);
                //var EntryDate = q.EntryDate;
                //var EntryBy = q.EnteredBy;

                //model.EnteredBy = EntryBy;
                //model.EntryDate = EntryDate;
               // model.UpdatedDate = DateTime.Now;
                //model.UpdatedBy = "UserID";
                await _unitOfWork.BeginTransactionAsync();
                var result = _mapper.Map<Roles>(model);
                _unitOfWork.RolesRepo.Update(result);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
            }
        }

        public async Task DeleteRole(int id)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                var result = _mapper.Map<Roles>(id);
                _unitOfWork.RolesRepo.Delete(result);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
            }
        }






    }





}
