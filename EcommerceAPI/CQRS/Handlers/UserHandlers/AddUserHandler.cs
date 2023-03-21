using EcommerceAPI.CQRS.Commands.UserCommands;
using EcommerceAPI.Domain.Interfaces;
using MediatR;

namespace EcommerceAPI.CQRS.Handlers.UserHandlers
{
    public class AddUserHandler : IRequestHandler<AddUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public AddUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.Post(request.User);
            return;
        }
    }
}
