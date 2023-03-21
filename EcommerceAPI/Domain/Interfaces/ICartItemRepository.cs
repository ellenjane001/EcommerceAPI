using EcommerceAPI.Data.DTO.CartItem;
using EcommerceAPI.Domain.Entities;

namespace EcommerceAPI.Domain.Interfaces
{
    public interface ICartItemRepository
    {
        Task<IEnumerable<CartItem>> GetCartItems();
        Task<Guid> Post(AddCartItemDTO cartItem);
        Task Put(Guid CartItemId, UpdateCartItemDTO cartItem);
        Task Delete(Guid CartItemId);
    }
}
