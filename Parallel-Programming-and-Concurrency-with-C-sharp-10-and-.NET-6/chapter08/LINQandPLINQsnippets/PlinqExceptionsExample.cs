// This namespace contains examples of LINQ and PLINQ snippets.
namespace LINQandPLINQsnippets
{
    // This class demonstrates how to handle exceptions that might occur 
    // while processing voters with PLINQ.
    internal class PlinqExceptionsExample
    {
        // This method processes adults who are eligible for voting using PLINQ.
        // It catches AggregateException to handle any exceptions that might occur.
        internal void ProcessAdultsWhoVoteWithPlinq(List<Person> people)
        {
            try
            {
                var adults = people.AsParallel().Where(p => p.Age > 17);
                adults.ForAll(ProcessVoterActions);
            }
            catch (AggregateException ae)
            {
                foreach (var ex in ae.InnerExceptions)
                {
                    Console.WriteLine($"Exception encountered while processing voters. Message: {ex.Message}");
                }
            }
        }
        
        // This method processes an adult voter.
        // It throws an ArgumentException if the adult is too old.
        // Otherwise, it adds the adult to a voter database and processes their data.
        private void ProcessVoterActions(Person adult)
        {
            if (adult.Age > 120)
            {
                throw new ArgumentException("This person is too old!", nameof(adult));
            }
            // Add adult to a voter database and process their data.
        }
        
        private SpinLock _spinLock = new SpinLock();
        
        // This method processes adults who are eligible for voting using PLINQ.
        // It uses a SpinLock to ensure that only one thread can access the age property of a voter at a time.
        // It sets the age of any voter who is too old to 120 without throwing an exception.
        internal void ProcessAdultsWhoVoteWithPlinq2(List<Person> people)
        {
            var adults = people.AsParallel().Where(p => p.Age > 17);
            adults.ForAll(ProcessVoterActions2);
        }
        
        // This method processes an adult voter.
        // It updates the age of any voter who is too old to 120 using a SpinLock.
        private void ProcessVoterActions2(Person adult)
        {
            var hasLock = false;
            if (adult.Age > 120)
            {
                try
                {
                    _spinLock.Enter(hasLock);
                    adult.Age = 120;
                }
                finally
                {
                    if (hasLock) _spinLock.Exit();
                }
            }
        } 
    }
}