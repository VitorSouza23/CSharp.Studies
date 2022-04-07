using LinqQuerySintax;
using Microsoft.EntityFrameworkCore;

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
        Console.WriteLine($"Product sold: {product}");
    }
}
