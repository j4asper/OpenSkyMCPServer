using System.ComponentModel.DataAnnotations;

namespace OpenSkyMcpServer.Options;

public class OpenSkyApiOptions
{
    public static readonly string OpenSkyApi = nameof(OpenSkyApi);
    
    [Required(AllowEmptyStrings = false)]
    public required string BaseUrl { get; set; }
    
    [Required(AllowEmptyStrings = false)]
    public required string Token { get; set; }
}