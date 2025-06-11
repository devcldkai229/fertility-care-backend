using FertilityCare.Domain.Entities;
using FertilityCare.Infrastructure.Identity;
using FertilityCare.UseCase.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.Infrastructure.Repositories
{
    public class OrderStepRepository : IOrderStepRepository
    {
        private readonly FertilityCareDBContext _context;

        public OrderStepRepository(FertilityCareDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "Database context cannot be null.");
        }

        public async Task DeleteByIdAsync(long id)
        {
            var orderStep = await _context..FindAsync(id);
            if (orderStep != null)
            {
                _context.OrderSteps.Remove(orderStep);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OrderStep>> FindAllAsync()
        {
            return await _context.OrderSteps.ToListAsync();
        }

        public async Task<OrderStep> FindByIdAsync(long id)
        {
            return await _context.OrderSteps.FindAsync(id);
        }

        public async Task<bool> IsExistAsync(long id)
        {
            return await _context.OrderSteps.AnyAsync(os => os.Id == id);
        }

        public async Task<OrderStep> SaveAsync(OrderStep entity)
        {
            _context.OrderSteps.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<OrderStep> UpdateAsync(OrderStep entity)
        {
            _context.OrderSteps.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}