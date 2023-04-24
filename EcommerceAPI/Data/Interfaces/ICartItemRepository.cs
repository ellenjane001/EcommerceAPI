using EcommerceAPI.Domain.Entities;
using EcommerceAPI.DTO.CartItem;

namespace EcommerceAPI.Data.Interfaces
{
    public interface ICartItemRepository
    {
        Task<IEnumerable<CartItem>> GetCartItems();
        Task<Guid> Post(AddCartItemDTO cartItem);
        Task Put(Guid CartItemId, UpdateCartItemDTO cartItem);
        void Delete(Guid CartItemId);
    }
}
