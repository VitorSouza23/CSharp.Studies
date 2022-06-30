Customer c = new();

Console.WriteLine($"Customer ID: {c.Id}");
Console.WriteLine($"Order description: {c.Order.Description}"); //The object going to initialized here


class Customer
{
    private readonly Lazy<Order> _orders;

    public Guid Id { get; }

    public Customer()
    {
        Id = Guid.NewGuid();
        _orders = new(() => new Order(Id, "Test")); //The object going to just be initialized when called
    }

    public Order Order
    {
        get => _orders.Value;
    }
}

class Order
{
    public Order(Guid customerId, string description)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        Description = description;
    }

    public Guid Id { get; }
    public Guid CustomerId { get; set; }
    public string Description { get; set; }
}