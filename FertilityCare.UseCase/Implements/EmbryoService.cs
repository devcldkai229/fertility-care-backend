using FertilityCare.UseCase.DTOs.Embryos;
using FertilityCare.UseCase.Interfaces.Repositories;
using FertilityCare.UseCase.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.UseCase.Implements
{
    public class EmbryoService : IEmbryoService
    {

        private readonly IEmbryoRepository _embryoRepository;

        public EmbryoService(IEmbryoRepository emryoRepository)
        {
            _embryoRepository = emryoRepository;
        }

        public async Task<IEnumerable<EmbryoData>> GetByOrderIdAsync(Guid orderId)
        {
            var result = await _embryoRepository.FindByOrderIdAsync(orderId);

            return result
            .GroupBy(e => e.EmbryoGrade)
            .Select(g => new EmbryoData {
                EmbryoGrade = g.Key,
                EmbryoQuantity = g.Count()
            })
            .ToList();
        }
    }
}
