using EcommerceAPI.Domain.Entities;
using MediatR;

namespace EcommerceAPI.Data.Queries
{
    public record GetOrderByIDQuery(Guid OrderId) : IRequest<Order>;
}
