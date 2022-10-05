using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using Kodlama.io.devs.Application.Features.Authorizations.Rules;
using Kodlama.io.devs.Application.Features.GitHubs.Rules;
using Kodlama.io.devs.Application.Features.OperationClaims.Rules;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Rules;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        services.AddScoped<GitHubBusinessRules>();
        services.AddScoped<OperationClaimBusinessRules>();
        #endregion

        #region FluentValidation
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        #endregion

        #region PiplineBehaviors
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        #endregion



        return services;
    }
}
