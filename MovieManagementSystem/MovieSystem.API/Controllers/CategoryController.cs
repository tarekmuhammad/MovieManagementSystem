using Microsoft.AspNetCore.Mvc;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.DTO;
using MovieSystem.Application.Helper;

namespace MovieSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;


        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("~/GetAlCategories")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var data = await _categoryService.GetAllCategories();
                var response = new ApiResponse<IEnumerable<CategoryDetailsDto>> { Code = 200, Status = "Success", Result = data };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message };
                return StatusCode(500, response);
            }
        }

        [HttpGet("~/GetCategory/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var data = await _categoryService.GetCategoryById(id);
                var response = new ApiResponse<CategoryDetailsDto> { Code = 200, Status = "Success", Result = data };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message };
                return StatusCode(500, response);
            }

        }

        [HttpPost("~/CreateParentCategory")]
        public async Task<ActionResult> CreateParentCategory(ParentCategoryDto model)
        {
            try
            {
                await _categoryService.CreateParentCategory(model);
                var response = new ApiResponse<string> { Code = 200, Status = "Success", Result = "Created" };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message };
                return StatusCode(500, response);
            }
        }
        
        [HttpPost("~/CreateSubCategory")]
        public async Task<ActionResult> CreateSubCategory(SubCategoryDto model)
        {
            try
            {
                await _categoryService.CreateSubCategory(model);
                var response = new ApiResponse<string> { Code = 200, Status = "Success", Result = "Created" };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message };
                return StatusCode(500, response);
            }
        }

        [HttpPut("~/UpdateCategory")]
        public async Task<ActionResult> Update(CategoryUpdateDto model)
        {
            try
            {
                await _categoryService.UpdateCategory(model);
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

        [HttpDelete("~/DeleteCategory/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _categoryService.DeleteCategory(id);
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
