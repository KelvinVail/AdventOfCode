namespace AdventOfCode;

public class DumboOctopuses : Puzzle
{
    private readonly List<DumboOctopus> _octopuses = new ();
    private int _iteration;

    public DumboOctopuses(bool test = false)
        : base(11, test)
    {
        for (int row = 0; row < Input.Length; row++)
        {
            for (int column = 0; column < Input[0].Length; column++)
            {
                _octopuses.Add(
                    new DumboOctopus(
                        ToInt(Input[row][column].ToString()),
                        new Coordinate(row, column),
                        _octopuses));
            }
        }
    }

    public int TotalFlashes => _octopuses.Sum(x => x.FlashCount);

    public void Iterate()
    {
        _iteration++;
        foreach (var octopus in _octopuses)
            octopus.Charge(_iteration);
    }

    public int AllFlashOnIteration()
    {
        var lastFlashTotal = 0;
        int flashesThisIteration;
        do
        {
            Iterate();
            flashesThisIteration = TotalFlashes - lastFlashTotal;
            lastFlashTotal = TotalFlashes;
        } while (flashesThisIteration != 100);

        return _iteration;
    }
}