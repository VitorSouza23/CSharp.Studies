using Console.TestCSahrp11;
using static System.Console;

var testRequired = new RequiredFields
{
    Name = "Test",
    Age = 123
};

WriteLine($$"""
    Just Testing some features:
    Name: {{testRequired.Name}}
    Age: {{testRequired.Age}}
""");

//List patterns
int[] arr = { 1, 2, 3, 4, 5, 6 };
WriteLine(arr is [1, 2, 3, 4, 5, 6]);
WriteLine(arr is [_, _, 3, _, _, _]);
WriteLine(arr is [>= 1, 3, _, _, 6]);

if (arr is [.., var lastElement]) WriteLine(lastElement);