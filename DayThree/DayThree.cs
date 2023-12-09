using System.Text;
using aoc2023;


public static class DayThree
{
    public static async Task Solve()
    {
        var file = await File.ReadAllLinesAsync($"{nameof(DayThree)}/input.txt");
        var results = new List<int>();
        var charList = new List<char>();

        for (var i = 0; i < file.Length; i++)
        {
            var previousLine = file.ElementAtOrDefault(i - 1);
            var currentLine = file.ElementAtOrDefault(i);
            var nextLine = file.ElementAtOrDefault(i + 1);
            charList.Clear();
            int? numberStartedAt = null;

            for (var j = 0; j < currentLine!.Length; j++)
            {
                if ((int)currentLine[j] is >= 48 and <= 57)
                {
                    charList.Add(currentLine[j]);

                    numberStartedAt ??= j;

                    if (currentLine.ElementAtOrDefault(j + 1) != default)
                    {
                        continue;
                    }
                }

                if (charList.Count == 0) 
                {
                    continue;
                }

                var symbolsAround = new List<char>();

                // symbolOnTheLeft
                if (numberStartedAt!.Value > 0)
                {
                    symbolsAround.Add(currentLine.ElementAtOrDefault(numberStartedAt!.Value - 1));
                }

                // symbolOnTheRight
                if (currentLine.ElementAtOrDefault(j + 1) != default)
                {
                    symbolsAround.Add(currentLine.ElementAtOrDefault(j));
                }

                // symbolsAbove
                symbolsAround.AddRange(previousLine?[(numberStartedAt!.Value > 0 ? numberStartedAt!.Value - 1 : 0)..(j + 1)]?.ToCharArray() ?? []);
                // symbolsBelow
                symbolsAround.AddRange(nextLine?[(numberStartedAt!.Value > 0 ? numberStartedAt!.Value - 1 : 0)..(j + 1)]?.ToCharArray() ?? []);
                symbolsAround.RemoveAll(x => x == '.');

                if (symbolsAround.Any(x => char.IsAsciiDigit(x) is false))
                {
                    results.Add(int.Parse(charList.ToArray()));
                }

                charList.Clear();
                numberStartedAt = null;
            }
        }

        System.Console.WriteLine($"{nameof(DayThree)} result: {results.Sum()}");
    }
}


