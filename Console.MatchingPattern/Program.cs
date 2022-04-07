Customer customer = new()
{
    Id = new Guid("5dcd25bf-cda3-4115-a279-b8abbac186b5"),
    Name = "Test",
    Actived = true,
    ActivationDate = new DateOnly(2001, 1, 1),
    Score = 50
};

if (customer is { ActivationDate.Year: > 2000 })
    Console.ForegroundColor = ConsoleColor.Yellow;
if (customer is { Category: CustomerCategory.Disabled })
    Console.ForegroundColor = ConsoleColor.Red;

Console.WriteLine($"The customer: {customer.Name} (Id: {customer.Id}) is categorized as {customer.Category}");

class Customer
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public DateOnly ActivationDate { get; set; }
    public int Score { get; set; }
    public bool Actived { get; set; }
    public int ActivedYears => ActivationDate.Year - DateTime.UtcNow.Year;
    public CustomerCategory Category => this switch
    {
        { Actived: false } => CustomerCategory.Disabled,
        Customer c when SpecialCases.IsSpecialSecretDate(c.ActivationDate) => CustomerCategory.Premium,
        { ActivedYears: < 3, Score: < 50} => CustomerCategory.Regular,
        { ActivedYears: < 3, Score: >= 50 } => CustomerCategory.Gold,
        { ActivedYears: >= 3, Score: < 70 } => CustomerCategory.Gold,
        { ActivedYears: >= 3, Score: >= 70 } => CustomerCategory.Premium,
        _ => CustomerCategory.Disabled
    };
}
enum CustomerCategory
{
    Disabled,
    Regular,
    Gold,
    Premium
}

static class SpecialCases
{
    public static bool IsSpecialSecretDate(DateOnly dateOnly)
    {
        return dateOnly is { Year: 2001, Month: 1, Day: 1 };
    }
}

