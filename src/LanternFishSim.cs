using System.Globalization;

namespace AdventOfCode;

internal class LanternFishSim
{
    private Dictionary<int, long> _fishes = new ();

    public LanternFishSim(bool test = false)
    {
        var fileName = test ? "TestInput" : "Input";
        var input = File.ReadAllLines(@".\Input\2021\06\" + fileName + ".txt")[0].Split(',');
        foreach (var s in input)
        {
            if (!_fishes.ContainsKey(ToInt(s)))
                _fishes.Add(ToInt(s), 0);

            _fishes[ToInt(s)]++;
        }
    }

    public void NextDay()
    {
        var nextGen = new Dictionary<int, long>();
        for (int i = 0; i < 9; i++)
        {
            nextGen.Add(i, 0);
        }

        foreach (var fish in _fishes)
        {
            if (fish.Key == 0)
            {
                nextGen[6] += fish.Value;
                nextGen[8] += fish.Value;
            }
            else
            {
                nextGen[fish.Key - 1] += fish.Value;
            }
        }

        _fishes = nextGen;
    }

    public void GoToDay(int day)
    {
        for (int i = 0; i < day; i++)
            NextDay();
    }

    public long Fishes => _fishes.Sum(x => x.Value);

    private static int ToInt(string c) =>
        int.Parse(c, NumberStyles.Integer, new NumberFormatInfo());
}