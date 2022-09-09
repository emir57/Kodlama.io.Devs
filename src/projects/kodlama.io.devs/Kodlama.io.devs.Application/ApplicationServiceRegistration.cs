using Core.Application.Pipelines.Validation;
using FluentValidation;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Kodlama.io.devs.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddScoped<ProgrammingLanguageBusinessRules>();
        services.AddScoped<ProgrammingLanguageTechnologyBusinessRules>();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        return services;
    }
}
