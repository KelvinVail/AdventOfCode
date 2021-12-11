namespace AdventOfCode;

public class DumboOctopus
{
    private readonly Coordinate _pos;
    private int _energy;
    private readonly List<DumboOctopus> _octopuses;
    private int _flashedOnIteration = -1;

    public DumboOctopus(
        int energy,
        Coordinate pos = null,
        List<DumboOctopus> octopuses = null)
    {
        _pos = pos ?? new Coordinate(0, 0);
        _octopuses = octopuses ?? new List<DumboOctopus>();

        _energy = energy;
        if (energy == 10) Flash(0);
    }

    public int FlashCount { get; private set; }

    public void Charge(int iteration = 0)
    {
        if (!Flashed(iteration))
            _energy++;

        if (Charged() && !Flashed(iteration))
            Flash(iteration);
    }

    private bool Flashed(int iteration) => iteration == _flashedOnIteration;

    private bool Charged() => _energy > 9;

    private void Flash(int iteration)
    {
        FlashCount++;
        _flashedOnIteration = iteration;
        _energy = 0;
        ChargeNeighbors(iteration);
    }

    private void ChargeNeighbors(int iteration)
    {
        Charge(_pos.North(), iteration);
        Charge(_pos.NorthEast(), iteration);
        Charge(_pos.East(), iteration);
        Charge(_pos.SouthEast(), iteration);
        Charge(_pos.South(), iteration);
        Charge(_pos.SouthWest(), iteration);
        Charge(_pos.West(), iteration);
        Charge(_pos.NorthWest(), iteration);
    }

    private void Charge(Coordinate pos, int iteration) =>
        _octopuses.FirstOrDefault(x => x._pos.Equals(pos))?.Charge(iteration);
}