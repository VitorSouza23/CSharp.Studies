var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

string CollorName(string color) => $"Color specified: {color}";

app.MapGet("/colorSelector/{color}", CollorName)
    .AddEndpointFilter(async (invocationContext, next) =>
    {
        var color = invocationContext.GetArgument<string>(0);
        if (color is "Blue") return Results.Problem("Blue is not allowed!");
        return await next(invocationContext);
    });

app.Run();