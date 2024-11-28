using Microsoft.AspNetCore.Mvc;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.DTO;
using MovieSystem.Application.Helper;

namespace MovieSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignController : ControllerBase
    {

        private readonly IAssignService _AssignService;


        public AssignController(IAssignService AssignService)
        {
            _AssignService = AssignService;
        }



        [HttpPost("~/AssignUserToRole")]
        public async Task<ActionResult> AssignUserToRole(AssignUserRoleDto model)
        {
            try
            {
                await _AssignService.AssignUserToRole(model.roleId,model.userId);
                var response = new ApiResponse<string> { Code = 200, Status = "Success", Result = "AssignUserToRole" };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message };
                return StatusCode(500, response);
            }
        }

        [HttpPost("~/RevokeUserToRole")]
        public async Task<ActionResult> RevokeUserRole(AssignUserRoleDto model)
        {
            try
            {
                await _AssignService.RevokeUserRole(model.userId, model.roleId);
                var response = new ApiResponse<string> { Code = 200, Status = "Success", Result = "RevokeUserRole" };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message };
                return StatusCode(500, response);
            }
        }



        [HttpPost("~/AssignUserToPermission")]
        public async Task<ActionResult> AssignUserToPermission(AssignUserPermissionDto model)
        {
            try
            {
                await _AssignService.AssignUserToPermission(model.permissionId, model.userId);
                var response = new ApiResponse<string> { Code = 200, Status = "Success", Result = "AssignUserToPermission" };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message };
                return StatusCode(500, response);
            }
        }


        [HttpPost("~/RevokeUserPermission")]
        public async Task<ActionResult> RevokeUserPermission(AssignUserPermissionDto model)
        {
            try
            {
                await _AssignService.RevokeUserPermission(model.userId, model.permissionId);
                var response = new ApiResponse<string> { Code = 200, Status = "Success", Result = "RevokeUserPermission" };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message };
                return StatusCode(500, response);
            }
        }


        [HttpPost("~/AssignRoleToPermission")]
        public async Task<ActionResult> AssignRoleToPermission(AssignRolePermissionDto model)
        {
            try
            {
                await _AssignService.AssignRoleToPermission(model.roleId, model.permissionId);
                var response = new ApiResponse<string> { Code = 200, Status = "Success", Result = "RevokeUserPermission" };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message };
                return StatusCode(500, response);
            }
        }

        [HttpPost("~/RevokeRoleToPermission")]
        public async Task<ActionResult> RevokeRolePermission(AssignRolePermissionDto model)
        {
            try
            {
                await _AssignService.RevokeRolePermission(model.roleId, model.permissionId);
                var response = new ApiResponse<string> { Code = 200, Status = "Success", Result = "RevokeUserPermission" };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message };
                return StatusCode(500, response);
            }
        }



    }
}
