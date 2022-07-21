Customer c = new();
Product p = new();
Order o = new();

Console.WriteLine(c);
Console.WriteLine(p);
Console.WriteLine(o);

Console.WriteLine();

Customer c1 = new() { BirthDate = DateOnly.FromDateTime(DateTime.UtcNow), Id = Guid.NewGuid(), Name = "Test"};
Product p1 = new() { Name = "Test Product", Id = Guid.NewGuid(), Price = 10.23f };
Order o1 = new() { Id = Guid.NewGuid(), Customer = c1, Product = p1 };

Console.WriteLine(c1);
Console.WriteLine(p1);
Console.WriteLine(o1);

Console.WriteLine();

Customer c2 = Customer.Empty;
Product p2 = Product.Empty;
Order o2 = Order.Empty;

Console.WriteLine(c2);
Console.WriteLine(p2);
Console.WriteLine(o2);

internal class Customer
{
    public Guid Id { get; init; } = default!;
    public string Name { get; init; } = default!;
    public DateOnly BirthDate { get; init; } = default!;

    public override string ToString()
    {
        return $"Id: {Id}; Name: {Name}; Birth Date: {BirthDate}";
    }

    public static Customer Empty => new() { Id = Guid.Empty };
}

internal class Product
{
    public Guid Id { get; init; } = default!;
    public string Name { get; init; } = default!;
    public float Price { get; init; } = default!;

    public override string ToString()
    {
        return $"Id: {Id}; Name: {Name}; Price: {Price:2}";
    }

    public static Product Empty => new() { Id = Guid.Empty };
}


internal class Order
{
    public Guid Id { get; init; } = default!;
    public Product Product { get; init; } = default!;
    public Customer Customer { get; init; } = default!;

    public override string ToString()
    {
        return $"Id: {Id}; Product: {Product}; Customer: {Customer}";
    }

    public static Order Empty => new() { Id = Guid.Empty, Product = Product.Empty, Customer = Customer.Empty};
}