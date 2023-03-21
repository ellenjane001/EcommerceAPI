using EcommerceAPI.Data.DTO.CartItem;
using FluentValidation;

namespace EcommerceAPI.Validators
{
    public class UpdateCartItemValidator : AbstractValidator<UpdateCartItemDTO>
    {
        public UpdateCartItemValidator()
        {
            RuleFor(cartItem => cartItem.CartItemName).NotEmpty();
        }
    }
}
