using EcommerceAPI.Data.DTO.User;
using FluentValidation;

namespace EcommerceAPI.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserValidator()
        {
            RuleFor(user => user.UserName).NotEmpty().NotNull().Equals("string");
        }
    }
}
