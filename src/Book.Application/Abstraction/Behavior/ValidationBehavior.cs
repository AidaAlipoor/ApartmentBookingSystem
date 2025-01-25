using Book.Application.Abstraction.Messaging;
using Book.Application.Exception;
using FluentValidation;
using MediatR;

namespace Book.Application.Abstraction.Behavior
{
    public class ValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IBaseCommand
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validators.Any() is false)
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var validationErrors = _validators
                .Select(validation => validation.Validate(context))
                .Where(validationResult => validationResult.Errors.Any())
                .SelectMany(validationResult => validationResult.Errors)
                .Select(validationFailure => new ValidationError
                (validationFailure.PropertyName, validationFailure.ErrorMessage))
                .ToList();  

            if(validationErrors.Any())
            {
                throw new Exception.ValidationException(validationErrors);
            }

            return await next();
        }
    }
}
