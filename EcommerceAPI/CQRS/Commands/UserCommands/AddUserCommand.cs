using EcommerceAPI.Data.DTO.User;
using MediatR;

namespace EcommerceAPI.CQRS.Commands.UserCommands
{
    public class AddUserCommand : IRequest<Guid>
    {
        public CreateUserDTO User { get; set; }

        public AddUserCommand(CreateUserDTO user)
        {
            User = user;
        }
    }

}
