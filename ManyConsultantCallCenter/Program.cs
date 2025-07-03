using ManyConsultantCallCenter;

var center = new CallCenter();
var ops = new Operations();
Parallel.Invoke(
    () => ops.Clients(center),
    () => ops.Consultant(center, "Marcin", ConsoleColor.Red),
    () => ops.Consultant(center, "James", ConsoleColor.Yellow),
    () => ops.Consultant(center, "Olivia", ConsoleColor.Green));
