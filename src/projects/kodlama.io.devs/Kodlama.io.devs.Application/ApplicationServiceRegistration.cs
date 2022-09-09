using Core.Application.Pipelines.Validation;
using FluentValidation;
using Kodlama.io.devs.Application.Features.Authorizations.Rules;
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
        #region AutoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        #endregion

        #region MediatR
        services.AddMediatR(Assembly.GetExecutingAssembly());
        #endregion

        #region BusinessRules
        services.AddScoped<ProgrammingLanguageBusinessRules>();
        services.AddScoped<ProgrammingLanguageTechnologyBusinessRules>();
        services.AddScoped<AuthorizationBusinessRules>();
        #endregion

        #region FluentValidation
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        #endregion

        #region PiplineBehaviors
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        #endregion

        return services;
    }
}
