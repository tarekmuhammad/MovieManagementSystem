using Microsoft.AspNetCore.Mvc;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.DTO;
using MovieSystem.Application.Helper;

namespace MovieSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {

        private readonly IReviewService _ReviewService;


        public ReviewController(IReviewService ReviewService)
        {
            _ReviewService = ReviewService;
        }

        [HttpGet("~/GetAlReviews")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var data = await _ReviewService.GetAllReviews();
                var response = new ApiResponse<IEnumerable<ReviewDetailsDto>> { Code = 200, Status = "Success", Result = data };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message };
                return StatusCode(500, response);
            }
        }

        [HttpPost("~/CreateReview")]
        public async Task<ActionResult> CreateSubCategory(ReviewCreateDto model)
        {
            try
            {
                await _ReviewService.CreateReview(model);
                var response = new ApiResponse<string> { Code = 200, Status = "Success", Result = "Created" };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message };
                return StatusCode(500, response);
            }
        }

        [HttpPut("~/UpdateReview")]
        public async Task<ActionResult> Update(ReviewUpdateDto model)
        {
            try
            {
                await _ReviewService.UpdateReview(model);
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

        [HttpDelete("~/DeleteReview/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _ReviewService.DeleteReview(id);
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
