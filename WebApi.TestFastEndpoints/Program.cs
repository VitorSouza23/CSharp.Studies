global using FastEndpoints;
global using FastEndpoints.Security;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddAuthenticationJWTBearer("TokenSigningKey1");
builder.Services.AddLogging();
builder.Services.AddSwaggerDoc();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints(config => config.RoutingOptions = o => o.Prefix = "api");
app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults(s => s.Path = ""));
app.Run();