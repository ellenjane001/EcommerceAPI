using EcommerceAPI.Data.DTO.CartItem;
using FluentValidation;

namespace EcommerceAPI.Validators
{
    public class AddCartItemValidator : AbstractValidator<AddCartItemDTO>
    {
        public AddCartItemValidator()
        {
            RuleFor(cartItem => cartItem.CartItemName).NotEmpty();
        }
    }
}
