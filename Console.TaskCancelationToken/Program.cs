using static System.Console;

var source = new CancellationTokenSource();
var token = source.Token;

Task.Run(async () =>
{
    while (true)
    {
        WriteLine("I'm running!");
        var wait = TimeSpan.FromSeconds(1);
        await Task.Delay(wait, token);
    }
}, token);

ReadKey();
source.Cancel();
WriteLine("Canceled!");
ReadKey();