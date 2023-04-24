using EcommerceAPI.Data.Interfaces;
using EcommerceAPI.Data.Queries;
using EcommerceAPI.Domain.Entities;
using MediatR;

namespace EcommerceAPI.Data.Handlers
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Order>>
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrdersHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken) => await _orderRepository.GetOrders();
    }
}
