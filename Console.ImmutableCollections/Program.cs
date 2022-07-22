using System.Collections.Immutable;

IImmutableList<int> immutableList = ImmutableList.Create<int>();

immutableList = immutableList.Add(0);
immutableList = immutableList.Add(1);
immutableList = immutableList.Add(2);

foreach(int x in immutableList)
    Console.WriteLine(x);

immutableList = immutableList.Remove(0);

foreach (int x in immutableList)
    Console.WriteLine(x);


Customer customer = new() { Name = "Test", Id = Guid.NewGuid()};

IImmutableList<Customer> immutableList2 = ImmutableList.Create<Customer>();
immutableList2 = immutableList2.Add(customer);

Console.WriteLine(immutableList2[0].Name);

customer.Name = "Changed Name";

Console.WriteLine(immutableList2[0].Name);


internal class Customer
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}