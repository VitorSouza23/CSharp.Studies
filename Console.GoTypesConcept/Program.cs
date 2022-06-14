IPerson p = new Person(1, "Test", new DateOnly(2000, 1, 1));

Console.WriteLine($"{p.Name} is {p.CalcualateAge(DateOnly.FromDateTime(DateTime.Now))} years old");

interface IPerson
{
    int Id { get; }
    string Name { get; }
    DateOnly BirthDay { get; }
    int CalcualateAge(DateOnly referenceDate)
    {
        return Math.Abs(referenceDate.Year - BirthDay.Year);
    }
}

record Person(int Id, string Name, DateOnly BirthDay) : IPerson;