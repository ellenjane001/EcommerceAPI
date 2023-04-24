using EcommerceAPI.Data.Commands;
using EcommerceAPI.Data.Interfaces;
using MediatR;

namespace EcommerceAPI.Data.Handlers
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
            await _cartItemRepository.Post(request.cartItem);
            return;
        }
    }
}
