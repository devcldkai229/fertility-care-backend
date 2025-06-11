using FertilityCare.UseCase.DTOs.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.UseCase.Interfaces.Services
{
    public interface IAppointmentService
    {

        Task<AppointmentDTO> PlaceAppointmentFirstTimeAsync(CreateAppointmentRequestDTO request);

        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByStepIdAsync(Guid stepId);

        Task<AppointmentDTO> PlaceAppointmentByStepIdAsync(Guid stepId, CreateAppointmentRequestDTO request);

        Task<AppointmentDTO> UpdateInfoAppointmentByAppointmentIdAsync(
            Guid appointmentId, UpdateInfoAppointmentRequestDTO request);

    }
}
