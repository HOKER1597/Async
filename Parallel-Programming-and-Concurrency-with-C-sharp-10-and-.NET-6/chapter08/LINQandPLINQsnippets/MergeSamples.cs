namespace LINQandPLINQsnippets
{
    internal class MergeSamples
    {
        internal IEnumerable<Person> GetImportantChildrenNoMergeSpecified(List<Person> people)
        {
            // This method doesn't specify a merge option, so PLINQ will use the default behavior.
            // The query returns up to three important children who are under 18, executing in parallel.
            return people.AsParallel()
            .Where(p => p.IsImportant && p.Age < 18).Take(3);
        }

        internal IEnumerable<Person> GetImportantChildrenDefaultMerge(List<Person> people)
        {
            // This method sets the merge option to ParallelMergeOptions.Default.
            // PLINQ will use the default merge behavior, which may be different from the no-merge-specified behavior.
            // The query returns up to three important children who are under 18, executing in parallel.
            return people.AsParallel().WithMergeOptions(ParallelMergeOptions.Default)
                .Where(p => p.IsImportant && p.Age < 18).Take(3);
        }

        internal IEnumerable<Person> GetImportantChildrenAutoBuffered(List<Person> people)
        {
            // This method sets the merge option to ParallelMergeOptions.AutoBuffered.
            // PLINQ will execute the query in parallel and buffer intermediate results as necessary.
            // The query returns up to three important children who are under 18.
            return people.AsParallel().WithMergeOptions(ParallelMergeOptions.AutoBuffered)
                .Where(p => p.IsImportant && p.Age < 18).Take(3);
        }

        internal IEnumerable<Person> GetImportantChildrenNotBuffered(List<Person> people)
        {
            // This method sets the merge option to ParallelMergeOptions.NotBuffered.
            // PLINQ will execute the query in parallel and not buffer intermediate results.
            // The query may return fewer than three important children who are under 18.
            return people.AsParallel().WithMergeOptions(ParallelMergeOptions.NotBuffered)
                .Where(p => p.IsImportant && p.Age < 18).Take(3);
        }

        internal IEnumerable<Person> GetImportantChildrenFullyBuffered(List<Person> people)
        {
            // This method sets the merge option to ParallelMergeOptions.FullyBuffered.
            // PLINQ will execute the query in parallel and fully buffer intermediate results.
            // The query returns up to three important children who are under 18.
            return people.AsParallel().WithMergeOptions(ParallelMergeOptions.FullyBuffered)
                .Where(p => p.IsImportant && p.Age < 18).Take(3);
        }
    }
}