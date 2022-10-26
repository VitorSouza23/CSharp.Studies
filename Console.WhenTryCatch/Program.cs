using static System.Console;

Random rdm = new();
string message = string.Empty;

try
{
    var flag = rdm.Next(0, 3);
    var execption = flag switch
    {
        1 => MyExcetpitonStatus.Ok(),
        2 => MyExcetpitonStatus.Bad(),
        3 => MyExcetpitonStatus.Fatal(),
        _ => MyExcetpitonStatus.Unknown()
    };

    throw execption;
}
catch (MyExcetpitonStatus ex) when (ex.Code == MyExcetpitonStatus.OkCode)
{
    message = "It's an Ok error";
}
catch (MyExcetpitonStatus ex) when (ex.Code == MyExcetpitonStatus.BadCode)
{
    message = "It's a Bad error";
}
catch (MyExcetpitonStatus ex) when (ex.Code == MyExcetpitonStatus.FatalCode)
{
    message = "It's a Fatal error";
}
catch (MyExcetpitonStatus ex) when (ex.Code == MyExcetpitonStatus.UnknownCode)
{
    message = "It's an Unknown error";
}

WriteLine(message);

class MyExcetpitonStatus : Exception
{
    public const int UnknownCode = 0;
    public const int OkCode = 1;
    public const int BadCode = 2;
    public const int FatalCode = 3;

    private MyExcetpitonStatus(int code)
    {
        Code = code;
    }

    public int Code { get; }

    public static MyExcetpitonStatus Unknown() => new(UnknownCode);
    public static MyExcetpitonStatus Ok() => new(OkCode);
    public static MyExcetpitonStatus Bad() => new(BadCode);
    public static MyExcetpitonStatus Fatal() => new(FatalCode);
}