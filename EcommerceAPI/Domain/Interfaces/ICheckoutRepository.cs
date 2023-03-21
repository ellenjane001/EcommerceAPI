using EcommerceAPI.Data.DTO.Checkout;
using EcommerceAPI.Domain.Entities;

namespace EcommerceAPI.Domain.Interfaces
{
    public interface ICheckoutRepository
    {
        Task<Order> Checkout(CheckoutDTO order);
    }
}
