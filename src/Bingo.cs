using System.Globalization;

namespace AdventOfCode;

internal class Bingo
{
    private readonly List<int> _bingoNumbers = new ();
    private readonly List<BingoBoard> _boards = new ();

    public Bingo(bool test = false)
    {
        var fileName = test ? "TestInput" : "Input";
        var input = File.ReadAllLines(@".\Input\2021\04\" + fileName + ".txt");

        var lineCount = 0;
        var currentBoard = new BingoBoard();
        foreach (var line in input)
        {
            lineCount++;
            if (lineCount == 1)
            {
                _bingoNumbers.AddRange(line.Split(',').Select(ToInt).ToList());
                continue;
            }

            if (line.Length == 0)
            {
                if (currentBoard.SumOfUnmarked > 0)
                    _boards.Add(currentBoard);
                currentBoard = new BingoBoard();
                continue;
            }

            var rowList = line.Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(ToInt).ToList();
            currentBoard.AddRow(rowList);
        }

        _boards.Add(currentBoard);
    }

    public int FindWinner()
    {
        for (int i = 0; i < _bingoNumbers.Count; i++)
        {
            foreach (var board in _boards)
            {
                board.NumberCalled(_bingoNumbers[i]);
                if (board.Winner())
                {
                    return board.SumOfUnmarked * _bingoNumbers[i];
                }
            }
        }

        return 0;
    }

    public int FindLoser()
    {
        for (int i = 0; i < _bingoNumbers.Count; i++)
        {
            foreach (var board in _boards)
            {
                board.NumberCalled(_bingoNumbers[i]);
                var losers = _boards.Where(x => !x.Winner());
                if (!losers.Any())
                {
                    return board.SumOfUnmarked * _bingoNumbers[i];
                }
            }
        }

        return 0;
    }

    private static int ToInt(string c) =>
        int.Parse(c, NumberStyles.Integer, new NumberFormatInfo());
}