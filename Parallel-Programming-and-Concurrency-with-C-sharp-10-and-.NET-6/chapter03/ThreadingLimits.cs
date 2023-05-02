// This class demonstrates techniques for limiting the number of threads used in parallel processing
public class ThreadingLimitsSample
{
    // Uses Parallel.ForEach to process a list of items, limiting the degree of parallelism to half the processor count
    public void ProcessParallelForEachWithLimits(List<string> items)
    {
        int max = Environment.ProcessorCount > 1 ?
        Environment.ProcessorCount / 2 : 1;
        var options = new ParallelOptions
        {
            MaxDegreeOfParallelism = max
        };
        Parallel.ForEach(items, options, y =>
        {
            // Process items
        });
    }
    // Uses PLINQ to process a list of items, limiting the degree of parallelism to half the processor count,
    // and returns true if any items meet a specific criteria (in this case, if they are not null or whitespace)
    public bool ProcessPlinqWithLimits(List<string> items)
    {
        int max = Environment.ProcessorCount > 1 ? Environment.ProcessorCount / 2 : 1;
        return items.AsParallel()
            .WithDegreeOfParallelism(max)
            .Any(i => CheckString(i));
    }

    // Updates the maximum number of threads available in the thread pool to twice the processor count, or twice the minimum number of threads, whichever is greater
    private void UpdateThreadPoolMax()
    {
        ThreadPool.GetMinThreads(out int workerMin, out int completionMin);
        int workerMax = GetProcessingMax(workerMin);
        int completionMax = GetProcessingMax(completionMin);
        ThreadPool.SetMaxThreads(workerMax, completionMax);
    }

    // Calculates the maximum number of threads to use based on the minimum number of threads available
    private int GetProcessingMax(int min)
    {
        return min < Environment.ProcessorCount ? Environment.ProcessorCount * 2 : min * 2;
    }
}