using MediatR;

namespace EcommerceAPI.CQRS.Commands.CartItemCommands
{
    public class DeleteCartItemCommand : IRequest
    {
        public Guid CartItemId { get; set; }

        public DeleteCartItemCommand(Guid cartItemId)
        {
            CartItemId = cartItemId;
        }
    }
}
