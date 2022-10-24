using Console.DebuggerAttributes;
using static System.Console;

var point1 = new Point(3, 4);
var point2 = new Point(5, 6);

WriteLine(point1.DistanceTo(point2));
ReadKey();