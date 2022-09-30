using Console.DateTimeOffsetTest;
using static System.Console;

IProcessDateTimeService process = new ProcessDateTimeService(new DateTimeOffsetProvider());

WriteLine(process.GetNowPeriodName());