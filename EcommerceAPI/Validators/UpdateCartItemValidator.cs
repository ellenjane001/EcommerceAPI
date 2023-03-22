using EcommerceAPI.CQRS.Commands.CartItemCommands;
using FluentValidation;

namespace EcommerceAPI.Validators
{
    public class UpdateCartItemValidator : AbstractValidator<PutCartItemCommand>
    {
        public UpdateCartItemValidator()
        {
            RuleFor(cartItem => cartItem.CartItemDTO.CartItemName).NotEmpty();
        }
    }
}
