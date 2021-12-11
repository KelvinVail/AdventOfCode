using System.Runtime.CompilerServices;
using AdventOfCode;

var sub = new Submarine();

// Day 03
//Display(sub.Diagnostic.PowerConsumption);
//Display(sub.Diagnostic.LifeSupport);

// Day 04
//var bingo = new Bingo();
//var winner = bingo.FindWinner();
//Display(winner);
//var loser = bingo.FindLoser();
//Display(loser);

//var vents = new HydrothermalVents();
//Display(vents.VentCount());

//var fishes = new LanternFishSim();
//fishes.GoToDay(256);
//Display(fishes.Fishes);

//var displays = new SevenSegmentDisplays();
//Display(displays.DisplayTotal());

//var heightMap = new HeightMap();
//Display(heightMap.SumOfLowPoints());
//Display(heightMap.LargestBasinSizes());

//var syntaxChecker = new SyntaxChecker();
//Display(syntaxChecker.Score());
//Display(syntaxChecker.GetMiddleScore());

var dumbos = new DumboOctopuses();
for (int i = 0; i < 100; i++)
    dumbos.Iterate();
Display(dumbos.TotalFlashes);
Display(dumbos.AllFlashOnIteration());

void Display<T>(T value, [CallerArgumentExpression("value")] string paramName = "") =>
    Console.WriteLine($"{paramName.Split('.').Last()}:{value}");
