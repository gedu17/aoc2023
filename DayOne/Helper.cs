namespace aoc2023;

public static class Helper 
{
    public static void SetNumbers(int value, ref int? firstNumber, ref int? secondNumber)
    {
        if (firstNumber.HasValue is false)
        {
            firstNumber = value;
            secondNumber = value;

            return;
        }
        
        secondNumber = value;
    }
}