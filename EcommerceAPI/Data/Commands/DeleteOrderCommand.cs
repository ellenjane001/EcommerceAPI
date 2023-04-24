using MediatR;

namespace EcommerceAPI.Data.Commands
{
    public record DeleteOrderCommand(Guid OrderId) : IRequest;
}
