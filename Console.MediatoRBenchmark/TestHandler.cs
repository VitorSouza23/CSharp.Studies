using MediatR;

namespace Console.MediatoRBenchmark;

public class TestRequest : IRequest<int>
{
    public int Number { get; set; }
}

public class TestHandler : IRequestHandler<TestRequest, int>
{
    public Task<int> Handle(TestRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(345 + request.Number);
    }
}

public class TestService
{
    public Task<int> Handle(int number)
    {
        return Task.FromResult(345 + number);
    }
}