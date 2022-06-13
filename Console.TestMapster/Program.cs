using Mapster;

var a = new TestA { Name = "Test", Age = 30 };
var b = a.Adapt<TestB>();
Console.WriteLine($"Name: {b.Name} - Age: {b.Age}");

internal class TestA
{
    public string? Name { get; set; }
    public int Age { get; set; }
}

internal class TestB
{
    public string? Name { get; set; }
    public int Age { get; set; }
}