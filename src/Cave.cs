namespace AdventOfCode;

public class Cave
{
    private readonly bool _isSmall = true;
    private readonly HashSet<Cave> _connected = new ();
    private readonly HashSet<string> _completed = new ();
    private int _visited;

    public Cave(string id)
    {
        Id = id;
        if (id.Equals(id.ToUpperInvariant(), StringComparison.Ordinal))
            _isSmall = false;
    }

    public string Id { get; }

    public bool CanVisit => !_isSmall || _visited == 0;

    public IReadOnlyList<Cave> ConnectedCaves =>
        _connected.Where(x => x.CanVisit).OrderBy(x => x.Id).ToList();

    public void Visit()
    {
        if (!CanVisit)
        {
            throw new InvalidOperationException(
                $"Small cave {Id} has already been visited.");
        }

        _visited++;
    }

    public void Connect(Cave cave)
    {
        _connected.Add(cave);
        if (!cave.ConnectedCaves.Contains(this))
            cave.Connect(this);
    }

    public int TotalRoutes(Cave end)
    {
        var random = new Random(77);
        for (int i = 0; i < 10000000; i++)
            RandomRoute(end, random);

        return _completed.Count(x => x.EndsWith(end.Id));
    }

    private string PrintCave(Cave cave, int level)
    {
        var s = cave.Id;
        foreach (var c in ConnectedCaves)
        {
            s += PrintCave(c, level + 1);
        }

        return s;
    }

    public override string ToString() => Id;

    private void RandomRoute(Cave end, Random random)
    {
        ResetCaves();
        var current = this;
        var route = new List<Cave>();

        current.Visit();
        route.Add(current);

        do
        {
            var caves = current.ConnectedCaves.Count;
            if (caves == 0) break;

            int next = random.Next(caves);
            current = current.ConnectedCaves[next];
            if (current != null)
            {
                current.Visit();
                route.Add(current);
            }
        }
        while (current != null && current != end);

        _completed.Add(string.Join(',', route));
    }

    private void ResetCaves()
    {
        _visited = 0;
        foreach (var cave in _connected)
        {
            if (cave._visited > 0)
                cave.ResetCaves();
        }
    }
}