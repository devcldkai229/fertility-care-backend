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
    public class OrderRepository : IOrderRepository
    {

        private readonly FertilityCareDBContext _context;

        public OrderRepository(FertilityCareDBContext context)
        {
            _context = context;
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> FindByIdAsync(Guid id)
        {
            var result = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                throw new NotFoundException($"Order with ID {id} not found.");
            }

            return result;
        }

        public async Task<bool> IsExistAsync(Guid id)
        {
            var orderExists = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if(orderExists is null)
            {
                return false;
            }

            return true;
        }

        public async Task<Order> SaveAsync(Order entity)
        {
            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task<Order> UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
