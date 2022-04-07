using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using static LinqQuerySintax.Model;

namespace LinqQuerySintax;

public class DatabaseContext : DbContext
{
    public DatabaseContext([NotNull] DbContextOptions options) : base(options)
    {
    }

    public DbSet<Saller> Sallers { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        int productsCount = 100, salesCount = 100, sallersCount = 100;
        var sallers = new Saller[sallersCount];
        var sales = new Sale[salesCount];
        var products = new Product[productsCount];
        var random = new Random();

        for (int index = 0; index < sallersCount; index++)
        {
            sallers[index] = new Saller
            {
                BirthDate = DateTime.Now.AddDays(index),
                CPF = $"XXXXXXXXXX{index}",
                Id = Guid.NewGuid(),
                Name = $"Saller {index + 1}",
            };
        }

        for (int index = 0; index < salesCount; index++)
        {
            sales[index] = new Sale
            {
                Date = DateTime.Now.AddDays(index),
                Id = Guid.NewGuid(),
                SallerId = sallers[random.Next(sallersCount)].Id,
            };
        }

        for (int index = 0; index < productsCount; index++)
        {
            products[index] = new Product
            {
                Id = Guid.NewGuid(),
                Name = $"Product {index + 1}",
                SaleId = sales[random.Next(salesCount)].Id,
                Value = (decimal)Math.Round(random.NextDouble() * (index + 1), 2)
            };
        }

        modelBuilder.Entity<Saller>()
            .HasData(sallers);
        modelBuilder.Entity<Sale>()
            .HasData(sales);
        modelBuilder.Entity<Product>()
            .HasData(products);

        base.OnModelCreating(modelBuilder);
    }
}
