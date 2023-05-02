// This is a namespace called LINQandPLINQsnippets
namespace LINQandPLINQsnippets
{
    // This is a class called OrderSamples
    internal class OrderSamples
    {
        // This is a method called GetImportantChildrenNoOrder that takes in a List<Person> object called people and returns an IEnumerable<Person> object
        // The method uses LINQ to find all people that are marked as important and are under the age of 18, and returns them with no specific order
        internal IEnumerable<Person> GetImportantChildrenNoOrder(List<Person> people)
        {
            return people.AsParallel()
                .Where(p => p.IsImportant && p.Age < 18);
        }

        // This is a method called GetImportantChildrenUnordered that takes in a List<Person> object called people and returns an IEnumerable<Person> object
        // The method uses PLINQ to find all people that are marked as important and are under the age of 18, and returns them in an unordered list
        internal IEnumerable<Person> GetImportantChildrenUnordered(List<Person> people)
        {
             return people.AsParallel().AsUnordered()
                .Where(p => p.IsImportant && p.Age < 18);
        }

        // This is a method called GetImportantChildrenUnknownOrder that takes in a List<Person> object called people and returns an IEnumerable<Person> object
        // The method uses PLINQ to find all people that are marked as important and are under the age of 18, but it uses AsSequential when checking for age and thus the order is unknown
        internal IEnumerable<Person> GetImportantChildrenUnknownOrder(List<Person> people)
        {
            return people.AsParallel().Where(p => p.IsImportant)
                .AsSequential().Where(p => p.Age < 18);
        }

        // This is a method called GetImportantChildrenPreserveOrder that takes in a List<Person> object called people and returns an IEnumerable<Person> object\n        // The method uses PLINQ to find all people that are marked as important and are under the age of 18, and returns them in the original order of the list
        internal IEnumerable<Person> GetImportantChildrenPreserveOrder(List<Person> people)
        {
            return people.AsParallel().AsOrdered()
                .Where(p => p.IsImportant && p.Age < 18);
        }

        // This is a method called GetImportantChildrenReverseOrder that takes in a List<Person> object called people and returns an IEnumerable<Person> object
        // The method uses PLINQ to find all people that are marked as important and are under the age of 18, and returns them in reverse order of the original list
        internal IEnumerable<Person> GetImportantChildrenReverseOrder(List<Person> people)
        {
            return people.AsParallel().AsOrdered().Reverse()
                .Where(p => p.IsImportant && p.Age < 18);
        }
    }
}