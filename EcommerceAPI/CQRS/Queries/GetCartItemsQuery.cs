using MediatR;

namespace EcommerceAPI.CQRS.Queries
{
    public record GetCartItemsQuery() : IRequest<IEnumerable<Domain.Entities.CartItem>>;
}
