using EcommerceAPI.Domain.Entities;
using MediatR;

namespace EcommerceAPI.CQRS.Queries
{
    public record GetOrderByIDQuery(Guid OrderId) : IRequest<Order>;
}
