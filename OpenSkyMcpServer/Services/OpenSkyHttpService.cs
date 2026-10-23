namespace OpenSkyMcpServer.Services;

public class OpenSkyHttpService : IOpenSkyHttpService
{
    private readonly HttpClient httpClient;

    public OpenSkyHttpService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    
    
}