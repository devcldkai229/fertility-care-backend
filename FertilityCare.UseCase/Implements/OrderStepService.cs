using FertilityCare.UseCase.DTOs.OrderSteps;
using FertilityCare.UseCase.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.UseCase.Implements
{
    public class OrderStepService : IOrderStepService
    {
        public async Task<OrderStepDTO> GetAllStepsByOrderIdAsync(Guid orderId)
        {
            throw new NotImplementedException();
        }
    }
}
