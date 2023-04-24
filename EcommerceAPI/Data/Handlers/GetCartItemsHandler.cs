using EcommerceAPI.Data.Interfaces;
using EcommerceAPI.Data.Queries;
using EcommerceAPI.Domain.Entities;
using MediatR;

namespace EcommerceAPI.Data.Handlers
{
    public class GetCartItemsHandler : IRequestHandler<GetCartItemsQuery, IEnumerable<CartItem>>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public GetCartItemsHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<IEnumerable<CartItem>> Handle(GetCartItemsQuery request, CancellationToken cancellationToken) => await _cartItemRepository.GetCartItems();
    }
}
