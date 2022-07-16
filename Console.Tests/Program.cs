using System.Text.RegularExpressions;

string[] inputs =
{
    "S;M;plasticCup()", "C;V;mobile phone", "C;C;coffee machine", "S;C;LargeSoftwareBook", "C;M;white sheet of paper",
    "S;V;pictureFrame"
};

foreach (var input in inputs)
{
    var commands = input.Split(';');

    if (commands[0] == "S")
    {
        var result = CombineToSplited(commands[2]);
        if (commands[1] == "M")
            result = result.Substring(0, result.Length - 2);

        Console.WriteLine(result);
    }
    else
    {
        var result = SplitedToCombine(commands[2]);
        if (commands[1] == "M")
            result = result + "()";
        if (commands[1] == "C")
            result = char.ToUpper(result[0]) + result.Substring(1, result.Length - 1);
        Console.WriteLine(result);
    }
}

string CombineToSplited(string inp)
{
    return Regex
        .Replace(inp, @"(\p{Lu})", " $1")
        .TrimStart()
        .ToLower();
}

string SplitedToCombine(string inp)
{
    var values = inp.Split(' ');
    for (var x = 1; x < values.Length; x++)
    {
        values[x] = char.ToUpper(values[x][0]) + values[x].Substring(1, values[x].Length -1);
    }

    return string.Concat(values);
}