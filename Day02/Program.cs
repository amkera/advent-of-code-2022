var data =
    (from line in File.ReadAllLines("input02.txt")
        select line).ToArray();

var myScoringDictionary = new Dictionary<string, int>
{
    { "X", 1 }, //rock
    { "Y", 2 }, //paper
    { "Z", 3 }, //scissors
    // { "A", 1 }, rock
    // { "B", 2 }, paper
    // { "C", 3 }  scissors
};

int myScoreOfTheRoundForPart1 (string opponent, string me)
{
    return (opponent, me) switch
    {
        ("A", "X") => 4, //rock vs rock, 1 + 3
        ("A", "Y") => 8, //rock vs paper, 2 + 6
        ("A", "Z") => 3, //rock vs scissors, 3 + 0

        ("B", "X") => 1, //paper vs rock, 1 + 0
        ("B", "Y") => 5, //paper vs paper, 2 + 3
        ("B", "Z") => 9, //paper vs scissors, 3 + 6

        ("C", "X") => 7, //scissors vs rock, 1 + 6
        ("C", "Y") => 2, //scissors vs paper, 2 + 0
        ("C", "Z") => 6, //scissors vs scissors, 3 + 3
    };
}

int myScoreOfTheRoundForPart2(string opponent, string me)
{
    return (opponent, me) switch
    {
        //opponent chooses rock
        ("A", "X") => 3, //X means I lose, so I choose scissors: Lose(0) + Scissors(3)
        ("A", "Y") => 4, //Y means a tie, so I choose rock: Tie(3) + Rock (1)
        ("A", "Z") => 8, //Z means I win, so I choose paper: Win (6) + Paper(2)

        //opponent chooses paper
        ("B", "X") => 1, //X means I lose, so I choose rock: Lose(0) + Rock(1)
        ("B", "Y") => 5, //Y means a tie, so I choose paper: Tie(3) + Paper(2)
        ("B", "Z") => 9, //Z means I win, so I choose scissors: Win(6) + Scissors(3)

        //opponent chooses scissors
        ("C", "X") => 2, //X means I lose, so I choose paper: Lose(0) + Paper(2)
        ("C", "Y") => 6, //Y means a tie, so I choose scissors: Tie(3) + Scissors(3)
        ("C", "Z") => 7, //Z means I win, so I choose rock: Win(6) + Rock(1)
    };
}


int Part1()
{
    // var myTotalScore = 0;
    // foreach (var line in data)
    // {
    //     var game = line.Split(" ");
    //     var opponent = game[0];
    //     var me = game[1];
    //     var myRoundScore = myScoreOfTheRoundForPart1(opponent, me);
    //     myTotalScore += myRoundScore;
    // }
    
    //Using a LINQ expression
    var myTotalScore = (from line in data 
        select line.Split(" ") into game 
        let opponent = game[0] let me = game[1] 
        select myScoreOfTheRoundForPart1(opponent, me)).Sum();

    Console.WriteLine($"Answer to part 1: {myTotalScore}");
    return myTotalScore;
}



int Part2()
{
    // int myTotalScore = 0;
    // foreach (var line in data)
    // {
    //     var game = line.Split(" ");
    //     var opponent = game[0];
    //     var me = game[1];
    //     var myRoundScore = myScoreOfTheRoundForPart2(opponent, me);
    //     myTotalScore += myRoundScore;
    // }
    
    //Using a LINQ expression
    var myTotalScore = (from line in data 
        select line.Split(" ") into game 
        let opponent = game[0] let me = game[1] 
        select myScoreOfTheRoundForPart2(opponent, me)).Sum();
    
    Console.WriteLine($"Answer to part 2: {myTotalScore}");
    return myTotalScore;
}

Part1();
Part2();