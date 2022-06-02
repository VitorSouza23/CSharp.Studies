using BenchmarkDotNet.Attributes;

namespace Console.FibonacciBenchmark;

[MemoryDiagnoser]
public class BenchmarkTest
{
    [Benchmark]
    public void Recursive_10()
    {
        Fibonacci.Recursive(10);
    }

    [Benchmark]
    public void Memo_10()
    {
        Fibonacci.Memo(10);
    }
    
    [Benchmark]
    public void BottomUp_10()
    {
        Fibonacci.BottomUp(10);
    }
}