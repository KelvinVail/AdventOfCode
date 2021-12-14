using System;
using Xunit;

namespace AdventOfCode.Tests;

public class CaveTests
{
    [Theory]
    [InlineData("A")]
    [InlineData("a")]
    [InlineData("start")]
    [InlineData("end")]
    [InlineData("x")]
    public void CanBeGivenAnId(string id)
    {
        var cave = new Cave(id);

        Assert.Equal(id, cave.Id);
    }

    [Theory]
    [InlineData("A")]
    [InlineData("a")]
    [InlineData("end")]
    [InlineData("x")]
    public void CavesCanBeVisited(string id)
    {
        var cave = new Cave(id);

        Assert.True(cave.CanVisit);
    }

    [Theory]
    [InlineData("A")]
    [InlineData("B")]
    [InlineData("AB")]
    [InlineData("XXX")]
    public void CaveWithCapitalIdsCanBeVisitedMultipleTimes(string id)
    {
        var cave = new Cave(id);

        for (int i = 0; i < 10; i++)
            cave.Visit();

        Assert.True(cave.CanVisit);
    }

    [Theory]
    [InlineData("a")]
    [InlineData("b")]
    [InlineData("ab")]
    [InlineData("xxx")]
    public void CaveWithLowerCaseIdsCanOnlyBeVisitedOnce(string id)
    {
        var cave = new Cave(id);

        cave.Visit();

        Assert.False(cave.CanVisit);
        var ex = Assert.Throws<InvalidOperationException>(() => cave.Visit());
        Assert.Equal($"Small cave {id} has already been visited.", ex.Message);
    }

    [Fact]
    public void TwoCavesCanBeConnected()
    {
        var caveA = new Cave("A");
        var caveB = new Cave("B");

        caveA.Connect(caveB);

        Assert.Contains(caveB, caveA.ConnectedCaves);
        Assert.Contains(caveA, caveB.ConnectedCaves);
    }

    [Fact]
    public void CavesCanOnlyBeConnectedWithASingleConnection()
    {
        var caveA = new Cave("A");
        var caveB = new Cave("B");

        caveA.Connect(caveB);
        caveB.Connect(caveA);

        Assert.Single(caveA.ConnectedCaves);
        Assert.Single(caveB.ConnectedCaves);
    }

    [Fact]
    public void AConnectionClosedIfTheConnectedCaveCanNotBeVisited()
    {
        var caveA = new Cave("A");
        var caveb = new Cave("b");
        caveA.Connect(caveb);

        Assert.Contains(caveb, caveA.ConnectedCaves);
        caveb.Visit();

        Assert.DoesNotContain(caveb, caveA.ConnectedCaves);
    }

    [Fact(Skip = "Slow")]
    public void TotalNumberOfRoutesBetweenTwoCavesCanBeCalculated()
    {
        var start = new Cave("start");
        var A = new Cave("A");
        var b = new Cave("b");
        var c = new Cave("c");
        var d = new Cave("d");
        var end = new Cave("end");

        start.Connect(A);
        start.Connect(b);
        A.Connect(c);
        A.Connect(b);
        b.Connect(d);
        A.Connect(end);
        b.Connect(end);

        Assert.Equal(10, start.TotalRoutes(end));
    }
}