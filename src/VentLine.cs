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

    public bool IsHorizontal => _start.Row == _end.Row;

    public bool IsVertical => _start.Column == _end.Column;

    public bool IsDiagonal => !IsHorizontal && !IsVertical;

    public List<Coordinate> AllVents()
    {
        var vents = new List<Coordinate>();
        if (IsHorizontal)
        {
            vents.Add(_start);
            var min = Math.Min(_start.Column, _end.Column);
            var max = Math.Max(_start.Column, _end.Column);
            var ventCount = max - min;
            for (int i = 0; i < ventCount - 1; i++)
            {
                vents.Add(new Coordinate(_start.Row, min + i + 1));
            }

            vents.Add(_end);
        }

        if (IsVertical)
        {
            vents.Add(_start);
            var min = Math.Min(_start.Row, _end.Row);
            var max = Math.Max(_start.Row, _end.Row);
            var ventCount = max - min;
            for (int i = 0; i < ventCount - 1; i++)
            {
                vents.Add(new Coordinate(min + i + 1, _start.Column));
            }

            vents.Add(_end);
        }

        if (IsDiagonal)
        {
            vents.Add(_start);
            var xDiff = _start.Row - _end.Row;
            var xIncrement = xDiff > 0 ? -1 : 1;
            var yDiff = _start.Column - _end.Column;
            var yIncrement = yDiff > 0 ? -1 : 1;
            var min = Math.Min(_start.Row, _end.Row);
            var max = Math.Max(_start.Row, _end.Row);
            var ventCount = max - min;
            for (int i = 0; i < ventCount - 1; i++)
            {
                var x = (i + 1) * xIncrement;
                var y = (i + 1) * yIncrement;
                vents.Add(new Coordinate(_start.Row + x, _start.Column + y));
            }

            vents.Add(_end);
        }

        return vents;
    }
}