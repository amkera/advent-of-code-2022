using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Xsl;

var regex = new Regex("(\\d+)-(\\d+),(\\d+)-(\\d+)");

var data =
    (from line in File.ReadAllLines("input04.txt")
        where !string.IsNullOrWhiteSpace(line)
        let regexMatch = regex.Match(line)
        select (
            firstElf: (
                lowNumber: long.Parse(regexMatch.Groups[1].Value),
                highNumber: long.Parse(regexMatch.Groups[2].Value)
            ),
            secondElf: (
                lowNumber: long.Parse(regexMatch.Groups[3].Value),
                highNumber: long.Parse(regexMatch.Groups[4].Value)
            )
        )
    ).ToArray();
 
int calculateFullOverlaps()
{
    var overlaps = 0;
    foreach (var (firstElf, secondElf) in data)
    {
        if (firstElf.lowNumber <= secondElf.lowNumber && firstElf.highNumber >= secondElf.highNumber)
            overlaps++;
         else if (secondElf.lowNumber <= firstElf.lowNumber && secondElf.highNumber >= firstElf.highNumber)
            overlaps++;
    }
    Console.WriteLine($"The answer to part 1 is: {overlaps}");
    return overlaps;
}
calculateFullOverlaps();

int calculatePartialOverlaps()
{
    var overlaps = 0;
    foreach (var (firstElf, secondElf) in data)
    {
        if (firstElf.lowNumber >= secondElf.lowNumber && firstElf.lowNumber <= secondElf.highNumber)
            // 72-92,48-88
            overlaps++;
        else if (firstElf.highNumber >= secondElf.lowNumber && firstElf.highNumber <= secondElf.highNumber)
            //52-66,60-70
            overlaps++;
        else if (secondElf.lowNumber >= firstElf.lowNumber && secondElf.lowNumber <= firstElf.highNumber)
            //2-11,10-96
            overlaps++;
        else if (secondElf.highNumber >= firstElf.lowNumber && secondElf.highNumber <= firstElf.highNumber)
            //2-11,10-10
            overlaps++;
    }
    Console.WriteLine($"The answer to part 2 is: {overlaps}");
    return overlaps;
}

calculatePartialOverlaps();