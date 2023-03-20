using EcommerceAPI.Domain.Entities;
using EcommerceAPI.DTO.Checkout;

namespace EcommerceAPI.Data.Interfaces
{
    public interface ICheckoutRepository
    {
        Task<Order> Checkout(CheckoutDTO order);
    }
}
