using System.Diagnostics;
using Console.EverithingAwaitable;

using static System.Console;

Stopwatch sw = Stopwatch.StartNew();

await Delay.Seconds(3);

WriteLine(sw.ElapsedMilliseconds);


