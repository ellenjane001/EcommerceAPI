using EcommerceAPI.CQRS.Commands.OrderCommands;
using EcommerceAPI.Domain.Interfaces;
using MediatR;

namespace EcommerceAPI.CQRS.Handlers.OrderHandlers
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
            await _orderRepository.Put(request.OrderId, request.Order);
            return;
        }
    }
}
