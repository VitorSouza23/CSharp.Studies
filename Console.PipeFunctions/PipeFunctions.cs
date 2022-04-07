namespace PipeFunctions;

public static class PipeFunctions
{
    public static TOut? Pipe<TIn, TOut>(this TIn? input, Func<TIn?, TOut?>? func)
    {
        return func != null ? func.Invoke(input) : default;
    }
}
