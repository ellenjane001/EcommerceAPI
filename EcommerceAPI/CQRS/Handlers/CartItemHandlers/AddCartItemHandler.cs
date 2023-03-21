using EcommerceAPI.CQRS.Commands.CartItemCommands;
using EcommerceAPI.Domain.Interfaces;
using MediatR;

namespace EcommerceAPI.CQRS.Handlers.CartItemHandlers
{
    public class AddCartItemHandler : IRequestHandler<AddCartItemCommand>
    {
        private readonly ICartItemRepository _cartItemRepository;
        public AddCartItemHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }
        public async Task Handle(AddCartItemCommand request, CancellationToken cancellationToken)
        {
            await _cartItemRepository.Post(request.CartItem);
            return;
        }
    }
}
