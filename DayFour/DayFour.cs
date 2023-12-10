using System.ComponentModel.DataAnnotations;
using System.Text;
using aoc2023;


public static class DayFour
{
    public static async Task Solve()
    {
        var file = await File.ReadAllLinesAsync($"{nameof(DayFour)}/input.txt");
        var results = new List<int>();

        foreach (var line in file)
        {
            var cardSplit = line.Split(":");
            var gameSplit = cardSplit[1].Split("|");
            
            var winningNumbers = gameSplit[0].Trim().Split(" ").Where(x => x != string.Empty).Select(int.Parse);
            var gameNumbers = gameSplit[1].Trim().Split(" ").Where(x => x != string.Empty).Select(int.Parse);

            var result = gameNumbers.Intersect(winningNumbers).Aggregate(0, (x, y) => x == 0 ? 1 : x * 2);
            
            results.Add(result);
        }

        System.Console.WriteLine($"{nameof(DayFour)} result: {results.Sum()}");
    }
}