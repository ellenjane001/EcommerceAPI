using EcommerceAPI.DTO.Order;
using MediatR;

namespace EcommerceAPI.Data.Commands
{
    public record PutOrderCommand(Guid OrderId, UpdateOrderDTO order) : IRequest;
}
