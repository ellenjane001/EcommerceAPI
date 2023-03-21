using EcommerceAPI.Domain.Entities;
using MediatR;

namespace EcommerceAPI.CQRS.Queries
{
    public record GetUserByIdQuery(Guid UserId) : IRequest<User>;
}
