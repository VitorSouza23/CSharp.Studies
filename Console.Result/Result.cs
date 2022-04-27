namespace Core.Result;

public readonly partial struct Result<TValue, TException> where TException : Exception
{
    public Result(TValue value)
    {
        Value = value;
        Exception = default;
    }

    public Result(TException exception)
    {
        Exception = exception;
        Value = default;
    }

    public Result()
    {
        Value = default;
        Exception = default;
    }

    public bool IsSuccess => Exception is null;
    public TValue? Value { get; private init; }
    public TException? Exception { get; private init; }

    public static implicit operator TValue?(Result<TValue, TException> result) => result.Value;
    public static implicit operator TException?(Result<TValue, TException> result) => result.Exception;
    public static implicit operator Result<TValue, TException>(TValue value) => new Result<TValue, TException>(value);
    public static implicit operator Result<TValue, TException>(TException ex) => new Result<TValue, TException>(ex);
}