using EcommerceAPI.CQRS.Commands.CartItemCommands;
using EcommerceAPI.Domain.Interfaces;
using MediatR;

namespace EcommerceAPI.CQRS.Handlers.CartItemHandlers
{
    public class DeleteCartItemHandler : IRequestHandler<DeleteCartItemCommand>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public DeleteCartItemHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }
        public async Task Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            await _cartItemRepository.Delete(request.CartItemId);
            return;
        }
    }
}
