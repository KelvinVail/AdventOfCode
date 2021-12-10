using Xunit;

namespace AdventOfCode.Tests;

public class SyntaxCheckerTests
{
    private readonly SyntaxChecker _checker = new (true);

    [Fact]
    public void ReturnDefaultIfNoCorruptedCharacterFound()
    {
        var corrupted = _checker.FirstCorruptedCloser("()");

        Assert.Equal('\0', corrupted);
    }

    [Theory]
    [InlineData("(]", ']')]
    [InlineData("{()()()>", '>')]
    [InlineData("(((()))}", '}')]
    [InlineData("[({(<(())[]>[[{[]{<()<>>", '\0')]
    [InlineData("[(()[<>])]({[<{<<[]>>(", '\0')]
    [InlineData("{([(<{}[<>[]}>{[]{[(<()>", '}')]
    [InlineData("(((({<>}<{<{<>}{[]{[]{}", '\0')]
    [InlineData("[[<[([]))<([[{}[[()]]]", ')')]
    [InlineData("[{[{({}]{}}([{[{{{}}([]", ']')]
    [InlineData("{<[[]]>}<{[{[{[]{()[[[]", '\0')]
    [InlineData("[<(<(<(<{}))><([]([]()", ')')]
    [InlineData("<{([([[(<>()){}]>(<<{{", '>')]
    [InlineData("<{([{{}}[<[[[<>{}]]]>[]]", '\0')]
    public void ReturnFirstCorruptedCloser(string input, char output)
    {
        var corrupted = _checker.FirstCorruptedCloser(input);

        Assert.Equal(output, corrupted);
    }

    [Theory]
    [InlineData(")", 3)]
    [InlineData("]", 57)]
    [InlineData("}", 1197)]
    [InlineData(">", 25137)]
    [InlineData("})])>", 26397)]
    public void ScoreCorruptCharacters(string input, int expectedScore)
    {
        var score = _checker.Score(input);

        Assert.Equal(expectedScore, score);
    }

    [Fact]
    public void ScoreTestInput()
    {
        var score = _checker.Score();

        Assert.Equal(26397, score);
    }

    [Theory]
    [InlineData("[({(<(())[]>[[{[]{<()<>>", "}}]])})]")]
    [InlineData("[(()[<>])]({[<{<<[]>>(", ")}>]})")]
    [InlineData("(((({<>}<{<{<>}{[]{[]{}", "}}>}>))))")]
    [InlineData("{<[[]]>}<{[{[{[]{()[[[]", "]]}}]}]}>")]
    [InlineData("<{([{{}}[<[[[<>{}]]]>[]]", "])}>")]
    public void CompleteIncompleteLines(string input, string output)
    {
        var closeWith = _checker.Complete(input);

        Assert.Equal(output, closeWith);
    }

    [Theory]
    [InlineData("])}>", 294)]
    [InlineData("}}]])})]", 288957)]
    [InlineData(")}>]})", 5566)]
    [InlineData("}}>}>))))", 1480781)]
    [InlineData("]]}}]}]}>", 995444)]
    [InlineData(")>}>>>}})}])>})", 11962370241)]
    public void ScoreCompleteLines(string input, long expectedScore)
    {
        var score = _checker.ScoreCompletedLine(input);

        Assert.Equal(expectedScore, score);
    }

    [Fact]
    public void CalculateMiddleScore()
    {
        var middleScore = _checker.GetMiddleScore();

        Assert.Equal(288957, middleScore);
    }
}