using System.ComponentModel.DataAnnotations;
using FluentValidation;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace Application.Validation;

public class Validator<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    
    public Validator(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var err = _validators
            .Select(x => x.Validate(context))
            .SelectMany(y => y.Errors)
            .Where(z => z is not null).ToList();
        
        if (err.Count is not 0) throw new ValidationException(err);
        
        return next();
    }
}