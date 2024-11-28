using Microsoft.AspNetCore.Mvc;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.DTO;
using MovieSystem.Application.Helper;

namespace MovieSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {


        private readonly IRoleService _RoleService;


        public RoleController(IRoleService RoleService)
        {
            _RoleService = RoleService;
        }


        [HttpGet("~/GetAllRoles")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var data = await _RoleService.GetAllRoles();
                var response = new ApiResponse<IEnumerable<RoleDetailsDto>> { Code = 200, Status = "Success", Result = data };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message };
                return StatusCode(500, response);
            }
        }


        [HttpGet("~/GetRole/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var data = await _RoleService.GetRole(id);
                var response = new ApiResponse<RoleDetailsDto> { Code = 200, Status = "Success", Result = data };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message };
                return StatusCode(500, response);
            }

        }

         
        [HttpPost("~/CreateRole")]
        public async Task<ActionResult> Create(RoleCreateDto model)
        {
            try
            {
                await _RoleService.CreateRole(model);
                var response = new ApiResponse<string> { Code = 200, Status = "Success", Result = "Created" };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message };
                return StatusCode(500, response);
            }
        }



        [HttpPut("~/UpdateRole")]
        public async Task<ActionResult> Update(RoleUpdateDto model)
        {
            try
            {
                await _RoleService.UpdateRole(model);
                var response = new ApiResponse<string> { Code = 200, Status = "Success", Result = "Updated" };
                return Ok(response);

            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>
                {
                    Code = 500,
                    Status = "Internal Server Error",
                    Result = ex.Message
                };
                return StatusCode(500, response);
            }
        }


        [HttpDelete("~/DeleteRole/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _RoleService.DeleteRole(id);
                var response = new ApiResponse<string> { Code = 200, Status = "Success", Result = "Deleted" };
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
