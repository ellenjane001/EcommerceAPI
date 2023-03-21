using EcommerceAPI.Data.DTO.CartItem;
using MediatR;

namespace EcommerceAPI.CQRS.Commands.CartItemCommands
{
    public record AddCartItemCommand(AddCartItemDTO CartItem) : IRequest;
}
