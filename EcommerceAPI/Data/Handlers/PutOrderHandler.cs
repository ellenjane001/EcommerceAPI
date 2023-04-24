using EcommerceAPI.Data.Commands;
using EcommerceAPI.Data.Interfaces;
using MediatR;

namespace EcommerceAPI.Data.Handlers
{
    public class PutOrderHandler : IRequestHandler<PutOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public PutOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(PutOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderRepository.Put(request.OrderId, request.order);
            return;
        }
    }
}
