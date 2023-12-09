var file = await System.IO.File.ReadAllLinesAsync("input.txt");

var result = 0;

foreach (var line in file) 
{
    int? firstNumber = null;
    int? secondNumber = null;

    foreach (int @char in line) 
    {
        if (@char is >= 48 and <= 57)
        {
            if (firstNumber.HasValue is false)
            {
                firstNumber = @char % 48;
                secondNumber = @char % 48;
            }
            else
            {
                secondNumber = @char % 48;
            }
        }
    }

    result += firstNumber!.Value * 10 + secondNumber!.Value;
}

System.Console.WriteLine($"Result is: {result}");