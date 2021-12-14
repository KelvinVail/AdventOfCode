using Xunit;

namespace AdventOfCode.Tests;

public class CoordinateTests
{
    [Theory]
    [InlineData(1, 2)]
    [InlineData(7, 8)]
    [InlineData(7, 12)]
    [InlineData(135, 200)]
    [InlineData(14, 200)]
    public void CellsAboveTheFoldRemainUnchanged(int row, int fold)
    {
        var coordinate = new Coordinate(row, 1);

        coordinate.FoldRow(fold);

        Assert.Equal(row, coordinate.Row);
        Assert.Equal(1, coordinate.Column);
    }

    [Theory]
    [InlineData(3, 2, 1)]
    [InlineData(9, 8, 7)]
    [InlineData(17, 12, 7)]
    [InlineData(300, 200, 100)]
    [InlineData(386, 200, 14)]
    public void CellsBelowTheFoldAreFoldedUpwards(int row, int fold, int foldedRow)
    {
        var coordinate = new Coordinate(row, 1);

        coordinate.FoldRow(fold);

        Assert.Equal(foldedRow, coordinate.Row);
        Assert.Equal(1, coordinate.Column);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(7, 8)]
    [InlineData(7, 12)]
    [InlineData(135, 200)]
    [InlineData(14, 200)]
    public void CellsRightOfTheFoldRemainUnchanged(int column, int fold)
    {
        var coordinate = new Coordinate(1, column);

        coordinate.FoldColumn(fold);

        Assert.Equal(1, coordinate.Row);
        Assert.Equal(column, coordinate.Column);
    }

    [Theory]
    [InlineData(3, 2, 1)]
    [InlineData(9, 8, 7)]
    [InlineData(17, 12, 7)]
    [InlineData(300, 200, 100)]
    [InlineData(386, 200, 14)]
    public void CellsRightOfTheFoldAreFoldedLeft(int column, int fold, int foldedColumn)
    {
        var coordinate = new Coordinate(1, column);

        coordinate.FoldColumn(fold);

        Assert.Equal(1, coordinate.Row);
        Assert.Equal(foldedColumn, coordinate.Column);
    }
}