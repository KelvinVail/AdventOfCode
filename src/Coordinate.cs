namespace AdventOfCode;

public class Coordinate : IEquatable<Coordinate>
{
    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }

    public int Column { get; }

    public Coordinate North() =>
        new (Row - 1, Column);

    public Coordinate NorthEast() =>
        new (Row - 1, Column + 1);

    public Coordinate East() =>
        new (Row, Column + 1);

    public Coordinate SouthEast() =>
        new (Row + 1, Column + 1);

    public Coordinate South() =>
        new (Row + 1, Column);

    public Coordinate SouthWest() =>
        new (Row + 1, Column - 1);

    public Coordinate West() =>
        new (Row, Column - 1);

    public Coordinate NorthWest() =>
        new (Row - 1, Column - 1);

    public bool Equals(Coordinate? other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Row == other.Row && Column == other.Column;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != this.GetType())
        {
            return false;
        }

        return Equals((Coordinate)obj);
    }

    public override int GetHashCode() => HashCode.Combine(Row, Column);

    public override string ToString() => $"{Row},{Column}";
}