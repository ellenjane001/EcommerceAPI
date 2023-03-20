using EcommerceAPI.DTO.CartItem;
using MediatR;

namespace EcommerceAPI.Data.Commands
{
    public record AddCartItemCommand(AddCartItemDTO cartItem) : IRequest;
}
