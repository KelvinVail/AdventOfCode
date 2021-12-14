namespace AdventOfCode;

public class PolymerInserter : Puzzle
{
    private readonly Dictionary<string, char> _templates = new ();

    public PolymerInserter(bool test = false)
        : base(14, test)
    {
        for (int i = 2; i < Input.Length; i++)
            AddTemplate(Input[i]);
    }

    public string InitialInput => Input[0];

    public void Clear() => _templates.Clear();

    public void AddTemplate(string template)
    {
        var split = template.Split(" -> ");
        if(!_templates.ContainsKey(split[0]))
            _templates.Add(split[0], char.Parse(split[1]));
    }

    public string Insert(string input)
    {
        var output = string.Empty;
        for (long i = 0; i < input.Length - 1; i++)
        {
            if (!string.IsNullOrEmpty(output))
                output = output.Remove(output.Length - 1);
        }

        return output;
    }

    public long Insert(int steps)
    {
        var moleculeCount = CutPolymer();

        for (var i = 0; i < steps; i++)
        {
            var updated = new Dictionary<string, long>();
            foreach (var (molecule, count) in moleculeCount)
            {
                var (a, n, b) = (molecule[0], _templates[molecule], molecule[1]);
                updated[$"{a}{n}"] = updated.GetValueOrDefault($"{a}{n}") + count;
                updated[$"{n}{b}"] = updated.GetValueOrDefault($"{n}{b}") + count;
            }

            moleculeCount = updated;
        }

        var elementCounts = new Dictionary<char, long>();
        foreach (var (molecule, count) in moleculeCount) {
            var a = molecule[0];
            elementCounts[a] = elementCounts.GetValueOrDefault(a) + count;
        }

        elementCounts[Input[0].Last()]++;

        return elementCounts.Values.Max() - elementCounts.Values.Min();
    }

    private Dictionary<string, long> CutPolymer()
    {
        var moleculeCount = new Dictionary<string, long>();
        foreach (var i in Enumerable.Range(0, Input[0].Length - 1))
        {
            var ab = Input[0].Substring(i, 2);
            moleculeCount[ab] = moleculeCount.GetValueOrDefault(ab) + 1;
        }

        return moleculeCount;
    }

    public int Score(string input)
    {
        var most = input.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
        var least = input.GroupBy(x => x).OrderByDescending(x => x.Count()).Last().Key;

        var mostCount = input.Count(x => x == most);
        var leastCount = input.Count(x => x == least);

        return mostCount - leastCount;
    }

    private string ProcessTwoChars(string input)
    {
        if (!_templates.ContainsKey(input)) return input;
        var sequence = input.ToList();
        sequence.Insert(1, _templates[input]);
        return string.Join(string.Empty, sequence);
    }
}