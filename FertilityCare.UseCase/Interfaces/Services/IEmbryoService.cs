using FertilityCare.UseCase.DTOs.Embryos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.UseCase.Interfaces.Services
{
    public interface IEmbryoService
    {
        Task<IEnumerable<EmbryoData>> GetByOrderIdAsync(Guid orderId);
    }
}
