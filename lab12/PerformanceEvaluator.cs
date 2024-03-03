namespace lab12;

public static class PerformanceEvaluator
{
    public static double EvaluateEfficiency(TimeSpan sequentialTime, TimeSpan parallelTime)
    {
        double speedup = sequentialTime.TotalMilliseconds / parallelTime.TotalMilliseconds;
        double efficiency = speedup / Environment.ProcessorCount;
        return efficiency;
    }

    public static double EvaluateAmdahlSpeedup(TimeSpan sequentialTime, TimeSpan parallelTime)
    {
        double P = sequentialTime.TotalMilliseconds / parallelTime.TotalMilliseconds;
        double threadCount = Environment.ProcessorCount;
        double speedupAmdahl = 1 / ((1 - P) + (P / threadCount));
        return speedupAmdahl;
    }

    public static double EvaluateGustafsonSpeedup(TimeSpan sequentialTime, TimeSpan parallelTime)
    {
        double speedupGustafson = sequentialTime.TotalMilliseconds / parallelTime.TotalMilliseconds;
        return speedupGustafson;
    }
}
