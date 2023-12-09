using System.Text;
using aoc2023;

public static class DayOne
{
    public static async Task Solve()
    {
        var file = await File.ReadAllLinesAsync($"{nameof(DayOne)}/input.txt");

        var result = 0;

        var numbers = new Dictionary<string, int> 
        { 
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };

        var charList = new StringBuilder();


        foreach (var line in file) 
        {
            int? firstNumber = null;
            int? secondNumber = null;
            charList.Clear();

            for (int i = 0; i < line.Length; i++) 
            {
                var currentChar = line.ElementAtOrDefault(i);

                if ((int)currentChar is >= 48 and <= 57)
                {
                    Helper.SetNumbers(currentChar % 48, ref firstNumber, ref secondNumber);

                    continue;
                }

                charList.Append(currentChar);
                var charCounter = 1;

                do 
                {
                    var nextChar = line.ElementAtOrDefault(i + charCounter);

                    if (nextChar == default)
                    {
                        break;
                    }

                    charList.Append(nextChar);

                    if (numbers.ContainsKey(charList.ToString()))
                    {
                        Helper.SetNumbers(numbers[charList.ToString()], ref firstNumber, ref secondNumber);
                        charList.Clear();
                        
                        break;
                    }

                    charCounter++;
                } while (charCounter < 6);
                
                if (numbers.ContainsKey(charList.ToString()))
                {
                    Helper.SetNumbers(numbers[charList.ToString()], ref firstNumber, ref secondNumber);
                }

                charList.Clear();
            }

            result += firstNumber!.Value * 10 + secondNumber!.Value;
        }

        System.Console.WriteLine($"Result is: {result}");
    }
}