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
    public class DoctorRepository : IDoctorRepository
    {
        private readonly FertilityCareDBContext _context;

        public DoctorRepository(FertilityCareDBContext context)
        {
            _context = context;
        }

        public async Task<Doctor> SaveAsync(Doctor entity)
        {
            await _context.Doctors.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Doctor> UpdateAsync(Doctor entity)
        {
            var existing = await _context.Doctors.FindAsync(entity.Id);
            if (existing == null)
                throw new NotFoundException("Doctor not found");

            _context.Entry(existing).CurrentValues.SetValues(entity);
            existing.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
                throw new NotFoundException("Doctor not found");

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Doctor>> FindAllAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> FindByIdAsync(Guid id)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            if (doctor == null)
                throw new NotFoundException("Doctor not found");

            return doctor;
        }

        public async Task<bool> IsExistAsync(Guid id)
        {
            return await _context.Doctors.AnyAsync(d => d.Id == id);
        }

    }
}
