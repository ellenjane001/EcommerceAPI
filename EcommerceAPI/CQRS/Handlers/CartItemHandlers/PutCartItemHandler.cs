using EcommerceAPI.CQRS.Commands.CartItemCommands;
using EcommerceAPI.Domain.Interfaces;
using MediatR;

namespace EcommerceAPI.CQRS.Handlers.CartItemHandlers
{
    public class PutCartItemHandler : IRequestHandler<PutCartItemCommand>
    {
        private readonly ICartItemRepository _cartItemRepository;
        public PutCartItemHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }
        public async Task Handle(PutCartItemCommand request, CancellationToken cancellationToken)
        {
            await _cartItemRepository.Put(request.CartItemId, request.CartItem);
            return;
        }
    }
}
