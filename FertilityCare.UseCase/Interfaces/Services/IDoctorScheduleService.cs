using Fertilitycare.Share.Comon;
using Fertilitycare.Share.Pagination;
using FertilityCare.Domain.Entities;
using FertilityCare.UseCase.DTOs.DoctorSchedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.UseCase.Interfaces.Services
{
    public interface IDoctorScheduleService
    {
        //CRUD
        Task<DoctorScheduleDTO> CreateScheduleAsync(CreateDoctorScheduleRequestDTO request);

        Task<DoctorScheduleDTO> UpdateScheduleAsync(UpdateDoctorScheduleRequestDTO request);

        Task<bool> DeleteScheduleAsync(long scheduleId);

        Task<IEnumerable<DoctorScheduleDTO>> FindAllSchedulesAsync();

        Task<IEnumerable<DoctorScheduleDTO>> GetAllSchedulesAsync(Guid doctorId);

        Task<DoctorScheduleDTO?> GetScheduleByIdAsync(long scheduleId);

        Task<PagedResult<DoctorScheduleDTO>> GetSchedulesPagedAsync(PaginationRequestDTO request);
    }
}
