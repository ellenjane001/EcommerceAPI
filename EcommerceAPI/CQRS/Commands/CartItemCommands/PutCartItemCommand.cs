using EcommerceAPI.Data.DTO.CartItem;
using MediatR;

namespace EcommerceAPI.CQRS.Commands.CartItemCommands
{
    public class PutCartItemCommand : IRequest
    {
        public Guid CartItemId { get; set; }
        public UpdateCartItemDTO CartItemDTO { get; set; }
        public PutCartItemCommand(Guid cartItemId, UpdateCartItemDTO cartItemDTO)
        {
            CartItemId = cartItemId;
            CartItemDTO = cartItemDTO;
        }
    }
}
