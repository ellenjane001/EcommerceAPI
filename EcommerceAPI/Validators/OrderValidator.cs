using EcommerceAPI.CQRS.Commands.OrderCommands;
using FluentValidation;

namespace EcommerceAPI.Validators
{
    public class OrderValidator : AbstractValidator<PutOrderCommand>
    {
        public OrderValidator()
        {
            RuleFor(order => order.OrderDTO.Status).NotEmpty();
        }
    }
}
