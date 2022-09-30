namespace Console.DateTimeOffsetTest;

public interface IProcessDateTimeService
{
    string GetNowPeriodName();
}

public class ProcessDateTimeService : IProcessDateTimeService
{
    private readonly IDateTimeOffisetProvider _dateTimeOffsetProvider;

    public ProcessDateTimeService(IDateTimeOffisetProvider provider)
    {
        _dateTimeOffsetProvider = provider;
    }

    public string GetNowPeriodName()
    {
        var now = _dateTimeOffsetProvider.Now;

        return now.Hour switch
        {
            >= 0 and < 6 => "Dawn",
            >= 6 and < 12 => "Morning",
            >= 12 and < 18 => "Afternon",
            _ => "Night"
        };
    }
}
