using lab12;
using System.Text;

Console.OutputEncoding = Console.InputEncoding = Encoding.Unicode;

// n1 = 15, n2 = 30 (кількість ітерацій)
int dataLength = 100000; // Кількість ітерацій для обчислення скалярного добутку (test)
double sequentialResult = 0;
double parallelResult = 0;

// Оцінка тривалості послідовного обчислення
TimeSpan sequentialTimeSpan = SequentialComputation.MeasureTime(dataLength, ref sequentialResult);

// Оцінка тривалості паралельного обчислення
TimeSpan parallelTimeSpan = ParallelComputation.MeasureTime(dataLength, ref parallelResult);

// Оцінка ефективності реалізованих паралельних алгоритмів
double efficiency = PerformanceEvaluator.EvaluateEfficiency(sequentialTimeSpan, parallelTimeSpan);

// Оцінка максимального прискорення законом Амдала
double amdahlSpeedup = PerformanceEvaluator.EvaluateAmdahlSpeedup(sequentialTimeSpan, parallelTimeSpan);

// Оцінка максимального прискорення законом Густавсона-Барсіса
double gustafsonSpeedup = PerformanceEvaluator.EvaluateGustafsonSpeedup(sequentialTimeSpan, parallelTimeSpan);

// Виведення результатів про швидкість послідовного, паралельного обчислення, ефективності реалізованих паралельних алгоритмів, максимального прискорення законом Амдала, та максимального прискорення законом Густавсона-Барсіса
Console.Clear();
Results.DisplayResults("Sequential", sequentialResult, sequentialTimeSpan);
Results.DisplayResults("Parallel", parallelResult, parallelTimeSpan);
Results.DisplayEvaluatorResults(efficiency, amdahlSpeedup, gustafsonSpeedup);