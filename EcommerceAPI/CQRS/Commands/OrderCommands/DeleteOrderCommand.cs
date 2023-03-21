using MediatR;

namespace EcommerceAPI.CQRS.Commands.OrderCommands
{
    public record DeleteOrderCommand(Guid OrderId) : IRequest;
}
