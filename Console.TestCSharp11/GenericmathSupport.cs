public interface ITest
{
    static abstract string Dump();
    static virtual int DumpNumber() => 1;
}

public class Test : ITest
{
    public static string Dump() => """
    Test string raw
    It's a good feature
    Testing "quotes"
    """;
}
