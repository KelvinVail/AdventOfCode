using Xunit;

namespace AdventOfCode.Tests;

public class DumboOctopusesTests
{
    private readonly DumboOctopuses _octopuses = new (true);

    [Fact]
    public void TestDataDoesNotFlashOnFirstIteration()
    {
        _octopuses.Iterate();

        Assert.Equal(0, _octopuses.TotalFlashes);
    }

    [Fact]
    public void TestDataFlashesThirtyFiveTimesOnSecondIteration()
    {
        _octopuses.Iterate();
        _octopuses.Iterate();

        Assert.Equal(35, _octopuses.TotalFlashes);
    }

    [Fact]
    public void TestDataFlashes204TimesAfter10Iterations()
    {
        for (int i = 0; i < 10; i++)
            _octopuses.Iterate();

        Assert.Equal(204, _octopuses.TotalFlashes);
    }

    [Fact]
    public void TestDataFlashes1656TimesAfter100Iterations()
    {
        for (int i = 0; i < 100; i++)
            _octopuses.Iterate();

        Assert.Equal(1656, _octopuses.TotalFlashes);
    }

    [Fact]
    public void AllFlashOnIteration195()
    {
        Assert.Equal(195, _octopuses.AllFlashOnIteration());
    }
}