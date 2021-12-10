using System.Globalization;

namespace AdventOfCode;

public abstract class Puzzle
{
    protected Puzzle(int day, bool test = false)
    {
        var fileName = test ? "TestInput" : "Input";
        Input = File.ReadAllLines(@".\Input\2021\" + day.ToString("00", new NumberFormatInfo()) + @"\" + fileName + ".txt");
    }

    protected string[] Input { get; }

    protected static int ToInt(string c) =>
        int.Parse(c, NumberStyles.Integer, new NumberFormatInfo());
}