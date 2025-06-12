using FertilityCare.UseCase.DTOs.Appointments;
using FertilityCare.UseCase.Interfaces.Repositories;
using FertilityCare.UseCase.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.UseCase.Implements
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        private readonly IOrderStepRepository _stepRepository;

        private readonly IOrderRepository _orderRepository; 

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByStepIdAsync(Guid stepId)
        {
            throw new NotImplementedException();
        }

        public async Task<AppointmentDTO> PlaceAppointmentByStepIdAsync(Guid stepId, CreateAppointmentRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public async Task<AppointmentDTO> PlaceAppointmentWithStartOrderAsync(CreateAppointmentRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public async Task<AppointmentDTO> UpdateInfoAppointmentByAppointmentIdAsync(Guid appointmentId, UpdateInfoAppointmentRequestDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
