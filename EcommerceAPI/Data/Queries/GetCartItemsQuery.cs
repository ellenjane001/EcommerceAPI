using EcommerceAPI.Domain.Entities;
using MediatR;

namespace EcommerceAPI.Data.Queries
{
    public record GetCartItemsQuery() : IRequest<IEnumerable<CartItem>>;
}
