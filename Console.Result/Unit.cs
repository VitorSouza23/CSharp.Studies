namespace Core.Result;

public record struct Unit();

public readonly partial struct Result<TValue, TException>
{
    public static Result<Unit, TException> Unit => new Result<Unit, TException>(new Unit());
}