using ModelContextProtocol.AspNetCore;
using OpenSkyMcpServer.Options;

namespace OpenSkyMcpServer.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHostDependencies(this IServiceCollection services)
    {
        services
            .AddOptions()
            .ConfigureMcpServer()
            ;
        
        return services;
    }
    
    private static IServiceCollection AddOptions(this IServiceCollection services)
    {
        services
            .AddOptionsWithValidateOnStart<OpenSkyApiOptions>()
            .BindConfiguration(OpenSkyApiOptions.OpenSkyApi)
            .ValidateDataAnnotations();
        
        return services;
    }

    private static IServiceCollection ConfigureMcpServer(this IServiceCollection services)
    {
        services
            .AddMcpServer()
            .WithHttpTransport(options =>
            {
                options.SessionMode = HttpServerSessionMode.Stateless;
            })
            .WithToolsFromAssembly();
        
        return services;
    }
}