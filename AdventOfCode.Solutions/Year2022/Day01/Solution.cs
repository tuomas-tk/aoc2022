namespace AdventOfCode.Solutions.Year2022.Day01;

class Solution : SolutionBase
{
    public Solution() : base(01, 2022, "Calorie Counting") { }

    protected override string SolvePartOne()
    {
        // Debug = true;
        int max = 0;
        foreach (string elf in this.Input.SplitByParagraph())
        {
            int totalCalories = elf.SplitByNewline().Select(s => Int32.Parse(s)).Sum();
            if (totalCalories > max)
            {
                max = totalCalories;
            }
        }
        return max.ToString();
    }

    protected override string SolvePartTwo()
    {
        //Debug = true;
        return Input
            .SplitByParagraph()
            .Select(elf =>
                elf
                    .SplitByNewline()
                    .Select(s => Int32.Parse(s))
                    .Sum()
            )
            .Order()
            .TakeLast(3)
            .Sum()
            .ToString();
    }
}
