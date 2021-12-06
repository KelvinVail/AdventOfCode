namespace AdventOfCode;

internal class VentLine
{
    private readonly Coordinate _start;
    private readonly Coordinate _end;

    public VentLine(Coordinate start, Coordinate end)
    {
        _start = start;
        _end = end;
    }

    public bool IsHorizontal => _start.X == _end.X;

    public bool IsVertical => _start.Y == _end.Y;

    public bool IsDiagonal => !IsHorizontal && !IsVertical;

    public List<Coordinate> AllVents()
    {
        var vents = new List<Coordinate>();
        if (IsHorizontal)
        {
            vents.Add(_start);
            var min = Math.Min(_start.Y, _end.Y);
            var max = Math.Max(_start.Y, _end.Y);
            var ventCount = max - min;
            for (int i = 0; i < ventCount - 1; i++)
            {
                vents.Add(new Coordinate(_start.X, min + i + 1));
            }

            vents.Add(_end);
        }

        if (IsVertical)
        {
            vents.Add(_start);
            var min = Math.Min(_start.X, _end.X);
            var max = Math.Max(_start.X, _end.X);
            var ventCount = max - min;
            for (int i = 0; i < ventCount - 1; i++)
            {
                vents.Add(new Coordinate(min + i + 1, _start.Y));
            }

            vents.Add(_end);
        }

        if (IsDiagonal)
        {
            vents.Add(_start);
            var xDiff = _start.X - _end.X;
            var xIncrement = xDiff > 0 ? -1 : 1;
            var yDiff = _start.Y - _end.Y;
            var yIncrement = yDiff > 0 ? -1 : 1;
            var min = Math.Min(_start.X, _end.X);
            var max = Math.Max(_start.X, _end.X);
            var ventCount = max - min;
            for (int i = 0; i < ventCount - 1; i++)
            {
                var x = (i + 1) * xIncrement;
                var y = (i + 1) * yIncrement;
                vents.Add(new Coordinate(_start.X + x, _start.Y + y));
            }

            vents.Add(_end);
        }

        return vents;
    }
}