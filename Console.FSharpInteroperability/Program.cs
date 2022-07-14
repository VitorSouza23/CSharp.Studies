using FSharpCalculations;

var vcl = new Attribute(0.987, Calculations.Quality.Good);
var refDensity = new Attribute(15.0, Calculations.Quality.Uncertain);

var density = new Attribute(Calculations.density(refDensity.Value, vcl.Value), Calculations.quality(refDensity.Quality, vcl.Quality));

Console.WriteLine(density);

internal record Attribute(double Value, Calculations.Quality Quality);
