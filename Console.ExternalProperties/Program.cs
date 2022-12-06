using System.Runtime.CompilerServices;

ExternalClass test = new()
{
    SomeProperty = 123
};

test.GetProperties().ExtendedProperty = "New Test";

Console.WriteLine($"Base value {test.SomeProperty} - Extended value: {test.GetProperties().ExtendedProperty}");

class ExternalClass
{
    public int SomeProperty { get; set; }
}

class ExternalClassMetadata
{
    public string? ExtendedProperty { get; set; }
}

static class ExternalClassExtensions
{
    public static readonly ConditionalWeakTable<ExternalClass, ExternalClassMetadata> Data = new();

    public static ExternalClassMetadata GetProperties(this ExternalClass obj)
    {
        return Data.GetOrCreateValue(obj);
    }
}