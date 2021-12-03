namespace AdventOfCode;

public class Submarine
{
    public Submarine(bool test = false)
    {
        Diagnostic = new Diagnostic(test);
    }

    public Diagnostic Diagnostic { get; }
}