using System.Reflection;
using Application.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddMediatR(typeof(IAssemblyMarker));
        collection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        collection.AddTransient(typeof(IPipelineBehavior<,>),typeof(Validator<,>));
        
        return collection;
    }
}