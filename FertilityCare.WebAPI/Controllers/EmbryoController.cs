using FertilityCare.UseCase.DTOs.Embryos;
using FertilityCare.UseCase.Interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FertilityCare.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/embryos")]
    public class EmbryoController : ControllerBase
    {
        private readonly IEmbryoService _embryoService;

        public EmbryoController(IEmbryoService embryoService)
        {
            _embryoService = embryoService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<EmbryoData>>>> GetByOrderId([FromRoute] string id)
        {
            try
            {
                var result = await _embryoService.GetByOrderIdAsync(Guid.Parse(id));

                return Ok(new ApiResponse<IEnumerable<EmbryoData>>
                {
                    StatusCode = 200,
                    Message = "Lấy dữ liệu phôi thành công.",
                    Data = result
                });
            }
            catch (FormatException)
            {
                return BadRequest(new ApiResponse<string>
                {
                    StatusCode = 400,
                    Message = "ID không hợp lệ.",
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    StatusCode = 500,
                    Message = "Đã xảy ra lỗi khi lấy dữ liệu phôi.",
                    Data = ex.Message
                });
            }
        }

    }
}
