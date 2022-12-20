int i = 0;

repeat:
if (i < 10)
{
    i++;
    goto repeat;
}

Console.WriteLine(i);

Console.WriteLine(CalculatePrice(CoffeeChoice.Plain));
Console.WriteLine(CalculatePrice(CoffeeChoice.WithMilk));
Console.WriteLine(CalculatePrice(CoffeeChoice.WithIceCream));

static decimal CalculatePrice(CoffeeChoice choice)
{
    decimal price = 0;
    switch (choice)
    {
        case CoffeeChoice.Plain:
            price += 10.0m;
            break;

        case CoffeeChoice.WithMilk:
            price += 5.0m;
            goto case CoffeeChoice.Plain;

        case CoffeeChoice.WithIceCream:
            price += 7.0m;
            goto case CoffeeChoice.Plain;
    }

    return price;
}

enum CoffeeChoice
{
    Plain,
    WithMilk,
    WithIceCream
}