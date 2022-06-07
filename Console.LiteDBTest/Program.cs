//Sample for https://www.litedb.org/docs/getting-started/
using LiteDB;

const string dbName = "Test.db";
string currentDirectory = Directory.GetCurrentDirectory();
string dbPath = Path.Combine(currentDirectory, dbName);

using var db = new LiteDatabase(dbPath);

var collection = db.GetCollection<Customer>("customers");

var customers = collection.FindAll();

if(customers.Any() is false)
{
    var customer = new Customer
    {
        Name = "Test",
        Phones = new string[] { "222-222", "333-333" },
        IsActive = true,
    };

    collection.Insert(customer);

    customer.Name = "Test Updated";

    collection.Update(customer);
}

var response = System.Text.Json.JsonSerializer.Serialize(customers);
Console.WriteLine(response);

collection.EnsureIndex(x => x.Name);

 var results = collection.Query()
    .Where(x => x.Name.StartsWith("Test"))
    .OrderBy(x => x.Name)
    .Select(x => new { x.Name, NameUpper = x.Name.ToUpper() })
    .Limit(10)
    .ToList();

response = System.Text.Json.JsonSerializer.Serialize(results);
Console.WriteLine(response);

collection.EnsureIndex(x => x.Phones);

var phone = collection.FindOne(x => x.Phones.Contains("222-222"));

response = System.Text.Json.JsonSerializer.Serialize(phone);
Console.WriteLine(response);

internal class Customer
{
    public int Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string[] Phones { get; set; } = Array.Empty<string>();
    public bool IsActive { get; set; }
}