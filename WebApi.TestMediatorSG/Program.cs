using Mediator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediator();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", async (IMediator mediator) =>
{
    var response = await mediator.Send(new WeatherForecastRequest());
    return Results.Ok(response);
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

public sealed record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public sealed record WeatherForecastRequest() : IRequest<WeatherForecast[]>
{

}

public sealed class WeatherForecastHandler : IRequestHandler<WeatherForecastRequest, WeatherForecast[]>
{
    private readonly string[] _summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public ValueTask<WeatherForecast[]> Handle(WeatherForecastRequest request, CancellationToken cancellationToken)
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            _summaries[Random.Shared.Next(_summaries.Length)]
        ))
        .ToArray();
        return new ValueTask<WeatherForecast[]>(forecast);
    }
}