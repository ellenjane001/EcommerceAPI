using EcommerceAPI.DTO.CartItem;
using EcommerceAPI.Entities;

namespace EcommerceAPI.Data.Interfaces
{
    public interface ICartItemRepository
    {
        Task<IEnumerable<CartItem>> GetCartItems();
        Task<Guid> Post(AddCartItemDTO cartItem);
        bool Put(Guid CartItemId, UpdateCartItemDTO cartItem);
        void Delete(Guid CartItemId);
    }
}
