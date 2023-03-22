using MediatR;

namespace EcommerceAPI.CQRS.Commands.OrderCommands
{
    public class DeleteOrderCommand : IRequest
    {
        public Guid OrderId { get; set; }

        public DeleteOrderCommand(Guid orderId)
        {
            OrderId = orderId;
        }
    }

}
