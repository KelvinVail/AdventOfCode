using Xunit;

namespace AdventOfCode.Tests;

public class PolymerInserterTests
{
    [Theory]
    [InlineData("NN -> C", "NN", "NCN")]
    [InlineData("NC -> B", "NC", "NBC")]
    [InlineData("CB -> H", "CB", "CHB")]
    public void TemplateIsInsertedIntoSequence(
        string template,
        string sequence,
        string expectedOutput)
    {
        var inserter = new PolymerInserter();
        inserter.Clear();
        inserter.AddTemplate(template);

        var output = inserter.Insert(sequence);

        Assert.Equal(expectedOutput, output);
    }

    [Fact]
    public void NothingIsInsertedIfTemplateNotFound()
    {
        var inserter = new PolymerInserter();
        inserter.Clear();
        inserter.AddTemplate("XX -> X");

        var output = inserter.Insert("NN");

        Assert.Equal("NN", output);
    }

    [Fact]
    public void AllInsertsAreMadeAtTheSameTime()
    {
        var inserter = new PolymerInserter();
        inserter.Clear();
        inserter.AddTemplate("NN -> C");
        inserter.AddTemplate("NC -> B");
        inserter.AddTemplate("CB -> H");

        var output = inserter.Insert("NNCB");

        Assert.Equal("NCNBCHB", output);
    }

    [Fact]
    public void TestPolymersGrowAsExpected()
    {
        var inserter = new PolymerInserter(true);

        var output = inserter.Insert(10);

        Assert.Equal(3073, output.Length);
    }

    [Fact]
    public void TestPolymersAreScored()
    {
        var inserter = new PolymerInserter(true);

        var output = inserter.Insert(10);
        var score = inserter.Score(output);

        Assert.Equal(1588, score);
    }
}