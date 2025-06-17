using FertilityCare.Domain.Entities;
using FertilityCare.Infrastructure.Identity;
using FertilityCare.UseCase.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.Infrastructure.Repositories
{
    public class EmbryoRepository : IEmbryoRepository
    {

        private readonly FertilityCareDBContext _context;

        public EmbryoRepository(FertilityCareDBContext context)
        {
            _context = context;
        }

        public Task DeleteByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmbryoTransfer>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EmbryoTransfer> FindByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmbryoTransfer>> FindByOrderIdAsync(Guid orderId)
        {
            return await _context.EmbryoTransfers.Where(x => x.OrderId == orderId).ToListAsync();
        }

        public Task<bool> IsExistAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<EmbryoTransfer> SaveAsync(EmbryoTransfer entity)
        {
            await _context.EmbryoTransfers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task<EmbryoTransfer> UpdateAsync(EmbryoTransfer entity)
        {
            throw new NotImplementedException();
        }
    }
}
