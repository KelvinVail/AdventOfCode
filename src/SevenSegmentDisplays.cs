namespace AdventOfCode;

internal class SevenSegmentDisplays : Puzzle
{
    private readonly SevenSegmentDisplay _display = new ();

    public SevenSegmentDisplays(bool test = false)
        : base(8, test)
    {
    }

    public int DisplayTotal()
    {
        var runningTotal = 0;

        foreach (var line in Input)
        {
            var split = line.Split('|');
            _display.SetSignals(split[0]);
            var total = _display.Decode(split[1]);
            runningTotal += total;
        }

        return runningTotal;
    }
}