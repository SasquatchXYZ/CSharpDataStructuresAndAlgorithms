using System.Diagnostics;
using FibonacciSeries;

var timer = Stopwatch.StartNew();
var n = 50;
var result = Fibonacci.SimpleRecursiveFibonacci(n);
timer.Stop();
Console.WriteLine($"{n}: {result} - {timer.ElapsedMilliseconds} ms.");

timer.Restart();
var bottomUp = Fibonacci.BottomUpFibonacci(n);
timer.Stop();
Console.WriteLine($"{n}: {bottomUp} - {timer.ElapsedMilliseconds} ms.");
