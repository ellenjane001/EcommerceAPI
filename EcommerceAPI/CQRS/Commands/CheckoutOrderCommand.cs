using EcommerceAPI.Data.DTO.Checkout;
using MediatR;

namespace EcommerceAPI.CQRS.Commands
{
    public class CheckoutOrderCommand : IRequest
    {
        public CheckoutDTO Checkout { get; set; }
        public CheckoutOrderCommand(CheckoutDTO checkout) { Checkout = checkout; }
    }

}
