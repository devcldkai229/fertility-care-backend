using FertilityCare.UseCase.DTOs.Blogs;
using FertilityCare.UseCase.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FertilityCare.WebAPI.Controllers
{
    [Route("api/v1/blog")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<BlogDTO>>> CreateBlog([FromBody] CreateBlogRequestDTO request)
        {
            try
            {
                var blog = await _blogService.CreateNewBlog(request);
                return Ok(new ApiResponse<BlogDTO>
                {
                    StatusCode = 201,
                    Message = "Create blog successfully",
                    Data = blog,
                    ResponsedAt = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<BlogDTO>
                {
                    StatusCode = 400,
                    Message = ex.Message,
                    ResponsedAt = DateTime.Now
                });
            }
        }
    }
}
