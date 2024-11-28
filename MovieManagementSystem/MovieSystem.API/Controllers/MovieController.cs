using Microsoft.AspNetCore.Mvc;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.DTO;
using MovieSystem.Application.Helper;

namespace MovieSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private readonly IMovieService _movieService;


        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }



        [HttpGet("~/GetAllMovies")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var data = await _movieService.GetAllWithCategory();
                var response = new ApiResponse<IEnumerable<MovieDetailsDto>> { Code = 200, Status = "Success", Result = data };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message };
                return StatusCode(500, response);
            }
        }


        [HttpGet("~/GetMovie/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var data =  await _movieService.GetMovie(id);
                var response = new ApiResponse<MovieDetailsDto> { Code = 200, Status = "Success", Result = data };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message };
                return StatusCode(500, response);
            }

        }


        [HttpGet("~/GetMovieByCategoryId/{id}")]
        public async Task<ActionResult> GetMoviesByCategoryId(int id)
        {
            try
            {
                var data = await _movieService.GetMovieByCategory(id);
                var response = new ApiResponse<IEnumerable<MovieDetailsDto>> { Code = 200, Status = "Success", Result = data };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message };
                return StatusCode(500, response);
            }

        }

 

        [HttpPost("~/CreateMovie")]
        public async Task <ActionResult> Create(MovieCreateDto model)
        {
            try
            {
                await _movieService.CreateMovie(model);
                var response = new ApiResponse<string> { Code = 200, Status = "Success", Result = "Created" };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string> { Code = 500, Status = "Internal Server Error", Result = ex.Message };
                return StatusCode(500, response);
            }
        }



        [HttpPut("~/UpdateMovie")]
        public async Task<ActionResult> Update(MovieUpdateDto model)
        {
            try
            {
                await _movieService.UpdateMovie(model);
                var response = new ApiResponse<string> { Code = 200, Status = "Success", Result = "Updated" };
                return Ok(response);
            
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string> { Code = 500, Status = "Internal Server Error", 
                    Result = ex.Message };
                return StatusCode(500, response);
            }
        }


        [HttpDelete("~/DeleteMovie")]
        public async Task<ActionResult> Delete(MovieDeleteDto model)
        {
            try
            {
                await _movieService.DeleteMovie(model);
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
