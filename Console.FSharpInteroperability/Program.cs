using FSharpCalculations;
using Microsoft.FSharp.Core;

var vcl = new Calculations.Attribute(0.987, Calculations.Quality.Good);
var refDensity = new Calculations.Attribute(15.0, Calculations.Quality.Uncertain);

var density = Calculations.calculateAttribute(refDensity, vcl, FuncConvert.FromFunc<double, double, double>((x, y) => Calculations.density(x, y)));

Console.WriteLine(density);