using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Tests;

public class DumboOctopusTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    public void DoesNotFlashIfEnergyIsBelowTen(int energy)
    {
        var octopus = new DumboOctopus(energy);

        Assert.Equal(0, octopus.FlashCount);
    }

    [Fact]
    public void FlashesWhenEnergyIsTen()
    {
        var octopus = new DumboOctopus(10);

        Assert.Equal(1, octopus.FlashCount);
    }

    [Fact]
    public void ChargeIncreasesEnergyByOne()
    {
        var octopus = new DumboOctopus(9);

        octopus.Charge();

        Assert.Equal(1, octopus.FlashCount);
    }

    [Fact]
    public void OnlyFlashesWhenEnergyReachesTen()
    {
        var octopus = new DumboOctopus(8);

        octopus.Charge();
        octopus.Charge();

        Assert.Equal(1, octopus.FlashCount);
    }

    [Fact]
    public void FlashesEveryTenCharges()
    {
        var octopus = new DumboOctopus(9);

        octopus.Charge(1);
        Assert.Equal(1, octopus.FlashCount);

        for (int i = 0; i < 20; i++)
            octopus.Charge(i + 2);

        Assert.Equal(3, octopus.FlashCount);
    }

    [Fact]
    public void OnyFlashesOncePerIteration()
    {
        var iteration = 1;
        var octopus = new DumboOctopus(0);

        for (int i = 0; i < 100; i++)
        {
            octopus.Charge(iteration);
        }

        Assert.Equal(1, octopus.FlashCount);
    }

    [Fact]
    public void ChargesOctopusToTheNorthWhenFlashes()
    {
        var octopuses = new List<DumboOctopus>();
        var octopus = new DumboOctopus(9, new Coordinate(5, 5), octopuses);
        var octopusNorth = new DumboOctopus(9, new Coordinate(4, 5), octopuses);
        octopuses.Add(octopus);
        octopuses.Add(octopusNorth);

        octopus.Charge();

        Assert.Equal(1, octopus.FlashCount);
        Assert.Equal(1, octopusNorth.FlashCount);
    }

    [Fact]
    public void ChargesOctopusToTheNorthEastWhenFlashes()
    {
        var octopuses = new List<DumboOctopus>();
        var octopus = new DumboOctopus(9, new Coordinate(5, 5), octopuses);
        var northEast = new DumboOctopus(9, new Coordinate(4, 6), octopuses);
        octopuses.Add(octopus);
        octopuses.Add(northEast);

        octopus.Charge();

        Assert.Equal(1, octopus.FlashCount);
        Assert.Equal(1, northEast.FlashCount);
    }

    [Fact]
    public void ChargesOctopusToTheEastWhenFlashes()
    {
        var octopuses = new List<DumboOctopus>();
        var octopus = new DumboOctopus(9, new Coordinate(5, 5), octopuses);
        var east = new DumboOctopus(9, new Coordinate(5, 6), octopuses);
        octopuses.Add(octopus);
        octopuses.Add(east);

        octopus.Charge();

        Assert.Equal(1, octopus.FlashCount);
        Assert.Equal(1, east.FlashCount);
    }

    [Fact]
    public void ChargesOctopusToTheSouthEastWhenFlashes()
    {
        var octopuses = new List<DumboOctopus>();
        var octopus = new DumboOctopus(9, new Coordinate(5, 5), octopuses);
        var southEast = new DumboOctopus(9, new Coordinate(6, 6), octopuses);
        octopuses.Add(octopus);
        octopuses.Add(southEast);

        octopus.Charge();

        Assert.Equal(1, octopus.FlashCount);
        Assert.Equal(1, southEast.FlashCount);
    }

    [Fact]
    public void ChargesOctopusToTheSouthWhenFlashes()
    {
        var octopuses = new List<DumboOctopus>();
        var octopus = new DumboOctopus(9, new Coordinate(5, 5), octopuses);
        var south = new DumboOctopus(9, new Coordinate(6, 5), octopuses);
        octopuses.Add(octopus);
        octopuses.Add(south);

        octopus.Charge();

        Assert.Equal(1, octopus.FlashCount);
        Assert.Equal(1, south.FlashCount);
    }

    [Fact]
    public void ChargesOctopusToTheSouthWestWhenFlashes()
    {
        var octopuses = new List<DumboOctopus>();
        var octopus = new DumboOctopus(9, new Coordinate(5, 5), octopuses);
        var southWest = new DumboOctopus(9, new Coordinate(6, 4), octopuses);
        octopuses.Add(octopus);
        octopuses.Add(southWest);

        octopus.Charge();

        Assert.Equal(1, octopus.FlashCount);
        Assert.Equal(1, southWest.FlashCount);
    }

    [Fact]
    public void ChargesOctopusToTheWestWhenFlashes()
    {
        var octopuses = new List<DumboOctopus>();
        var octopus = new DumboOctopus(9, new Coordinate(5, 5), octopuses);
        var west = new DumboOctopus(9, new Coordinate(5, 4), octopuses);
        octopuses.Add(octopus);
        octopuses.Add(west);

        octopus.Charge();

        Assert.Equal(1, octopus.FlashCount);
        Assert.Equal(1, west.FlashCount);
    }

    [Fact]
    public void ChargesOctopusToTheNorthWestWhenFlashes()
    {
        var octopuses = new List<DumboOctopus>();
        var octopus = new DumboOctopus(9, new Coordinate(5, 5), octopuses);
        var northWest = new DumboOctopus(9, new Coordinate(4, 4), octopuses);
        octopuses.Add(octopus);
        octopuses.Add(northWest);

        octopus.Charge();

        Assert.Equal(1, octopus.FlashCount);
        Assert.Equal(1, northWest.FlashCount);
    }
}