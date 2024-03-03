using System.Diagnostics;

namespace lab12;

class SequentialComputation
{
    public static TimeSpan MeasureTime(int dataLength, ref double result)
    {
        Console.Clear();
        Console.WriteLine($"Calculating measure time for {dataLength} iterations (Sequential Computation)...");

        Stopwatch stopwatch = Stopwatch.StartNew();
        CalculateResult(dataLength, ref result);
        stopwatch.Stop();

        Console.Clear();
        Console.WriteLine("Sequential Computation DONE!");

        // Adding a slight delay to ensure information is stored appropriately
        Thread.Sleep(1000);

        return stopwatch.Elapsed;
    }

    private static void CalculateResult(int dataLength, ref double result)
    {
        for (int i = 1; i <= dataLength; i++)
        {
            double varA = CalculateAi(i);
            double varB = CalculateBi(i);
            result += varA * varB;
        }
    }

    public static int Factorial(int n)
    {
        // recursion will call stack overflow, so "for" cycle is more suitable
        int result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    public static double CalculateAi(int i)
    {
        return Math.Pow(1.67, i) * (Math.Pow(i, 2) / Factorial(i));
    }

    public static double CalculateBi(int i)
    {
        return (1 / (i * (i + 1))) - (Math.Cos(i) / Math.Pow(Math.E, i)) + 1;
    }
}
