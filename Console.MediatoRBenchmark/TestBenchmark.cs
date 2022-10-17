using BenchmarkDotNet.Attributes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Console.MediatoRBenchmark;

[MemoryDiagnoser]
public class TestBenchmark
{
    private readonly IMediator _mediator;
    private readonly TestService _testService;
    
    public TestBenchmark()
    {
        var services = new ServiceCollection()
            .AddMediatR(typeof(TestBenchmark))
            .AddScoped<TestService>();
        var serviceProvider = services.BuildServiceProvider();
        _mediator = serviceProvider!.GetRequiredService<IMediator>();
        _testService = serviceProvider!.GetRequiredService<TestService>();
    }

    [Benchmark]
    public async Task<int> MediatR()
    {
        var request = new TestRequest { Number = 23 };
        return await _mediator.Send(request);
    }

    [Benchmark]
    public async Task<int> Direct()
    {
        return await _testService.Handle(23);
    }
}