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
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<BlogDTO>>>> GetAllBlogs([FromQuery]int pageNumber, int pageSize)
        {
            try
            {
                var blogs = await _blogService.GetAllBlog(pageNumber, pageSize);
                return Ok(new ApiResponse<List<BlogDTO>>
                {
                    StatusCode = 200,
                    Message = "Get all blogs successfully",
                    Data = blogs,
                    ResponsedAt = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<List<BlogDTO>>
                {
                    StatusCode = 400,
                    Message = ex.Message,
                    ResponsedAt = DateTime.Now
                });
            }
        }
        [HttpGet]
        [Route("doctor/{doctorId}")]
        public async Task<ActionResult<ApiResponse<List<BlogDTO>>>> GetBlogsByDoctorId([FromRoute] string doctorId, [FromQuery] int pageNumber, int pageSize)
        {
            try
            {
                var blogs = await _blogService.GetBlogByDoctorId(new BlogQueryDTO
                {
                    DoctorId = doctorId,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                });
                return Ok(new ApiResponse<List<BlogDTO>>
                {
                    StatusCode = 200,
                    Message = "Get blogs by doctor id successfully",
                    Data = blogs,
                    ResponsedAt = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<List<BlogDTO>>
                {
                    StatusCode = 400,
                    Message = ex.Message,
                    ResponsedAt = DateTime.Now
                });
            }
        }

        [HttpPut]
        [Route("{blogId}")]
        public async Task<ActionResult<ApiResponse<BlogDTO>>> UpdateBlog([FromRoute] string blogId, [FromBody] CreateBlogRequestDTO request)
        {
            try
            {
                var blog = await _blogService.UpdateBlog(blogId, request);
                return Ok(new ApiResponse<BlogDTO>
                {
                    StatusCode = 200,
                    Message = "Update blog successfully",
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
