using MediatR;

namespace EcommerceAPI.CQRS.Commands.CartItemCommands
{
    public record DeleteCartItemCommand(Guid CartItemId) : IRequest;
}
