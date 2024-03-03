using System.Diagnostics;

namespace lab12;

class ParallelComputation
{
    public static TimeSpan MeasureTime(int dataLength, ref double result)
    {
        Console.Clear();
        Console.WriteLine($"Calculating measure time for {dataLength} iterations (Parallel Computation)...");

        Stopwatch stopwatch = Stopwatch.StartNew();
        double partialResult = 0;
        object lockObject = new object();

        Parallel.For(1, dataLength + 1,
            () => 0.0, // Initialize localPartialResult
            (i, loopState, localPartialResult) =>
        {
            double varA = SequentialComputation.CalculateAi(i);
            double varB = SequentialComputation.CalculateBi(i);
            return localPartialResult + varA * varB;
        }, (localPartialResult) =>
        {
            lock (lockObject)
            {
                partialResult += localPartialResult;
            }
        });
        stopwatch.Stop();

        Console.Clear();
        Console.WriteLine("Parallel Computation DONE!");

        // Adding a slight delay to ensure information is stored appropriately
        Task.Delay(1000).Wait();

        result = partialResult; // Update result after parallel computation
        return stopwatch.Elapsed;
    }
}
