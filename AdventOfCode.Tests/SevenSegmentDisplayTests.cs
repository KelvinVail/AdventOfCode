using Xunit;

namespace AdventOfCode.Tests;

public class SevenSegmentDisplayTests
{
    private string _signals = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab";
    private SevenSegmentDisplay _display = new ();

    public SevenSegmentDisplayTests() =>
        _display.SetSignals(_signals);

    [Fact]
    public void CanDecodeOne()
    {
        var output = _display.Decode("ab");

        Assert.Equal(1, output);
    }

    [Fact]
    public void CanDecodeFour()
    {
        var output = _display.Decode("eafb");

        Assert.Equal(4, output);
    }

    [Fact]
    public void CanDecodeSeven()
    {
        var output = _display.Decode("dab");

        Assert.Equal(7, output);
    }

    [Fact]
    public void CanDecodeEight()
    {
        var output = _display.Decode("acedgfb");

        Assert.Equal(8, output);
    }

    [Fact]
    public void CanDecodeTwo()
    {
        var output = _display.Decode("gcdfa");

        Assert.Equal(2, output);
    }

    [Fact]
    public void CanDecodeThree()
    {
        var output = _display.Decode("fbcad");

        Assert.Equal(3, output);
    }

    [Fact]
    public void CanDecodeFive()
    {
        var output = _display.Decode("cdfbe");

        Assert.Equal(5, output);
    }

    [Fact]
    public void CanDecodeSix()
    {
        var output = _display.Decode("cdfgeb");

        Assert.Equal(6, output);
    }

    [Fact]
    public void CanDecodeNine()
    {
        var output = _display.Decode("cefabd");

        Assert.Equal(9, output);
    }

    [Fact]
    public void CanDecodeZero()
    {
        var output = _display.Decode("cagedb");

        Assert.Equal(0, output);
    }

    [Fact]
    public void CanDecodeMultipleNumbers()
    {
        var output = _display.Decode("cdfeb fcadb cdfeb cdbaf");

        Assert.Equal(5353, output);
    }

    [Fact]
    public void CanDecodeThreeProperly()
    {
        _display.SetSignals("gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc");
        var output = _display.Decode("cfgab");

        Assert.Equal(3, output);
    }
}