using CliWrap;
using static System.Console;

var cli = Cli.Wrap("git")
    .WithArguments("status")
    | (WriteLine);

await cli.ExecuteAsync();