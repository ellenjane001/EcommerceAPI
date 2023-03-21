using EcommerceAPI.Domain.Entities;
using MediatR;

namespace EcommerceAPI.CQRS.Queries
{
    public record GetUsersQuery() : IRequest<IEnumerable<User>>;
}
