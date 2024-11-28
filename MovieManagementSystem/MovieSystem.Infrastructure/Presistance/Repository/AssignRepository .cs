using Microsoft.EntityFrameworkCore;
using MovieSystem.Application.Repository.Interface;
using MovieSystem.Infrastructure.Presistance.Data;

namespace MovieSystem.Infrastructure.Presistance.Repository
{
    public class AssignRepository : IAssignRepository
    {
        private readonly MovieContext _context;
        public AssignRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task AssignUserToRole(string roleId, string userId)
        {
            //var user = await _context.Users.Include(u => u.RoleUser)
            //    .FirstOrDefaultAsync(u => u.Id == userId);
            //var role = await _context.RoleUser.FindAsync(roleId);

            //if (user != null && role != null && !user.RoleUser.Contains(role))
            //{
            //    user.RoleUser.Add(role);
            //    await _context.SaveChangesAsync();
            //}
        }



        public async Task RevokeUserRole(string userId, string roleId)
        {
            //var user = await _context.Users.Include(u => u.RoleUser).FirstOrDefaultAsync(u => u.Id == userId);
            //var role = await _context.RoleUser.FindAsync(roleId);

            //if (user != null && role != null && user.RoleUser.Contains(role))
            //{
            //    user.RoleUser.Remove(role);
            //    await _context.SaveChangesAsync();
            //}
        }





        public async Task AssignUserToPermission(int permissionId, string userId)
        {
            //var user = await _context.Users.FindAsync(userId);
            //var per = await _context.Permissions.FindAsync(permissionId);
            //if (user != null && per != null && !user.Permissions.Contains(per))
            //{
            //    user.Permissions.Add(per);
            //    await _context.SaveChangesAsync();
            //}
        }


        public async Task RevokeUserPermission(string userId, int permissionId)
        {
            //var user = await _context.Users.Include(R => R.Permissions).FirstOrDefaultAsync(r => r.Id == userId);
            //var per = await _context.Permissions.FindAsync(permissionId);
            //if (user != null && per != null && user.Permissions.Contains(per))
            //{
            //    user.Permissions.Remove(per);
            //    await _context.SaveChangesAsync();
            //}
        }




        public async Task AssignRoleToPermission(string roleId, int permissionId)
        {
            //var role = await _context.Roles.Include(R => R.Permissions).FirstOrDefaultAsync(r => r.Id == roleId);
            //var per = await  _context.Permissions.FindAsync(permissionId);
            //if (role != null && per != null && !role.Permissions.Contains(per))
            //{
            //    role.Permissions.Add(per);
            //    await _context.SaveChangesAsync();
            //}
        }

        public async Task RevokeRolePermission(string roleId, int permissionId)
        {
            //var role = await _context.Roles.Include(R => R.Permissions).FirstOrDefaultAsync(r => r.Id == roleId);
            //var per =  await _context.Permissions.FindAsync(permissionId);
            //if (role != null && per != null && role.Permissions.Contains(per))
            //{
            //    role.Permissions.Remove(per);
            //    await _context.SaveChangesAsync();
            //}
        }
     
    }
}