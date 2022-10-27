namespace Console.EverithingAwaitable;

public class Delay
{
    public TimeSpan Time { get; }

    private Delay(TimeSpan timeSpan)
    {
        Time = timeSpan;
    }

    public static Delay Seconds(int seconds) => new(TimeSpan.FromSeconds(seconds));
}