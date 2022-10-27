using System.Globalization;
using System.Runtime.CompilerServices;

namespace Console.EverithingAwaitable;

public static class Extensions
{
    public static TaskAwaiter GetAwaiter(this Delay delay)
    {
        return Task.Delay(delay.Time).GetAwaiter();
    }
}