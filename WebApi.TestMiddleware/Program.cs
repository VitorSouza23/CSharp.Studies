var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var log = app.Services.GetService<ILogger<Program>>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/test", () => "This is a test");

//Testing Middleware logics

//Use and Next()

app.Use(async (_, next) =>
{
    log?.LogInformation("Calling Use and Next()");
    await next.Invoke();
});

//Basic one
app.Run(async context =>
{
    log?.LogInformation("Calling basic Middleware");
    await context.Response.WriteAsync("Hello World");
});

app.Run();