List<string> repository = new();

var application = (string? text, Func<string, bool> store) =>
{
    return text switch
    {
        null => false,
        { Length: < 5 } => false,
        _ => store(text)
    };
};

var infrastructure = (string text) =>
{
    Console.WriteLine($"Storing: {text}");
    return true;
};

var console = (Func<string, bool> store, Func<string?, Func<string, bool>, bool> application) =>
{
    Console.WriteLine("What message you want store?");
    var text = Console.ReadLine();
    return application(text, store);
};

var result = console(infrastructure, application);
Console.WriteLine($"Stored successfully? {result}");

Console.ReadKey();
