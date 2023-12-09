using System.Text;
using aoc2023;


public static class DayTwo
{
    public static async Task Solve()
    {
        var file = await File.ReadAllLinesAsync("2/input.txt");
        var result = new List<int>();
        var cubeCounts = new Dictionary<string, int> {
            { "red", 12 },
            { "green", 13 }, 
            { "blue", 14 }
        };

        foreach (var line in file) 
        {
            var gameSplit = line.Split(":");
            var gameId = int.Parse(gameSplit[0].Replace("Game ", string.Empty));
            var sets = gameSplit[1].Split(";");
            var isViable = true;
            
            foreach (var set in sets)
            {
                var cubes = set.Split(",").Select(x => x.TrimStart());

                foreach (var cube in cubes)
                {
                    var cubeSplit = cube.Split(" ");
                    var cubeCount = cubeCounts[cubeSplit[1]];

                    if (int.Parse(cubeSplit[0]) > cubeCount)
                    {
                        isViable = false;
                        break;
                    }
                }

                if (isViable is false)
                {
                    break;
                }
            }

            if (isViable)
            {
                result.Add(gameId);
            }
        }

        System.Console.WriteLine($"Day Two result: {result.Sum()}");
    }
}


