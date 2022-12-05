namespace AdventOfCode.Solutions.Year2022.Day03;

class Solution : SolutionBase
{
    public Solution() : base(03, 2022, "Rucksack Reorganization") { }

    protected override string SolvePartOne()
    {
        //Debug = true;
        IEnumerable<Rucksack> rucksacks = Input.SplitByNewline().Select(line => new Rucksack(line));
        int sum = 0;
        foreach (var rucksack in rucksacks)
        {
            Item mistake = new Item(rucksack.GetMistake());
            System.Console.WriteLine(rucksack + " -> " + mistake + ": " + mistake.GetPriority().ToString());
            sum += mistake.GetPriority();
        }
        return sum.ToString();
    }

    protected override string SolvePartTwo()
    {
        IEnumerable<Rucksack> rucksacks = Input.SplitByNewline().Select(line => new Rucksack(line));
        int sum = 0;
        for (int i = 0; i < rucksacks.Count() / 3; i++)
        {
            char common = rucksacks.ElementAt(i * 3).ContentsTotal
                .Intersect(rucksacks.ElementAt(i * 3 + 1).ContentsTotal)
                .Intersect(rucksacks.ElementAt(i * 3 + 2).ContentsTotal)
                .First();
            sum += new Item(common).GetPriority();
        }
        return sum.ToString();
    }
}

class Rucksack
{
    public HashSet<char> ContentsTotal { get; }
    public HashSet<char> Contents1 { get; }
    public HashSet<char> Contents2 { get; }

    public Rucksack(string contents)
    {
        ContentsTotal = contents.ToHashSet();
        Contents1 = contents.Take(contents.Length / 2).ToHashSet();
        Contents2 = contents.TakeLast(contents.Length / 2).ToHashSet();
    }

    public char GetMistake()
    {
        return Contents1.Intersect(Contents2).First();
    }

    override public string ToString()
    {
        return Contents1.Count.ToString() + "/" + Contents2.Count.ToString();
    }
}

class Item
{
    public char Identifier { get; }
    public Item(char identifier)
    {
        Identifier = identifier;
    }
    public int GetPriority()
    {
        if (Identifier >= 'a' && Identifier <= 'z')
        {
            return (Identifier - 'a') + 1;
        }
        else if (Identifier >= 'A' && Identifier <= 'Z')
        {
            return (Identifier - 'A') + 27;
        }
        else throw new ArgumentOutOfRangeException("Not valid identifier");
    }

    public override string ToString()
    {
        return Identifier.ToString();
    }
}