namespace LINQandPLINQsnippets
{
    internal class LinqSnippets
    {
        // Method to query a list of cities that start with "S" and "T"
        internal void QueryCities(List<string> cities)
        {
            // Query is executed with ToList call
            List<string> citiesWithS = cities.Where(s => s.StartsWith('S')).ToList();

            // Query is not executed here
            IEnumerable<string> citiesWithT = cities.Where(s => s.StartsWith('T'));

            // Query is executed here when enumerating
            foreach (string city in citiesWithT)
            {
                // Do something with citiesWithT
            }
        }

        // Method to query a list of people and group them by last name if their age is over 17
        internal void QueryAndGroupPeople(List<Person> people)
        {
            var results = people.AsParallel().Where(p => p.Age > 17)
                .AsSequential().GroupBy(p => p.LastName);
            foreach (var group in results)
            {
                Console.WriteLine($"Last name {group.Key} has {group.Count()} people.");
            }
            // Sample output:
            // Last name Jones has 4220 people.
            // Last name Xu has 3434 people.
            // Last name Patel has 4798 people.
            // Last name Smith has 3051 people.
            // Last name Sanchez has 3811 people.
            // ...
        }

        // Method to demonstrate the query syntax and method syntax in LINQ
        internal void QuerySyntaxAndMethodSyntax(List<Person> people)
        {
            var peopleQuery1 = people.AsParallel().Where(p => p.Age > 17);

            var peopleQuery2 = from person in people.AsParallel()
                               where person.Age > 17
                               select person;
        }

        // Method to query a list of people whose last name starts with "H" in parallel, maintaining the order
        internal void QueryOrderedPeople(List<Person> people)
        {
            var results = people.AsParallel().AsOrdered()
                .Where(p => p.LastName.StartsWith("H"));
        }

        // Method to query a list of people whose last name starts with "H" in parallel, without maintaining the order
        internal void QueryUnorderedPeople(List<Person> people)
        {
            var results = people.AsParallel().AsUnordered()
                .Where(p => p.LastName.StartsWith("H"));
        }

        // Method to process a list of adults who can vote
        internal void ProcessAdultsWhoVote(List<Person> people)
        {
            foreach (var person in people)
            {
                if (person.Age < 18) continue;
                ProcessVoterActions(person);
            }
        }
        private void ProcessVoterActions(Person adult)
        {
            // Add adult to a voter database and process their data.
        }

        // Method to process a list of adults who can vote in parallel using Parallel.ForEach
        internal void ProcessAdultsWhoVoteInParallel(List<Person> people)
        {
            var adults = people.Where(p => p.Age > 17);
            Parallel.ForEach(adults, ProcessVoterActions);
        }

        // Method to process a list of adults who can vote in parallel using PLINQ's ForAll method
        internal void ProcessAdultsWhoVoteWithPlinq(List<Person> people)
        {
            var adults = people.AsParallel().Where(p => p.Age > 17);
            adults.ForAll(ProcessVoterActions);
        }
    }
}
