namespace AdventOfCode;

internal class BingoBoard
{
    private readonly List<Number> _numbers = new ();
    private int _rowCount = 0;

    public void AddRow(List<int> row)
    {
        _rowCount++;
        for (int i = 0; i < row.Count; i++)
            _numbers.Add(new Number(_rowCount, i, row[i]));
    }

    public void NumberCalled(int number)
    {
        foreach (var n in _numbers)
            n.NumberCalled(number);
    }

    public bool Winner()
    {
        for (int i = 0; i < 5; i++)
        {
            if (_numbers.Count(x => x.Row == i && x.HasBeenCalled) == 5)
                return true;
        }

        for (int i = 0; i < 5; i++)
        {
            if (_numbers.Count(x => x.Column == i && x.HasBeenCalled) == 5)
                return true;
        }

        return false;
    }

    public bool IsWinner => Winner();

    public int SumOfUnmarked =>
        _numbers.Where(x => !x.HasBeenCalled).Sum(x => x.Value);

    private class Number
    {
        public Number(int row, int column, int value)
        {
            Row = row;
            Column = column;
            Value = value;
        }

        public int Row { get; }

        public int Column { get; }

        public int Value { get; }

        public bool HasBeenCalled { get; private set; }

        public void NumberCalled(int number)
        {
            if (Value == number) HasBeenCalled = true;
        }
    }
}