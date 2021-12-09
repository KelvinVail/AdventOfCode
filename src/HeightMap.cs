using System.ComponentModel;

namespace AdventOfCode;

internal class HeightMap : Puzzle
{
    public HeightMap(bool test = false)
        : base(9, test)
    {
    }

    public int SumOfLowPoints()
    {
        var total = 0;
        for (int c = 0; c < Input[0].Length; c++)
        {
            for (int r = 0; r < Input.Length; r++)
            {
                var current = ToInt(Input[r][c].ToString());
                var up = r == 0 ? 10 : ToInt(Input[r - 1][c].ToString());
                if (current >= up) continue;

                var down = r == Input.Length - 1 ? 10 : ToInt(Input[r + 1][c].ToString());
                if (current >= down) continue;

                var left = c == 0 ? 10 : ToInt(Input[r][c - 1].ToString());
                if (current >= left) continue;

                var right = c == Input[0].Length - 1 ? 10 : ToInt(Input[r][c + 1].ToString());
                if (current >= right) continue;

                total += 1 + current;
            }
        }

        return total;
    }

    public int LargestBasinSizes()
    {
        var basins = new List<Basin>();

        var columnCount = Input[0].Length;
        for (int row = 0; row < Input.Length; row++)
        {
            for (int column = 0; column < columnCount; column++)
            {
                if (CellValue(row, column) == 9) continue;
                var firstCell = new Coordinate(row, column);
                while (column < columnCount && CellValue(row, column) != 9)
                {
                    column++;
                    var x = column < columnCount;
                }

                column--;

                var strip = new Strip(firstCell, new Coordinate(row, column));

                if (!basins.Any())
                    basins.Add(new Basin(strip));

                var added = false;
                foreach (var basin in basins)
                {
                    if (strip.Id == basin.Id)
                    {
                        added = true;
                        break;
                    }
                    var belongs = basin.Add(strip);
                    added = belongs;
                    if (belongs) break;
                }

                if (!added) basins.Add(new Basin(strip));
            }
        }

        var topThree = basins.OrderBy(x => x.Size).TakeLast(3);

        var prod = 1;
        foreach (var b in topThree)
        {
            prod *= b.Size;
        }

        return prod;
    }

    private int CellValue(int r, int c)
    {
        return ToInt(Input[r][c].ToString());
    }

    private class Strip
    {
        private readonly Coordinate _start;
        private readonly Coordinate _end;

        public Strip(Coordinate start, Coordinate end)
        {
            if (start.Row != end.Row) throw new ArgumentException("Coordinates must be on the same row.");
            Id = start;
            _start = start;
            _end = end;
        }

        public Coordinate Id { get; }

        public int Size => _end.Column - _start.Column + 1;

        public bool Touches(Strip strip)
        {
            if (strip._start.Row + 1 != _start.Row) return false;

            for (int i = strip._start.Column; i <= strip._end.Column; i++)
            {
                if (i >= _start.Column && i <= _end.Column) return true;
            }

            return false;
        }
    }

    private class Basin
    {
        private List<Strip> _strips = new ();

        public Basin(Strip firstStrip)
        {
            Id = firstStrip.Id;
            _strips.Add(firstStrip);
        }

        public Coordinate Id { get; }

        public int Size => _strips.Sum(x => x.Size);

        public bool Add(Strip strip)
        {
            var allStripsOnRowAbove = _strips.Where(x => x.Id.Row == strip.Id.Row - 1);
            foreach (var s in allStripsOnRowAbove)
            {
                if (strip.Touches(s))
                {
                    _strips.Add(strip);
                    return true;
                }
            }

            return false;
        }
    }

}