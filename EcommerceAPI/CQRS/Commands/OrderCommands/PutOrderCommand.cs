using EcommerceAPI.Data.DTO.Order;
using MediatR;

namespace EcommerceAPI.CQRS.Commands.OrderCommands
{
    public class PutOrderCommand : IRequest
    {
        public Guid OrderId { get; set; }
        public UpdateOrderDTO OrderDTO { get; set; }

        public PutOrderCommand(Guid orderId, UpdateOrderDTO orderDTO)
        {
            OrderId = orderId;
            OrderDTO = orderDTO;
        }
    }
}
