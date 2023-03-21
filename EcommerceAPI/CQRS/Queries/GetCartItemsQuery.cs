using EcommerceAPI.Domain.Entities;
using MediatR;

namespace EcommerceAPI.CQRS.Queries
{
    public record GetCartItemsQuery() : IRequest<IEnumerable<CartItem>>;
}
