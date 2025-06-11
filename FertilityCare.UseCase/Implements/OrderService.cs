using FertilityCare.UseCase.DTOs.Orders;
using FertilityCare.UseCase.Interfaces.Repositories;
using FertilityCare.UseCase.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.UseCase.Implements
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository), "Order repository cannot be null.");
        }

        public Task<IEnumerable<OrderDTO>> GetOrderByDoctorIdAsync(Guid doctorId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDTO> GetOrderByIdAsync(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDTO>> GetOrderByPatientIdAsync(Guid patientId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDTO> PlaceOrderAsync(CreateOrderRequestDTO request)
        {
            throw new NotImplementedException();
        }

    }
}
