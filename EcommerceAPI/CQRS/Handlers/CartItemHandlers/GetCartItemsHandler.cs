using EcommerceAPI.CQRS.Queries;
using EcommerceAPI.Domain.Interfaces;
using MediatR;

namespace EcommerceAPI.CQRS.Handlers.CartItemHandlers
{
    public class GetCartItemsHandler : IRequestHandler<GetCartItemsQuery, IEnumerable<Domain.Entities.CartItem>>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public GetCartItemsHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<IEnumerable<Domain.Entities.CartItem>> Handle(GetCartItemsQuery request, CancellationToken cancellationToken) => await _cartItemRepository.GetCartItems();
    }
}
