using FertilityCare.Domain.Entities;
using FertilityCare.Infrastructure.Identity;
using FertilityCare.Shared.Exceptions;
using FertilityCare.UseCase.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.Infrastructure.Repositories
{
    public class DoctorScheduleRepository : IDoctorScheduleRepository
    {
        private readonly FertilityCareDBContext _context;

        public DoctorScheduleRepository(FertilityCareDBContext context)
        {
            _context = context;
        }

        public async Task<DoctorSchedule> SaveAsync(DoctorSchedule entity)
        {
            await _context.DoctorSchedules.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<DoctorSchedule> UpdateAsync(DoctorSchedule entity)
        {
            var existing = await _context.DoctorSchedules.FindAsync(entity.Id);
            if (existing == null)
                throw new NotFoundException("Doctor schedule not found");

            _context.Entry(existing).CurrentValues.SetValues(entity);
            existing.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task DeleteByIdAsync(long id)
        {
            var schedule = await _context.DoctorSchedules.FindAsync(id);
            if (schedule == null)
                throw new NotFoundException("Doctor schedule not found");

            _context.DoctorSchedules.Remove(schedule);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DoctorSchedule>> FindAllAsync()
        {
            return await _context.DoctorSchedules.ToListAsync();
        }

        public async Task<DoctorSchedule> FindByIdAsync(long id)
        {
            var schedule = await _context.DoctorSchedules
                .FirstOrDefaultAsync(ds => ds.Id == id);

            if (schedule == null)
                throw new NotFoundException("Doctor schedule not found");

            return schedule;
        }

        public async Task<bool> IsExistAsync(long id)
        {
            var result = await _context.DoctorSchedules.FirstOrDefaultAsync(ds => ds.Id == id);
            if (result == null)
            {
                return false;
            }

            return true;
        }

        public Task<IQueryable<DoctorSchedule>> FindAllQueryableAsync()
        {
            return Task.FromResult(
                _context.DoctorSchedules
                        .Include(ds => ds.Doctor)
                        .Include(ds => ds.Slot)
                        .AsQueryable()
            );
        }

        public async Task<IEnumerable<DoctorSchedule>> GetSchedulesByDateAndDoctorAsync(DateOnly workDate, Guid? doctorId = null)
        {
            var query = _context.DoctorSchedules
            .Include(ds => ds.Slot)
            .Include(ds => ds.Doctor)
            .Where(ds => ds.WorkDate == workDate);

            if (doctorId.HasValue)
                query = query.Where(ds => ds.DoctorId == doctorId.Value);

            return await query.ToListAsync();

        }
    }
}
