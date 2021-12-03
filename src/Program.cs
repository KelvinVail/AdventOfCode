using System.Runtime.CompilerServices;
using AdventOfCode;

var sub = new Submarine();

Display(sub.Diagnostic.PowerConsumption);
Display(sub.Diagnostic.LifeSupport);

void Display<T>(T value, [CallerArgumentExpression("value")] string paramName = "") =>
    Console.WriteLine($"{paramName.Split('.').Last()}:{value}");
