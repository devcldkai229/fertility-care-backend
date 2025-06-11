using FertilityCare.UseCase.DTOs.Appointments;
using FertilityCare.UseCase.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.UseCase.Implements
{
    public class AppointmentService : IAppointmentService
    {
        public Task<IEnumerable<AppointmentDTO>> GetAppointmentsByStepIdAsync(Guid stepId)
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentDTO> PlaceAppointmentByStepIdAsync(Guid stepId, CreateAppointmentRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentDTO> PlaceAppointmentFirstTimeAsync(CreateAppointmentRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentDTO> UpdateInfoAppointmentByAppointmentIdAsync(Guid appointmentId, UpdateInfoAppointmentRequestDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
