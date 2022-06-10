using BenchmarkDotNet.Attributes;
using System.Text;

namespace Console.StringManipulationBenchmark;

[MemoryDiagnoser]
public class ChangeString
{
    private const string _password = "GreatePassword";

    [Benchmark]
    public string ForMethod()
    {
        var firstChars = _password.Substring(0, 3);
        var length = _password.Length - 3;

        for (int index = 0; index < length; index++)
        {
            firstChars += '*';
        }

        return firstChars;
    }

    [Benchmark]
    public string StringBuilderMehtod()
    {
        var firstChars = _password.Substring(0, 3);
        var length = _password.Length - 3;
        var stringBuilder = new StringBuilder(firstChars);

        for (int index = 0; index < length; index++)
        {
            stringBuilder.Append('*');
        }

        return stringBuilder.ToString();
    }

    [Benchmark]
    public string SpanMethod()
    {
        return string.Create(_password.Length, _password, (span, value) =>
        {
            value.AsSpan().CopyTo(span);
            span[3..].Fill('*');
        });
    }
}
