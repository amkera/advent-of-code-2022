// See https://aka.ms/new-console-template for more information

using System.Reflection.Metadata;
using System.Runtime.InteropServices.JavaScript;

var allData =
    (from line in File.ReadAllLines("input06.txt")
        where !string.IsNullOrWhiteSpace(line)
        select line).ToArray();

// string calculateCharactersToBeProcessed()
// {
//     var extracted = "";
//     var truncateLength = data.Length % 4;
//     var truncatedData = truncateLength == 0 ? data : data.Substring(0, data.Length - truncateLength);
//     for (var index = 0; index < truncatedData.Length; index += 4)
//     {
//         if ((truncatedData[index] != truncatedData[index + 1]) && (truncatedData[index + 1] != truncatedData[index + 2]) &&
//             (truncatedData[index + 2] != truncatedData[index + 3]))
//         {
//             extracted = truncatedData.Substring(0, (truncatedData[index + 3]));
//             
//         }
//     }
//     Console.WriteLine(extracted);
//     return extracted;
// }
//
// calculateCharactersToBeProcessed();


int calculateCharactersToBeProcessed(int desiredLength)
{
    var line = allData[0];
    for (var index = 0; index < line.Length - desiredLength - 1; index++)
    {
        if (line.Substring(index).Take(desiredLength).Distinct().Count() == desiredLength)
        {
            Console.WriteLine($"The answer to part 1 is {index + desiredLength}");
            return index + desiredLength;
        }
    }

    throw new InvalidOperationException();
}

calculateCharactersToBeProcessed(14);

//Part 1 can be solved with desiredLength = 4, and part 2 with desiredLength = 14 as seen above