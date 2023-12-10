using System.ComponentModel.DataAnnotations;
using System.Text;
using aoc2023;


public static class DayThree
{
    public static async Task Solve()
    {
        var file = await File.ReadAllLinesAsync($"{nameof(DayThree)}/input.txt");
        var results = new List<int>();

        for (var i = 0; i < file.Length; i++)
        {
            var previousLine = file.ElementAtOrDefault(i - 1);
            var currentLine = file.ElementAtOrDefault(i);
            var nextLine = file.ElementAtOrDefault(i + 1);

            for (var j = 0; j < currentLine!.Length; j++)
            {
                if (currentLine[j] != '*')
                {
                    continue;
                }

                var numbers = new List<int?>();

                if (char.IsDigit(currentLine.ElementAtOrDefault(j - 1)))
                {
                    numbers.Add(ReadNumberRtl(currentLine, j - 1));
                }

                if (char.IsDigit(currentLine.ElementAtOrDefault(j + 1)))
                {
                    numbers.Add(ReadNumberLtr(currentLine, j + 1));
                }

                if (previousLine is not null)
                {
                    numbers.AddRange(GetNumbers(previousLine!, j));
                }

                if (nextLine is not null)
                {
                    numbers.AddRange(GetNumbers(nextLine!, j));
                }

                numbers = numbers.Where(x => x.HasValue).ToList();
                
                if (numbers.Count == 2)
                {          
                    results.Add(numbers.First()!.Value * numbers.Skip(1).First()!.Value);
                }
            }
        }

        System.Console.WriteLine($"{nameof(DayThree)} result: {results.Sum()}");
    }

    public static List<int?> GetNumbers(string line, int gearPosition)
    {
        var beforeGear = line.ElementAtOrDefault(gearPosition - 1);
        var atGear = line.ElementAtOrDefault(gearPosition);
        var afterGear = line.ElementAtOrDefault(gearPosition + 1);
        var result = new List<int?>();

        if (char.IsDigit(beforeGear) && char.IsDigit(atGear) && char.IsDigit(afterGear))
        {
            result.Add(ReadNumberLtr(line, gearPosition - 1));
        }

        if (char.IsDigit(beforeGear) && char.IsDigit(atGear) is false && char.IsDigit(afterGear) is false)
        {
            result.Add(ReadNumberRtl(line, gearPosition - 1));
        }

        if (char.IsDigit(beforeGear) && char.IsDigit(atGear) && char.IsDigit(afterGear) is false)
        {
            result.Add(ReadNumberRtl(line, gearPosition));
        }

        if (char.IsDigit(beforeGear) is false && char.IsDigit(atGear) && char.IsDigit(afterGear))
        {
            result.Add(ReadNumberLtr(line, gearPosition));
        }

        if (char.IsDigit(beforeGear) is false && char.IsDigit(atGear) is false && char.IsDigit(afterGear))
        {
            result.Add(ReadNumberLtr(line, gearPosition + 1));
        }

        if (char.IsDigit(beforeGear) && char.IsDigit(atGear) is false && char.IsDigit(afterGear))
        {
            result.Add(ReadNumberRtl(line, gearPosition - 1));
            result.Add(ReadNumberLtr(line, gearPosition + 1));
        }

        return result;
    }

    private static int ReadNumberRtl(string line, int startingPosition)
    {
        var result = new List<char>();

        for (var i = startingPosition; i >= 0; i--)
        {
            if (char.IsDigit(line[i]))
            {
                result.Add(line[i]);

                continue;
            }

            break;
        }

        result.Reverse();

        return int.Parse(result.ToArray());
    }

    private static int ReadNumberLtr(string line, int startingPosition)
    {
        var result = new List<char>();

        for (var i = startingPosition; i < line.Length; i++)
        {
            if (char.IsDigit(line[i]))
            {
                result.Add(line[i]);

                continue;
            }

            break;
        }

        return int.Parse(result.ToArray());
    }
}


