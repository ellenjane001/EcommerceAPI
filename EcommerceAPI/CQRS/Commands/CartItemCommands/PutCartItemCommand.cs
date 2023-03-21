using EcommerceAPI.Data.DTO.CartItem;
using MediatR;

namespace EcommerceAPI.CQRS.Commands.CartItemCommands
{
    public record PutCartItemCommand(Guid CartItemId, UpdateCartItemDTO CartItem) : IRequest;
}
