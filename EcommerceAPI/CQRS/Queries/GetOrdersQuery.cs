using EcommerceAPI.Domain.Entities;
using MediatR;

namespace EcommerceAPI.CQRS.Queries
{
    public record GetOrdersQuery() : IRequest<IEnumerable<Order>>;
}
