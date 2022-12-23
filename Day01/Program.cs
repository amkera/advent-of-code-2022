var data =
    (from line in File.ReadAllLines("input.txt")
        select line).ToArray();

// [1000, 2000, 3000, "", 4000, "", 5000, 6000, "", 7000, 8000, 9000, "", 10000];

var caloriesPerElf = new List<long>(); //list of longs
var currentElfsCalories = 0L; //0 as a long

for (int index = 0; index < data.Length; ++index)
{
    if (data[index] != "")
    {
        currentElfsCalories += long.Parse(data[index]);
        //Sum the calories of the current elf
    }
    else
    {
        caloriesPerElf.Add(currentElfsCalories);
        currentElfsCalories = 0;
        //When we reach a blank line, store the current elf into the caloriesPerElf list and reset the temporary variable currentElfsCalories to 0
    }
}

if (currentElfsCalories > 0)
    caloriesPerElf.Add(currentElfsCalories);
//Include the last elf

void GetPart1() =>
    Console.WriteLine(caloriesPerElf.Max());

void GetPart2() =>
    Console.WriteLine(caloriesPerElf.OrderByDescending(x => x).Take(3).Sum());

GetPart1();
GetPart2();

