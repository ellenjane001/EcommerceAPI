using EcommerceAPI.DTO.CartItem;
using MediatR;

namespace EcommerceAPI.Data.Commands
{
    public record PutCartItemCommand(Guid CartItemId, UpdateCartItemDTO CartItem) : IRequest;
}
