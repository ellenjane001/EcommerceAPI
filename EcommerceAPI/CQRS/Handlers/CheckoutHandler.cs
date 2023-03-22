using EcommerceAPI.CQRS.Commands;
using EcommerceAPI.Domain.Interfaces;
using MediatR;

namespace EcommerceAPI.CQRS.Handlers
{
    public class CheckoutHandler : IRequestHandler<CheckoutOrderCommand>
    {
        private readonly ICheckoutRepository _checkoutRepository;
        public CheckoutHandler(ICheckoutRepository checkoutRepository)
        {
            _checkoutRepository = checkoutRepository;
        }
        public async Task Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            await _checkoutRepository.Checkout(request.Checkout);
            return;
        }
    }
}
