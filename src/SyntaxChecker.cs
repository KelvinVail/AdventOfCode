namespace AdventOfCode;

public class SyntaxChecker : Puzzle
{
    private readonly char[] _openers = { '(', '[', '{', '<' };
    private readonly Dictionary<char, char> _getOpener = new ()
    {
        { ')', '(' },
        { ']', '[' },
        { '}', '{' },
        { '>', '<' },
    };

    private readonly Dictionary<char, char> _getCloser = new ()
    {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' },
        { '<', '>' },
    };

    private readonly Dictionary<char, int> _scores = new ()
    {
        { ')', 3 },
        { ']', 57 },
        { '}', 1197 },
        { '>', 25137 },
    };

    public SyntaxChecker(bool test = false)
        : base(10, test)
    {
    }

    public char FirstCorruptedCloser(string s)
    {
        var open = new List<char>();

        foreach (var c in s)
        {
            if (_openers.Contains(c))
            {
                open.Add(c);
            }
            else
            {
                var lastOpen = open.Last();
                if (_getOpener[c] != lastOpen)
                    return c;

                open.RemoveAt(open.Count - 1);
            }
        }

        return default;
    }

    public int Score(string input)
    {
        var total = 0;
        foreach (var c in input)
        {
            total += _scores[c];
        }

        return total;
    }

    public int Score()
    {
        var corrupt = string.Empty;
        foreach (var line in Input)
        {
            var output = FirstCorruptedCloser(line);
            if (output != '\0')
                corrupt += output;
        }

        return Score(corrupt);
    }

    public string Complete(string input)
    {
        var open = new List<char>();

        foreach (var c in input)
        {
            if (_openers.Contains(c))
            {
                open.Add(c);
            }
            else
            {
                var lastOpen = open.Last();
                if (_getOpener[c] == lastOpen)
                    open.RemoveAt(open.Count - 1);
            }
        }

        var output = string.Empty;
        foreach (var c in open)
            output = _getCloser[c] + output;

        return output;
    }

    public long ScoreCompletedLine(string input)
    {
        var points = new Dictionary<char, long>
        {
            { ')', 1 },
            { ']', 2 },
            { '}', 3 },
            { '>', 4 },
        };

        long score = 0;
        foreach (var c in input)
        {
            score = (score * 5) + points[c];
        }

        return score;
    }

    public long GetMiddleScore()
    {
        var scores = new List<long>();

        foreach (var line in Input)
        {
            if (FirstCorruptedCloser(line) != '\0') continue;
            scores.Add(ScoreCompletedLine(Complete(line)));
        }

        scores.Sort();

        return scores[scores.Count / 2];
    }
}