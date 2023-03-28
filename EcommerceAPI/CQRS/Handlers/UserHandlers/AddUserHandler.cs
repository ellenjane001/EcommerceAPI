using EcommerceAPI.CQRS.Commands.UserCommands;
using EcommerceAPI.Domain.Interfaces;
using MediatR;

namespace EcommerceAPI.CQRS.Handlers.UserHandlers
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        public AddUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var UserId = await _userRepository.Post(request.User);
            return UserId;
        }
    }
}
