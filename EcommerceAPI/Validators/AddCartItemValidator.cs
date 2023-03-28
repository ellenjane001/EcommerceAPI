using EcommerceAPI.CQRS.Commands.CartItemCommands;
using FluentValidation;

namespace EcommerceAPI.Validators
{
    public class AddCartItemValidator : AbstractValidator<AddCartItemCommand>
    {
        public AddCartItemValidator()
        {
            RuleFor(cartItem => cartItem.CartItem.CartItemName)
            .NotEqual("string", StringComparer.OrdinalIgnoreCase).WithMessage("The value 'string' is not allowed.")
            .NotEmpty().WithMessage("Must not be empty")
            .NotNull().WithMessage("Null is not allowed");
        }
    }
}
