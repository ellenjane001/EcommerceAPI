using EcommerceAPI.CQRS.Queries;
using EcommerceAPI.Domain.Entities;
using EcommerceAPI.Domain.Interfaces;
using MediatR;

namespace EcommerceAPI.CQRS.Handlers.OrderHandlers
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
