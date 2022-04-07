namespace LinqQuerySintax;

public class Model
{
    public class Saller
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string? CPF { get; set; }
        public virtual ICollection<Sale>? Sales { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} - Name: {Name} - Birth Date: {BirthDate:yyyy/MM/dd} - CPF: {CPF}";
        }
    }

    public class Sale
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid SallerId { get; set; }
        public virtual Saller? Saller { get; set; }
        public virtual ICollection<Product>? Producs { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} - Date: {Date:yyyy/MM/dd} - Saler Id: {SallerId}";
        }
    }

    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Value { get; set; }
        public Guid? SaleId { get; set; }
        public virtual Sale? Sale { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} - Name: {Name} - Value: ¢ {Value}";
        }
    }
}
