namespace AdventOfCode.Solutions.Year2022.Day02;

class Solution : SolutionBase
{
    public Solution() : base(02, 2022, "Rock Paper Scissors") { }

    protected override string SolvePartOne()
    {
        ScoreCalculator scoreCalc = new ScoreCalculator();
        IEnumerable<int> scores = Input.SplitByNewline().Select(row => scoreCalc.ScoreRow(ParseRow(row)));
        return scores.Sum().ToString();
    }


    private (char, char) ParseRow(string row)
    {
        return (row.ElementAt(0), row.ElementAt(2));
    }

    private (char, char) ConvertRow((char, char) input)
    {
        return (input.Item1, SelectWhatToPlay(input));
    }

    private char SelectWhatToPlay((char, char) input)
    {
        return input.Item2 switch
        {
            'Y' => input.Item1 switch // draw
            {
                'A' => 'X',
                'B' => 'Y',
                'C' => 'Z',
                _ => throw new ArgumentException("Invalid input"),
            },
            'X' => input.Item1 switch // lose
            {
                'A' => 'Z',
                'B' => 'X',
                'C' => 'Y',
                _ => throw new ArgumentException("Invalid input"),
            },
            'Z' => input.Item1 switch // win
            {
                'A' => 'Y',
                'B' => 'Z',
                'C' => 'X',
                _ => throw new ArgumentException("Invalid input"),
            },
            _ => throw new ArgumentException("Invalid input"),
        };
    }

    protected override string SolvePartTwo()
    {
        ScoreCalculator scoreCalc = new ScoreCalculator();
        IEnumerable<int> scores = Input.SplitByNewline().Select(row => scoreCalc.ScoreRow(ConvertRow(ParseRow(row))));
        return scores.Sum().ToString();
    }
}

class ScoreCalculator
{
    private static IDictionary<(char, char), int> ScoringScheme = new Dictionary<(char, char), int>
    {
        // A: rock, B: paper, C: scissors
        // X: rock, Y: paper, Z: scissors
        {('A', 'X'), 3 + 1},
        {('A', 'Y'), 6 + 2},
        {('A', 'Z'), 0 + 3},
        {('B', 'X'), 0 + 1},
        {('B', 'Y'), 3 + 2},
        {('B', 'Z'), 6 + 3},
        {('C', 'X'), 6 + 1},
        {('C', 'Y'), 0 + 2},
        {('C', 'Z'), 3 + 3},
    };

    public int ScoreRow((char, char) row)
    {
        return ScoringScheme[row];
    }
}