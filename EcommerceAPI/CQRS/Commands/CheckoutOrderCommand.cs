using EcommerceAPI.Data.DTO.Checkout;
using MediatR;

namespace EcommerceAPI.CQRS.Commands
{
    public record CheckoutOrderCommand(CheckoutDTO Order) : IRequest;

}
