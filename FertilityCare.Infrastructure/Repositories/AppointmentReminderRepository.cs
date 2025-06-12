using FertilityCare.Domain.Entities;
using FertilityCare.Infrastructure.Identity;
using FertilityCare.Shared.Exceptions;
using FertilityCare.UseCase.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.Infrastructure.Repositories
{
    public class AppointmentReminderRepository : IAppointmentReminderRepository
    {
        private readonly FertilityCareDBContext _context;

        public AppointmentReminderRepository(FertilityCareDBContext context)
        {
            _context = context;
        }

        public Task DeleteByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppointmentReminder>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AppointmentReminder> FindByIdAsync(long id)
        {
            var reminder = await _context.AppointmentReminders.FindAsync(id);
            if (reminder == null)
            {
                throw new NotFoundException($"Appointment reminder with ID {id} not found.");
            }

            return reminder;
        }

        public async Task<bool> IsExistAsync(long id)
        {
            var reminder = await _context.AppointmentReminders.FindAsync(id);
            if(reminder == null)
            {
                return false;
            }

            return true;
        }

        public async Task<AppointmentReminder> SaveAsync(AppointmentReminder entity)
        {
            await _context.AppointmentReminders.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task<AppointmentReminder> UpdateAsync(AppointmentReminder entity)
        {
            throw new NotImplementedException();
        }
    }
}
