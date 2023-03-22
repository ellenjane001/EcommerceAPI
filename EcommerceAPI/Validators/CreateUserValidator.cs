using EcommerceAPI.CQRS.Commands.UserCommands;
using FluentValidation;

namespace EcommerceAPI.Validators
{
    public class CreateUserValidator : AbstractValidator<AddUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(user => user.User.UserName).NotEmpty().NotNull().Equals("string");
        }
    }
}
