using EcommerceAPI.Data.Interfaces;
using EcommerceAPI.Data.Queries;
using EcommerceAPI.Domain.Entities;
using MediatR;

namespace EcommerceAPI.Data.Handlers
{
    public class GetOrderByIDHandler : IRequestHandler<GetOrderByIDQuery, Order>
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrderByIDHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Order> Handle(GetOrderByIDQuery request, CancellationToken cancellationToken) => await _orderRepository.GetOrder(request.OrderId);
    }
}
