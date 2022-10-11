using static System.Console;

WriteLine("Case 1: Seed constructor is not Thread Safe");
ParallelTest(new Random(532));

WriteLine();
WriteLine("Case 2: Derivative class constructor uses dotnet5 compatibility");
ParallelTest(new MyRandom());

WriteLine();
WriteLine("Case 3: After dotnet6 default constructor is Thread Safe");
ParallelTest(new Random());

WriteLine();
WriteLine("Case 4: Random.Shared alternative");
ParallelTest(Random.Shared);

void ParallelTest(Random random)
{
    Parallel.For(1, 20, _ =>
    {
        var numbers = new int[10_000];
        for (var i = 0; i < numbers.Length; i++) numbers[i] = random.Next();
        var issues = numbers.Count(x => x == 0);
        WriteLine($"Issues: {issues}");
    });
}

class MyRandom : Random {}