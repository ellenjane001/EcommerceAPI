using EcommerceAPI.DTO.Checkout;
using EcommerceAPI.Entities;

namespace EcommerceAPI.Data.Interfaces
{
    public interface ICheckoutRepository
    {
        Task<Order> Checkout(CheckoutDTO order);
    }
}
