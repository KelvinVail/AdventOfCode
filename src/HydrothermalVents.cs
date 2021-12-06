using System.Globalization;

namespace AdventOfCode;

internal class HydrothermalVents
{
    private readonly List<VentLine> _lines = new ();

    public HydrothermalVents(bool test = false)
    {
        var fileName = test ? "TestInput" : "Input";
        var input = File.ReadAllLines(@".\Input\2021\05\" + fileName + ".txt");
        foreach (var l in input)
        {
            var split = l.Split(' ');
            var c1 = split[0].Split(',');
            var c2 = split[2].Split(',');
            _lines.Add(
                new VentLine(
                    new Coordinate(ToInt(c1[0]), ToInt(c1[1])),
                    new Coordinate(ToInt(c2[0]), ToInt(c2[1]))));
        }
    }

    public int VentCount()
    {
        var allCoordinates = new List<Coordinate>();
        foreach (var c in _lines)
        {
            allCoordinates.AddRange(c.AllVents());
        }

        var dict = new Dictionary<Coordinate, int>();
        foreach (var coordinate in allCoordinates)
        {
            if (!dict.ContainsKey(coordinate))
                dict.Add(coordinate, 0);

            dict[coordinate]++;
        }

        return dict.Count(x => x.Value > 1);
    }

    private static int ToInt(string c) =>
        int.Parse(c, NumberStyles.Integer, new NumberFormatInfo());
}