using FertilityCare.Domain.Entities;
using FertilityCare.Domain.Enums;
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
        private readonly IOrderStepRepository _stepRepository;

        private readonly IDoctorScheduleRepository _scheduleRepository;

        private readonly IOrderRepository _orderRepository;

        private readonly IAppointmentRepository _appointmentRepository;

        private readonly IAppointmentReminderRepository _appointmentReminderRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository, 
            IOrderStepRepository orderStepRepository, 
            IOrderRepository orderRepository,
            IDoctorScheduleRepository doctorScheduleRepository,
            IAppointmentReminderRepository appointmentReminderRepository)
        {
            _appointmentRepository = appointmentRepository;
            _stepRepository = orderStepRepository;
            _orderRepository = orderRepository;
            _scheduleRepository = doctorScheduleRepository;
            _appointmentReminderRepository = appointmentReminderRepository;
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
            var step = await _stepRepository.FindByIdAsync(request.OrderStepId);
            var schedule = await _scheduleRepository.FindByIdAsync(request.DoctorScheduleId);

            Appointment appointment = new Appointment
            {
                PatientId = Guid.Parse(request.PatientId),
                DoctorId = Guid.Parse(request.DoctorId),
                DoctorScheduleId = request.DoctorScheduleId,
                TreatmentServiceId = Guid.Parse(request.TreatmentServiceId),
                OrderStepId = request.OrderStepId,
                BookingEmail = request.BookingEmail,
                BookingPhone = request.BookingPhone,
                AppointmentDate = schedule.WorkDate,
                StartTime = schedule.Slot.StartTime,
                EndTime = schedule.Slot.EndTime,
                Status = AppointmentStatus.Booked,
                CancellationReason = "",
                Note = "",
                Amount = step.TreatmentStep.Amount,
                PaymentStatus = PaymentStatus.Pending,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            await _appointmentRepository.SaveAsync(appointment);
                   
            
        



        }

        public async Task<AppointmentDTO> UpdateInfoAppointmentByAppointmentIdAsync(Guid appointmentId, UpdateInfoAppointmentRequestDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
