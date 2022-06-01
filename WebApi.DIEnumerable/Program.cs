using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

ServiceDescriptor testADescriptor = new(typeof(ITest), typeof(TestA), ServiceLifetime.Singleton);
ServiceDescriptor testBDescriptor = new(typeof(ITest), typeof(TestB), ServiceLifetime.Singleton);

builder.Services.TryAddEnumerable(new[] {testADescriptor, testBDescriptor});

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/test", (IEnumerable<ITest> tests) =>
{
    string result = string.Join(',', tests.Select(t => t.GetNumber()));
    return Results.Ok(result);
});


app.Run();

internal interface ITest
{
    int GetNumber();
}

internal class TestA : ITest
{
    public int GetNumber() => 123;
}

internal class TestB : ITest
{
    public int GetNumber() => 42;
}