using FertilityCare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.UseCase.Interfaces.Repositories
{
    public interface IAppointmentRepository : IBaseRepository<Appointment, Guid>
    {

        Task<int> CountAppointmentByScheduleId(long scheduleId);

    }
}
