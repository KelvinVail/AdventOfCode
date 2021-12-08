namespace AdventOfCode;

public class SevenSegmentDisplay
{
    private List<string> _signals;
    private string _input;

    public void SetSignals(string signals)
    {
        _input = signals;
        _signals = signals.Split(' ').ToList();
    }

    public int Decode(string input)
    {
        if (input is null) return -1;

        var result = string.Empty;
        foreach (var s in input.Split(' '))
        {
            result += GetDigit(s);
        }

        return int.Parse(result);
    }

    private string GetDigit(string input)
    {
        if (input.Length == 2) return "1";
        if (input.Length == 4) return "4";
        if (input.Length == 3) return "7";
        if (input.Length == 7) return "8";
        if (IsTwo(input)) return "2";
        if (IsThree(input)) return "3";
        if (IsFive(input)) return "5";
        if (IsSix(input)) return "6";
        if (IsNine(input)) return "9";
        return "0";
    }

    private bool IsTwo(string input)
    {
        if (input.Length == 5 && ContainsE(input))
            return true;

        return false;
    }

    private bool IsThree(string input)
    {
        if (input.Length == 5 && ContainsC(input) && ContainsF(input))
            return true;

        return false;
    }

    private bool IsFive(string input)
    {
        if (input.Length == 5 && ContainsB(input))
            return true;

        return false;
    }

    private bool IsSix(string input)
    {
        if (input.Length == 6 && ContainsE(input) && !ContainsC(input))
            return true;

        return false;
    }

    private bool IsNine(string input)
    {
        if (input.Length == 6 && !ContainsE(input))
            return true;

        return false;
    }

    private bool HasSameSegmentsAsOne(string input)
    {
        var one = _signals.FirstOrDefault(x => x.Length == 2);
        if (
            one != null
            && input.Contains(one[0], StringComparison.InvariantCultureIgnoreCase)
            && input.Contains(one[1], StringComparison.InvariantCultureIgnoreCase))
        {
            return true;
        }

        return false;
    }

    private bool HasOneSegmentFromOne(string input)
    {
        var one = _signals.FirstOrDefault(x => x.Length == 2);
        if (
            one != null
            && (input.Contains(one[0], StringComparison.InvariantCultureIgnoreCase)
            || input.Contains(one[1], StringComparison.InvariantCultureIgnoreCase)))
        {
            return true;
        }

        return false;
    }

    private bool ContainsB(string input)
    {
        foreach (var c in input)
        {
            if (_input.Count(x => x == c) == 6)
                return true;
        }

        return false;
    }

    private bool ContainsC(string input)
    {
        foreach (var c in input)
        {
            var one = _signals.First(x => x.Length == 2);
            if (_input.Count(x => x == c) == 8 && one.Contains(c))
                return true;
        }

        return false;
    }

    private bool ContainsE(string input)
    {
        foreach (var c in input)
        {
            if (_input.Count(x => x == c) == 4)
                return true;
        }

        return false;
    }

    private bool ContainsF(string input)
    {
        foreach (var c in input)
        {
            if (_input.Count(x => x == c) == 9)
                return true;
        }

        return false;
    }
}