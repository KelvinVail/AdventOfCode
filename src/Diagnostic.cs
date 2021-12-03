using System.Globalization;

namespace AdventOfCode;

public class Diagnostic
{
    private readonly string[] _diagnosticReport;

    public Diagnostic(bool test = false)
    {
        var fileName = test ? "TestInput" : "Input";
        _diagnosticReport = File.ReadAllLines(@".\Input\2021\03\" + fileName + ".txt");
    }

    public int PowerConsumption => Gamma() * Epsilon();

    public int LifeSupport => OxygenGenerator * Co2Scrubber;

    private int OxygenGenerator => ToInt(FilterByMostCommon(_diagnosticReport));

    private int Co2Scrubber => ToInt(FilterByLeastCommon(_diagnosticReport));

    private static string FilterByMostCommon(string[] lines, int pos = 0)
    {
        lines = lines.Where(x => ToInt(x[pos]) == MostCommon(lines, pos)).ToArray();
        return lines.Length == 1 ? lines[0] : FilterByMostCommon(lines, pos + 1);
    }

    private static string FilterByLeastCommon(string[] lines, int pos = 0)
    {
        lines = lines.Where(x => ToInt(x[pos]) == LeastCommon(lines, pos)).ToArray();
        return lines.Length == 1 ? lines[0] : FilterByLeastCommon(lines, pos + 1);
    }

    private static int LeastCommon(IReadOnlyCollection<string> lines, int pos) =>
        MostCommon(lines, pos) == 1 ? 0 : 1;

    private static int MostCommon(IReadOnlyCollection<string> lines, int pos) =>
        (int)Math.Round(lines.Aggregate(0m, (c, l) => c + ToInt(l[pos])) / lines.Count, MidpointRounding.AwayFromZero);

    private static int ToInt(char c) =>
        int.Parse(c.ToString(), NumberStyles.Integer, new NumberFormatInfo());

    private static int ToInt(string s) =>
        Convert.ToInt32(s, 2);

    private int Gamma()
    {
        var gamma = string.Empty;
        for (int i = 0; i < _diagnosticReport[0].Length; i++)
            gamma += MostCommon(_diagnosticReport, i);

        return ToInt(gamma);
    }

    private int Epsilon()
    {
        var epsilon = string.Empty;
        for (int i = 0; i < _diagnosticReport[0].Length; i++)
            epsilon += LeastCommon(_diagnosticReport, i);

        return ToInt(epsilon);
    }
}