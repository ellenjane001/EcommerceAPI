using EcommerceAPI.Data.Contexts;
using EcommerceAPI.Domain.Entities;

namespace EcommerceAPI.Data.Miscellaneous
{
    public class CartItemHandlers
    {
        private readonly AppDBContext _dbContext;
        public CartItemHandlers(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public IEnumerable<CartItem> GetCartItemsByOrderId(Guid[] OrderIds)
        {
            return _dbContext.CartItems.Where(c => OrderIds.Any(orId => orId.Equals(c.OrderId))).ToList();
        }
    }
}
