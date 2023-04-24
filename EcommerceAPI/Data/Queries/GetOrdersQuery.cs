using EcommerceAPI.Domain.Entities;
using MediatR;

namespace EcommerceAPI.Data.Queries
{
    public record GetOrdersQuery() : IRequest<IEnumerable<Order>>;
}
