using EcommerceAPI.Data.DTO.User;
using MediatR;

namespace EcommerceAPI.CQRS.Commands.UserCommands
{
    public record AddUserCommand(CreateUserDTO User) : IRequest;

}
