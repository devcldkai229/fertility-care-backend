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

        private readonly IAppointmentRepository _appointmentRepository;

        private readonly IOrderStepRepository _stepRepository;

        public OrderService(IOrderRepository orderRepository, 
            IAppointmentRepository appointmentRepository, 
            IOrderStepRepository stepRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository), "Order repository cannot be null.");
            _appointmentRepository = appointmentRepository;
            _stepRepository = stepRepository;
        }

        public async Task<IEnumerable<OrderDTO>> GetOrderByDoctorIdAsync(Guid doctorId)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderDTO> GetOrderByIdAsync(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderDTO>> GetOrderByPatientIdAsync(Guid patientId)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderDTO> PlaceOrderAsync(CreateOrderRequestDTO request)
        {
            throw new NotImplementedException();
        }

    }
}
