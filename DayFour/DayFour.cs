using System.ComponentModel.DataAnnotations;
using System.Text;
using aoc2023;


public static class DayFour
{
    public static async Task Solve()
    {
        var file = await File.ReadAllLinesAsync($"{nameof(DayFour)}/input.txt");
        var result = 0;
        var duplicates = new Dictionary<int, int>();

        for (var i = 0; i < file.Length; i++)
        {
            var matchCount = GetMatchCount(file[i]);
            var filled = FillDuplicates(duplicates, i, file.Length, matchCount);
            
            result += filled + 1;
        }

        do 
        {
            for (var i = 0; i <= file.Length; i++)
            {
                if (duplicates.TryGetValue(i, out var count) is false || count == 0)
                {
                    continue;
                }

                foreach (var j in Enumerable.Range(1, count))
                {
                    var matchCount = GetMatchCount(file[i]);
                    var filled = FillDuplicates(duplicates, i, file.Length, matchCount);
                
                    result += filled;
                }
                
                duplicates[i] = 0;
            }
        } while (duplicates.Sum(x => x.Value) > 0);


        System.Console.WriteLine($"{nameof(DayFour)} result: {result}");
    }

    private static int GetMatchCount(string row)
    {
        var cardSplit = row.Split(":");
        var gameSplit = cardSplit[1].Split("|");
        
        var winningNumbers = gameSplit[0].Trim().Split(" ").Where(x => x != string.Empty).Select(int.Parse);
        var gameNumbers = gameSplit[1].Trim().Split(" ").Where(x => x != string.Empty).Select(int.Parse);

        return gameNumbers.Intersect(winningNumbers).Count();
    }

    private static int FillDuplicates(Dictionary<int, int> duplicates, int currentLine, int lineCount, int matchCount)
    {
        var result = 0;

        for (var j = 0; j < matchCount; j++)
        {
            var idx = currentLine + j + 1;
            
            if (idx > lineCount)
            {
                continue;
            }

            if (duplicates.ContainsKey(idx) is false)
            {
                duplicates[idx] = 0;
            }

            duplicates[idx]++;
            result++;
        }

        return result;
    }
}