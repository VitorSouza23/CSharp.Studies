using System.Reflection;

Console.WriteLine("Enter a number:");
string value = Console.ReadLine() ?? "";
ProcessInput(value);


static void ProcessInput(string input)
{
    var iRuleType = typeof(IRule);
    var types = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(s => s.GetTypes())
        .Where(p => iRuleType.IsAssignableFrom(p) && !p.IsInterface);

    foreach(var type in types)
    {
        IRule? rule = (IRule)Assembly.GetExecutingAssembly().CreateInstance(type.FullName, false);

        if (rule is not null && rule.Verify(input))
            rule.Execute();
    }
}

interface IRule
{
    bool Verify(string choice);
    void Execute();
}

class NotANumberRule : IRule
{
    public void Execute()
    {
        Console.WriteLine("Please, a number");
    }

    public bool Verify(string choice)
    {
        return !choice.All(char.IsDigit);
    }
}

class IsANumberRule : IRule
{
    public void Execute()
    {
        Console.WriteLine("Nice number!");
    }

    public bool Verify(string choice)
    {
        return choice.All(char.IsDigit);
    }
}