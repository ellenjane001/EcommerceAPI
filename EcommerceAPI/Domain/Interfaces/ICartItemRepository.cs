using EcommerceAPI.Data.DTO.CartItem;

namespace EcommerceAPI.Domain.Interfaces
{
    public interface ICartItemRepository
    {
        Task<IEnumerable<Entities.CartItem>> GetCartItems();
        Task<Guid> Post(AddCartItemDTO cartItem);
        Task Put(Guid CartItemId, UpdateCartItemDTO cartItem);
        Task Delete(Guid CartItemId);
    }
}
