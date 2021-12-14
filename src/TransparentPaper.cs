namespace AdventOfCode;

public class TransparentPaper : Puzzle
{
    private readonly List<string> _folds = new ();
    private HashSet<Coordinate> _dots = new ();

    public TransparentPaper(bool test = false)
        : base(13, test)
    {
        foreach (var line in Input)
        {
            if (line.Length == 0) continue;
            if (line.StartsWith('f'))
            {
                _folds.Add(line);
            }
            else
            {
                var c = line.Split (',');
                _dots.Add(new Coordinate(ToInt(c[1]), ToInt(c[0])));
            }
        }
    }

    public int DotCount => _dots.Count;

    public void Fold(string s = null)
    {
        var fold = (s ?? _folds[0]).Split('=');
        var isRow = fold[0].EndsWith('y');
        var foldIndex = ToInt(fold[1]);
        var newDots = new HashSet<Coordinate>();
        foreach (var dot in _dots)
        {
            if (isRow)
                dot.FoldRow(foldIndex);
            else
                dot.FoldColumn(foldIndex);
            newDots.Add(dot);
        }

        _dots = newDots;
    }

    public void MakeAllFolds()
    {
        foreach (var fold in _folds)
            Fold(fold);
    }

    public void DisplayCode()
    {
        var maxRow = _dots.Max(x => x.Row);
        var maxColumn = _dots.Max(x => x.Column);

        for (int r = 0; r <= maxRow; r++)
        {
            var row = string.Empty;
            for (int c = 0; c <= maxColumn; c++)
            {
                if (_dots.Any(x => x.Row == r && x.Column == c))
                    row += "X";
                else
                    row += ".";
            }

            Console.WriteLine(row);
        }
    }
}