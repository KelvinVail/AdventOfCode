using Xunit;

namespace AdventOfCode.Tests;

public class TransparentPaperTests
{
    [Fact]
    public void DotsAfterFirstFoldInTest()
    {
        var paper = new TransparentPaper(true);

        paper.Fold();
        var dots = paper.DotCount;

        Assert.Equal(17, dots);
    }
}