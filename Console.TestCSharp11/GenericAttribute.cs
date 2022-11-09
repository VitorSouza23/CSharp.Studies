namespace Console.TestCSahrp11;

[AttributeUsage(AttributeTargets.Method)]
public class GenericAttributes<T> : Attribute { }

public class GenericClass
{
    [GenericAttributes<string>]
    public string Method() => default;
}