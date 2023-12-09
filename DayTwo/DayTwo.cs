using System.Text;
using aoc2023;


public static class DayTwo
{
    public static async Task Solve()
    {
        var file = await File.ReadAllLinesAsync($"{nameof(DayTwo)}/input.txt");
        var results = new List<int>();
        

        foreach (var line in file) 
        {
            var result = 1;
            var cubesInSets = new Dictionary<string, List<int>> {
                { "red", new List<int> () },
                { "green", new List<int> () }, 
                { "blue", new List<int> () }
            };

            var gameSplit = line.Split(":");
            var gameId = int.Parse(gameSplit[0].Replace("Game ", string.Empty));
            var sets = gameSplit[1].Split(";");
            
            foreach (var set in sets)
            {
                var cubes = set.Split(",").Select(x => x.TrimStart());

                foreach (var cube in cubes)
                {
                    var cubeSplit = cube.Split(" ");

                    cubesInSets[cubeSplit[1]].Add(int.Parse(cubeSplit[0]));
                }
            }

            foreach (var item in cubesInSets)
            {
                result *= item.Value.Max();
            }
            
            results.Add(result);
        }

        System.Console.WriteLine($"Day Two result: {results.Sum()}");
    }
}


