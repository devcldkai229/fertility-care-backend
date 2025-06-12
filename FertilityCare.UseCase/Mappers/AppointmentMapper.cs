using FertilityCare.Domain.Entities;
using FertilityCare.UseCase.DTOs.Appointments;
using FertilityCare.UseCase.DTOs.Doctors;
using FertilityCare.UseCase.DTOs.DoctorSchedules;
using FertilityCare.UseCase.DTOs.OrderSteps;
using FertilityCare.UseCase.DTOs.Patients;
using FertilityCare.UseCase.DTOs.TreatmentServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.UseCase.Mappers
{
    public static class AppointmentMapper
    {

        public static AppointmentDTO MapToAppointmentDTO(this Appointment appointment)
        {
            return new AppointmentDTO
            {
                Id = appointment.Id.ToString(),
                Patient = appointment.Patient?.MapToPatientDTO(),
                Doctor = appointment.Doctor?.MapToDoctorDTO(),
                DoctorSchedule = appointment.DoctorSchedule?.MapToScheduleDTO(),
                TreatmentService = appointment.TreatmentService?.MapToTreatmentServiceDTO(),
                OrderStep = appointment.OrderStep?.MapToStepDTO(),
                BookingName = appointment.BookingEmail,
                BookingPhone = appointment.BookingPhone,
                AppointmentDate = appointment.AppointmentDate.ToString("dd/MM/yyyy"),       
                StartTime = appointment.StartTime.ToString("HH:mm"),
                EndTime = appointment.EndTime.ToString("HH:mm"),
                Status = appointment.Status.ToString(),
                CancellationReason = appointment.CancellationReason,
                Note = appointment.Note,
                Amount = appointment.Amount,
                PaymentStatus = appointment.PaymentStatus.ToString(),
                CreatedAt = appointment.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss"),
                UpdatedAt = appointment.UpdatedAt?.ToString("dd/MM/yyyy HH:mm:ss")
            };
        }

    }
}
d