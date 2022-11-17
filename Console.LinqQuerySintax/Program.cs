using System.ComponentModel.Design;

var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("Test")
                .Options;

using var context = new DatabaseContext(options);
context.Database.EnsureCreated();

var datas = from saller in context.Sallers
            join sale in context.Sales on saller.Id equals sale.SallerId into sallesBySaller
            from sale in sallesBySaller.DefaultIfEmpty()
            select new
            {
                Saller = saller,
                ProductsSold = sale.Producs
            };

foreach (var data in datas)
{
    Console.WriteLine($"Saller: {data.Saller}");
    foreach (var product in data.ProductsSold)
    {
        Console.WriteLine($"    Product sold: {product}");
    }
    Console.WriteLine();
}

var sales =
    from sale in context.Sales
    let nextTwoMonths = DateTime.Now.AddMonths(2)
    where sale.Date > nextTwoMonths
    select new { sale.Id, sale.Date, Total = sale.Producs!.Sum(p => p.Value), Sallle = sale.Saller!.Name };

foreach (var sale in sales)
{
    Console.WriteLine(
    $"""
    Sale: {sale.Id},
    Date: {sale.Date:s},
    Total: ¢ {sale.Total},
    Saller: {sale.Sallle}
    """);
    Console.WriteLine();
}