using System.Runtime.CompilerServices;
using AdventOfCode;

var sub = new Submarine();

// Day 03
Display(sub.Diagnostic.PowerConsumption);
Display(sub.Diagnostic.LifeSupport);

// Day 04
var bingo = new Bingo();
var winner = bingo.FindWinner();
Display(winner);
var loser = bingo.FindLoser();
Display(loser);

void Display<T>(T value, [CallerArgumentExpression("value")] string paramName = "") =>
    Console.WriteLine($"{paramName.Split('.').Last()}:{value}");
