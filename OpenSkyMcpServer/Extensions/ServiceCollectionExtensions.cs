using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using ModelContextProtocol.AspNetCore;
using OpenSkyMcpServer.Options;
using OpenSkyMcpServer.Services;

namespace OpenSkyMcpServer.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHostDependencies(this IServiceCollection services)
    {
        services
            .AddOptions()
            .ConfigureMcpServer()
            .AddOpenSkyHttpClient()
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
    
    private static IServiceCollection AddOpenSkyHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient<IOpenSkyHttpService, OpenSkyHttpService>((sp, httpClient) =>
        {
            var openSkyOptions = sp.GetRequiredService<IOptions<OpenSkyApiOptions>>().Value;
            
            httpClient.BaseAddress = new Uri(openSkyOptions.BaseUrl);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", openSkyOptions.Token);
        });
        
        return services;
    }
}