Console.WriteLine(1.ToString().PadLeft(5, '0'));
Console.WriteLine(Convert.ToString(1 << 1, 2).PadLeft(5, '0'));
Console.WriteLine(Convert.ToString(1 << 2, 2).PadLeft(5, '0'));
Console.WriteLine(Convert.ToString(1 << 3, 2).PadLeft(5, '0'));
Console.WriteLine(Convert.ToString(1 << 4, 2).PadLeft(5, '0'));

var scope = Scope.Engineer | Scope.Administrator;

if((scope & Scope.Viewer) == Scope.Viewer)
{
    Console.WriteLine("It's a v");
}

if ((scope & Scope.Operator) == Scope.Operator)
{
    Console.WriteLine("It's an Operator");
}

if ((scope & Scope.Engineer) == Scope.Engineer)
{
    Console.WriteLine("It's an Engineer");
}

if ((scope & Scope.Administrator) == Scope.Administrator)
{
    Console.WriteLine("It's an Administrator");
}

if ((scope & Scope.Owner) == Scope.Owner)
{
    Console.WriteLine("It's an Owner");
}

Console.WriteLine($"Current scopes: {scope}");

if(scope.HasFlag(Scope.Operator) is false)
{
    Console.WriteLine("It isn't an Operator");
}


[Flags]
enum Scope
{
    Viewer = 1,
    Operator = 1 << 1,
    Engineer = 1 << 2,
    Administrator = 1 << 3,
    Owner = 1 << 4
}