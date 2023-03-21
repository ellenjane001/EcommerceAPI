using EcommerceAPI.Data.DTO.Order;
using FluentValidation;

namespace EcommerceAPI.Validators
{
    public class OrderValidator : AbstractValidator<UpdateOrderDTO>
    {
        public OrderValidator()
        {
            RuleFor(order => order.Status).NotEmpty();
        }
    }
}
