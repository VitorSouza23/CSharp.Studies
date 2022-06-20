using WebApi.TestPriodicTimer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<TimerService>();

var app = builder.Build();

app.Run();