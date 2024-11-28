using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.DTO;
using MovieSystem.Application.Helper;

namespace MovieSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IValidator<UserCreateDto> _creatValidator; 

        public UserController(IUserService userService, IValidator<UserCreateDto> createValidator)
        {
            _userService = userService;
            _creatValidator = createValidator;
        }

        [HttpGet("~/GetAllUsers")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _userService.GetAll();
                var response = new ApiResponse<IEnumerable<UserDetailsDto>> { Code = 200, Status = "Success", Result = data };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message };
                return StatusCode(500, response);
            }
        }


        [HttpGet("~/GetUser/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var data = await _userService.GetUser(id);
                var response = new ApiResponse<UserDetailsDto> { Code = 200, Status = "Success", Result = data };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message };
                return StatusCode(500, response);
            }
        }


        [HttpPost("~/CreateUser")]
        public async Task<ActionResult> Create(UserCreateDto model)
        {
            var validation = _creatValidator.Validate(model);
            if (!validation.IsValid)
                return StatusCode(500, new ApiResponse<IList<ValidationFailure>> { Code = 500, Status = "Internal Server Error", Result = validation.Errors });
            try
            {
                await _userService.CreateUser(model);
                var res = new ApiResponse<string> { Code = 200, Status = "Success", Result = "Created" };
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message });
            }
        }


        [HttpPut("~/UpdateUser")]
        public async Task <ActionResult> Update(UserUpdateDto model)
        {
            try
            {
                await _userService.UpdateUser(model);
                var res = new ApiResponse<string> { Code = 200, Status = "Success", Result = "Updated" };
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message });
            }
        }


        [HttpDelete("~/DeleteUser/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _userService.DeleteUser(id);
                var res = new ApiResponse<string> { Code = 200, Status = "Success", Result = "Deleted" };
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message });
            }
        }


    }
}
