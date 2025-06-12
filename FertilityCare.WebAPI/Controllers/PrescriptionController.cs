using FertilityCare.UseCase.DTOs.Prescriptions;
using FertilityCare.UseCase.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FertilityCare.WebAPI.Controllers
{
    [Route("api/prescription-services")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;
        public PrescriptionController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse<PrescriptionDTO>>> CreatePrecription([FromBody] CreatePrecriptionRequestDTO request)
        {
            try
            {
                var result = await _prescriptionService.CreatePrescriptionAsync(request);
                return Ok(new ApiResponse<PrescriptionDTO>
                {
                    StatusCode = 200,
                    Message = "",
                    Data = result,
                    ResponsedAt = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>
                {
                    StatusCode = 400,
                    Message = ex.Message,
                    Data = null,
                    ResponsedAt = DateTime.Now
                });
            }
        }
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<PrescriptionDTO>>>> FindPrescriptionByOrderId([FromQuery] string orderId)
        {
            try
            {
                var result = await _prescriptionService.FindPrescriptionByOrderIdAsync(orderId);
                return Ok(new ApiResponse<IEnumerable<PrescriptionDTO>>
                {
                    StatusCode = 200,
                    Message = "",
                    Data = result,
                    ResponsedAt = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>
                {
                    StatusCode = 400,
                    Message = ex.Message,
                    Data = null,
                    ResponsedAt = DateTime.Now
                });
            }
        }

    }
}
