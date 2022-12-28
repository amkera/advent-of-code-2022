// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

var lines = File.ReadAllLines("input05.txt");
var divider = Array.IndexOf(lines, string.Empty); //finds the line between the config and the instructions

var numberOfStacks = int.Parse(lines[divider - 1].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Last());
var stacks = new Stack<char>[numberOfStacks];
Console.WriteLine(stacks);
/*
 * Separate first blank line, before it is the crate configuration and after it are the instructions
 * Need to use Stack, for last in first out since that's the way crates are moved around
 * Elements can be added using the Push() method. Cannot use collection-initializer syntax.
 * Elements can be retrieved using the Pop() and the Peek() methods. It does not support an indexer.
 */

for (var lineIndex = divider - 2; lineIndex >= 0; lineIndex--)  
    // 7 to 0. horizontal rows
    // lineIndex is 0, divider -2 makes that 7.
    // starting at the bottom of the stacks
{
    var line = lines[lineIndex];
    for (var stackId = 0; stackId < numberOfStacks; stackId++) //0 to 8, for the vertical stacks
    {
        var crateLetter = line[stackId * 4 + 1];
        if (char.IsLetter(crateLetter))
        {
            stacks[stackId] ??= new Stack<char>();
            stacks[stackId].Push(crateLetter);
            //Adds the crate letter to the appropriate Stack (1, 2, 3...)
        }
        //characters are present at 1, 5, 9, 13...So multiply the difference between numbers and add the first index where a letter appears
    }
}



for (var instructionId = divider + 1; instructionId < lines.Length; instructionId++)
{
    var instruction = lines[instructionId];
    var parts = instruction.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    var numberOfCrates = int.Parse(parts[1]);
    var sourceStackId = int.Parse(parts[3]) - 1;
    var targetStackId = int.Parse(parts[5]) - 1;

    var transferStack = new Stack<char>();
    for (var i = 0; i < numberOfCrates; i++)
    {
        var crate2 = stacks[sourceStackId].Pop();
        transferStack.Push(crate2);
    }
 
    //pushes them back in, in the reverse order
    while(transferStack.TryPop(out var crate2))
    {
        stacks[targetStackId].Push(crate2);
    }
}

// Print result
Console.WriteLine(string.Join("", stacks.Select(s => s.Peek())));