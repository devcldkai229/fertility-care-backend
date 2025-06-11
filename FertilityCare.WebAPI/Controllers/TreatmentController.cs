using FertilityCare.UseCase.DTOs.TreatmentServices;
using FertilityCare.UseCase.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FertilityCare.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly IPublicTreatmentService _publicTreatmentService;
        public TreatmentController(IPublicTreatmentService publicTreatmentService)
        {
            _publicTreatmentService = publicTreatmentService;
        }
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<TreatmentServiceDTO>>>> GetAll()
        {
            try
            {
                var result = await _publicTreatmentService.GetAllAsync();
                return Ok(new ApiResponse<IEnumerable<TreatmentServiceDTO>>
                {
                    StatusCode = 200,
                    Message = "",
                    Data = result,
                    ResponsedAt = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }
    }
}
