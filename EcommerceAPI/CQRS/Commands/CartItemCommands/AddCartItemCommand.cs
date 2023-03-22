using EcommerceAPI.Data.DTO.CartItem;
using MediatR;

namespace EcommerceAPI.CQRS.Commands.CartItemCommands
{
    public class AddCartItemCommand : IRequest
    {
        public AddCartItemDTO CartItem { get; set; }

        public AddCartItemCommand(AddCartItemDTO cartItem)
        {
            CartItem = cartItem;
        }
    }
}
