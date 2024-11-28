using AutoMapper;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.Repository.Interface;

namespace MovieSystem.Application.Contracts.Service
{
    public class AssignService : IAssignService
    {


        private readonly IAssignRepository _AssignRepository;
        private readonly IMapper _mapper;

        public AssignService(IAssignRepository AssignRepository, IMapper mapper)
        {
            _mapper = mapper;
            _AssignRepository = AssignRepository;
        }



        public async Task AssignRoleToPermission(string roleId, int permissionId)
        {
            await _AssignRepository.AssignRoleToPermission(roleId, permissionId);
        }

        public async Task AssignUserToPermission(int permissionId, string userId)
        {
            await _AssignRepository.AssignUserToPermission(permissionId, userId);
        }


        public async Task AssignUserToRole(string roleId, string userId)
        {
            await _AssignRepository.AssignUserToRole(roleId, userId);
        }

        public async Task RevokeRolePermission(string roleId, int permissionId)
        {
            await _AssignRepository.RevokeRolePermission(roleId, permissionId);
        }

        public async Task RevokeUserPermission(string userId, int permissionId)
        {
            await _AssignRepository.RevokeUserPermission(userId, permissionId);
        }

        public async Task RevokeUserRole(string userId, string roleId)
        {
            await _AssignRepository.RevokeUserRole(userId, roleId); 
        }
    }
}
