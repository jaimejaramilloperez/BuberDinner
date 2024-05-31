using BuberDinner.Api.Common.Errors;
using BuberDinner.Api.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberDinner.Api;

public static class DependencyInjectionRegister
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddMappings();
        services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();

        return services;
    }
}
