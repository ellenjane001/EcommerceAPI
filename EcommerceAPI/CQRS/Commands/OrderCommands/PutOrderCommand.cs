using EcommerceAPI.Data.DTO.Order;
using MediatR;

namespace EcommerceAPI.CQRS.Commands.OrderCommands
{
    public record PutOrderCommand(Guid OrderId, UpdateOrderDTO Order) : IRequest;
}
