using Core.Result;

var response = GetResponse("Test");

Console.WriteLine($"The response is {response}");

response = GetResponse(new Exception("This is an exception"));

Console.WriteLine($"The response is {response}");

static string? GetResponse(Result<string, Exception> result)
{
    return result switch
    {
        { IsSuccess: true } => result.Value,
        { IsSuccess: false } => result.Exception!.Message,
    };
}