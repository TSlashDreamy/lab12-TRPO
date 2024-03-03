namespace lab12;

class Results
{
    public static void DisplayResults(string computationType, double result, TimeSpan timeSpan)
    {
        FormatOutput($"Calculation for {computationType}");
        Console.WriteLine($"{computationType} Scalar product: {result}");
        Console.WriteLine($"{computationType} Execution speed: {timeSpan}\n");
    }

    public static void DisplayEvaluatorResults(double efficiency, double amdahlSpeedup, double gustafsonSpeedup)
    {
        FormatOutput("Efficiency");
        Console.WriteLine(efficiency);
        FormatOutput("Acceleration (Закон Амдала)");
        Console.WriteLine(amdahlSpeedup);
        FormatOutput("Acceleration (Закон Густавсона-Барсіса)");
        Console.WriteLine(gustafsonSpeedup);
    }

    private static void FormatOutput(string word)
    {
        int windowWidth = Console.WindowWidth;

        const int offset = 2;
        int totalLength = windowWidth - word.Length - offset;
        int halfLength = totalLength / 2;

        string line = new string('=', halfLength);
        Console.WriteLine($"{line} {word} {line}");
    }
}
