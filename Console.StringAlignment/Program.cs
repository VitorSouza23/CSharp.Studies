using static System.Console;

var number = 1;
new List<string>
{
    //nomral
    $"|{number}|",
    //left-aligned
    $"|{number, -10}|",
    //right-aligned
    $"|{number, 10}|"
}.ForEach(WriteLine);