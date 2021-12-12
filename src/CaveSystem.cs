using System.Collections.Immutable;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode;

public class CaveSystem : Puzzle
{
    private bool _part2 = true;

    public CaveSystem(bool test = false)
        : base(12, test)
    {
    }

    public int TotalRoutes()
    {
        //return PathCount("start", ImmutableHashSet.Create<string>("start"), false);
        return Paths(GetCave("start"), ImmutableHashSet.Create<string>("start"));
    }

    // Recursive approach this time.
    public int PathCount(string currentCave, ImmutableHashSet<string> visitedCaves, bool anySmallCaveWasVisitedTwice) {
        var map = GetMap();

        if (currentCave == "end")
        {
            return 1;
        }

        var res = 0;
        foreach (var cave in map[currentCave])
        {
            var isBigCave = cave.ToUpper() == cave;
            var seen = visitedCaves.Contains(cave);

            if (!seen || isBigCave) {
                // we can visit big caves any number of times, small caves only once
                res += PathCount(cave, visitedCaves.Add(cave), anySmallCaveWasVisitedTwice);
            }
            else if (_part2 && !isBigCave && cave != "start" && !anySmallCaveWasVisitedTwice)
            {
                // part 2 also lets us to visit a single small cave twice (except for start and end)
                res += PathCount(cave, visitedCaves, true);
            }
        }

        return res;
    }

    public int Paths(Cave current, ImmutableHashSet<string> visitedIds)
    {
        if (current.Id == "end") return 1;
        if (!current.CanVisit) return 0;

        var newCave = GetCave(current.Id);
        newCave.Visit();
        foreach (var id in visitedIds)
            newCave.ConnectedCaves.FirstOrDefault(x => x.Id == id)?.Visit();

        var count = 0;
        foreach (var cave in newCave.ConnectedCaves)
        {
            count += Paths(cave, visitedIds.Add(cave.Id));
        }

        return count;
    }

    public Cave GetCave(string id)
    {
        var caves = new List<Cave>();
        foreach (var line in Input)
        {
            var ids = line.Split('-');
            if (caves.All(x => x.Id != ids[0]))
                caves.Add(new Cave(ids[0]));
            if (caves.All(x => x.Id != ids[1]))
                caves.Add(new Cave(ids[1]));

            var cave1 = caves.First(x => x.Id == ids[0]);
            var cave2 = caves.First(x => x.Id == ids[1]);
            cave1.Connect(cave2);
        }

        return caves.First(x => x.Id == id);
    }

    public Dictionary<string, string[]> GetMap()
    {
        // taking all connections 'there and back':
        var connections =
            from line in Input
            let parts = line.Split("-")
            let caveA = parts[0]
            let caveB = parts[1]
            from connection in new[] { (From: caveA, To: caveB), (From: caveB, To: caveA) }
            select connection;

        // grouped by "from":
        return (
            from p in connections
            group p by p.From into g
            select g
        ).ToDictionary(g => g.Key, g => g.Select(connnection => connnection.To).ToArray());
    }
}