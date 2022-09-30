namespace Console.DateTimeOffsetTest;

public interface IDateTimeOffisetProvider
{
    DateTimeOffset Now { get; }
}

public sealed class DateTimeOffsetProvider : IDateTimeOffisetProvider
{
    public DateTimeOffset Now => DateTimeOffset.Now;
}
