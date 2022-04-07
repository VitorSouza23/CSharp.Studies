using PipeFunctions;
const string name = "Gerimu";

name.Pipe(v =>
{
    var hello = $"Hello {v}";
    Console.WriteLine(hello);
    return hello;
})
    .Pipe(v =>
    {
        Console.WriteLine("It's a pleasure to meet you");
        return v;
    });