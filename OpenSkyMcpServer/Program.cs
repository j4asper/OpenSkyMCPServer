using OpenSkyMcpServer.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostDependencies();

var app = builder.Build();

app.MapMcp();

app.Run();