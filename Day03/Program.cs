var data =
    (from line in File.ReadAllLines("input03.txt")
        select (
            whole: line.ToCharArray(),
            firstHalf: line[..(line.Length / 2)].ToCharArray(),
            secondHalf: line[(line.Length / 2)..].ToCharArray()
        )).ToArray();

//Each line can be called like this: line.firstHalf, line.SecondHalf

int getPriorityOfLetter(char c)
{
    if (c is >= 'a' and <= 'z')
    {
        return (c - 'a' + 1); //1-26
    }

    return (c - 'A' + 27); //27-52
}

int Part1()
{
    var sumOfPriorities = 0;
    foreach (var rucksack in data)
    {
        var first = rucksack.firstHalf;
        var second = rucksack.secondHalf;
        var uniqueLetter = first.Intersect(second).Single();

        sumOfPriorities += getPriorityOfLetter(uniqueLetter);

    }
    Console.WriteLine($"Answer to part 1: {sumOfPriorities}");
    return sumOfPriorities;
}

Part1();

int Part2()
{
    var sumOfPriorities = 0;
    for (int index = 0; index < data.Length; index += 3)
    {
        var firstRucksack = data[index].whole;
        var secondRucksack = data[index + 1].whole;
        var thirdRucksack = data[index + 2].whole;
        var uniqueLetter = firstRucksack.Intersect(secondRucksack).Intersect(thirdRucksack).Single();
        sumOfPriorities += getPriorityOfLetter(uniqueLetter);
    }

    Console.WriteLine($"Answer to part 2: {sumOfPriorities}");
    return sumOfPriorities;


}

Part2();