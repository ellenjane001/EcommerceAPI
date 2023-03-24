using FluentValidation;
using MediatR;

namespace EcommerceAPI.ValidatorBehavior
{
    internal class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var failures = _validators.Select(v => v.Validate(request)).SelectMany(result => result.Errors).Where(f => f != null).ToList();
            if (failures.Any())
            {
                throw new FluentValidation.ValidationException(failures);
            }

            return await next();
        }
    }
}
