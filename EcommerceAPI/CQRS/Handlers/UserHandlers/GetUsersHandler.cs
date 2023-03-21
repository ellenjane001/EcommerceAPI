﻿using EcommerceAPI.CQRS.Queries;
using EcommerceAPI.Domain.Entities;
using EcommerceAPI.Domain.Interfaces;
using MediatR;

namespace EcommerceAPI.CQRS.Handlers.UserHandlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken) => await _userRepository.GetUsers();
    }
}
