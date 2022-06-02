using BenchmarkDotNet.Attributes;

namespace Console.FibonacciBenchmark;

[MemoryDiagnoser]
public class BenchmarkTest
{
    [Benchmark]
    public void Recursive_100()
    {
        Fibonacci.Recursive(100);
    }

    [Benchmark]
    public void Memo_100()
    {
        Fibonacci.Memo(100);
    }
    
    [Benchmark]
    public void BottomUp_100()
    {
        Fibonacci.BottomUp(100);
    }
}