using FertilityCare.UseCase.DTOs.OrderSteps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.UseCase.Interfaces.Services
{
    public interface IOrderStepService
    {

        Task<OrderStepDTO> GetAllStepsByOrderIdAsync(Guid orderId);

    }
}
