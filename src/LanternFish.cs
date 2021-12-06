namespace AdventOfCode;

internal class LanternFish
{
    private int _internalTimer;

    public LanternFish(int internalTimer) =>
        _internalTimer = internalTimer;

    public bool CanCreate() => _internalTimer == 0;

    public LanternFish Create()
    {
        if (CanCreate())
        {
            _internalTimer = 6;
            return new LanternFish(8);
        }

        return default;
    }

    public void Increment() =>
        _internalTimer--;

    public override string ToString() => $"{_internalTimer}";
}