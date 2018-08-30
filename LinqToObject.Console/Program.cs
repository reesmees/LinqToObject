using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleData.Entities;
using ExampleData.Factories;

namespace LinqToObject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 2, -2, 5, -1, 5, 2, 7, 2, -2, -1, 7, 2, 7, -1, 4};
            List<char> letters = new List<char>() { 'A', 'C', 'G', 'H', 'J', 'A', 'G', 'A' };
            List<string> cities = new List<string>() { "ROME", "LONDON", "NAIROBI", "CALIFORNIA", "ZURICH", "NEW DELHI", "AMSTERDAM", "ABU DHABI", "PARIS" };
            string sentence = "DET her er et STYKKE TEKST med BLANDET casing";
            List<Bird> birds = BirdFactory.GetDefaultBirds();
            FindNonNegativeNumbersMethodSyntax(numbers);
            FindNonNegativeNumbersQuerySyntax(numbers);
            FindAndCountNumbersMethodSyntax(numbers);
            FindAndCountNumbersQuerySyntax(numbers);
            FindAndCountLettersMethodSyntax(letters);
            FindAndCountLettersQuerySyntax(letters);
            FindWordsThatStartWithNAndEndWithIMethodSyntax(cities);
            FindWordsThatStartWithNAndEndWithIQuerySyntax(cities);
            FindWordsThatAreUpperCaseQuerySyntax(sentence);
            FindWordsThatAreUpperCaseMethodSyntax(sentence);
            CreateListWithBirdNamesQuerySyntax(birds);
            CreateListWithBirdsNamesMethodSyntax(birds);
            CreateListWithDistinctBirdNamesQuerySyntax(birds);
            CreateListWithDistinctBirdNamesMethodSyntax(birds);
            FindAllBlackBirdsMethodSyntax(birds);
            FindAllBlackBirdsQuerySyntax(birds);
            FindBlackBirdWithMostSightingsMethodSyntax(birds);
            FindBlackBirdWithMostSightingsQuerySyntax(birds);
            FindAllBlackAndRedBirdsMethodSyntax(birds);
            FindAllBlackAndRedBirdsQuerySyntax(birds);
            FindBirdWithMostSightingsMethodSyntax(birds);
            FindBirdWithMostSightingsQuerySyntax(birds);
            CreateListOfAllBirdsExceptTheTwoBirdsWithMostSightingsMethodSyntax(birds);
            CreateListOfAllBirdsExceptTheTwoBirdsWithMostSightingsQuerySyntax(birds);
            CreateListOfAnonymousTypesQuerySyntax(birds);
            CreateListOfAnonymousTypesMethodSyntax(birds);
            CheckIfAllBirdsAreBlackMethodSyntax(birds);
            CheckIfAnyBirdIsWhiteMethodSyntax(birds);
            SortBirdsByNameColorAndSightingsMethodSyntax(birds);
            SortBirdsByNameColorAndSightingsQuerySyntax(birds);
            SelectBirdsInAListByNameFromAnotherListMethodSyntax(birds);
            SelectBirdsInAListByNameFromAnotherListQuerySyntax(birds);
            Console.Read();
        }

        public static void FindNonNegativeNumbersQuerySyntax(List<int> numbers)
        {
            Console.WriteLine("LINQ Query Syntax - Find all non-negative numbers in a list");

            var result = from n in numbers
                               where n >= 0
                               select n;
            foreach (var n in result)
            {
                Console.Write($"{n}, ");
            }
            Console.WriteLine("\n");
        }

        public static void FindNonNegativeNumbersMethodSyntax(List<int> numbers)
        {
            Console.WriteLine("LINQ Method Syntax - Find all non-negative numbers in a list");

            var result = numbers.Where(n => n >= 0);

            foreach (var n in result)
            {
                Console.Write($"{n}, ");
            }
            Console.WriteLine("\n");
        }

        public static void FindAndCountNumbersQuerySyntax(List<int> numbers)
        {
            Console.WriteLine("LINQ Query Syntax - Find numbers and count how many occurences of that number are present in a list");

            var groupedResult = from n in numbers
                                group n by n;

            var orderedGroupedResult = from g in groupedResult
                                       orderby g.Key
                                       select g;

            foreach (var nGroup in orderedGroupedResult)
            {
                Console.WriteLine($"Number: {nGroup.Key} Number Of Occurences: {nGroup.Count()}");
            }
            Console.WriteLine("\n");
        }

        public static void FindAndCountNumbersMethodSyntax(List<int> numbers)
        {
            Console.WriteLine("LINQ Method Syntax - Find numbers and count how many occurences of that number are present in a list");

            var groupedResult = numbers.GroupBy(n => n);

            var orderedGroupedResult = groupedResult.OrderBy(g => g.Key);

            foreach (var nGroup in orderedGroupedResult)
            {
                Console.WriteLine($"Number: {nGroup.Key} Number Of Occurences: {nGroup.Count()}");
            }
            Console.WriteLine("\n");
        }

        public static void FindAndCountLettersQuerySyntax(List<char> letters)
        {
            Console.WriteLine("LINQ Query Syntax - Find letters and count the number of occurence of that letter in a list");

            var groupedResult = from l in letters
                                group l by l;

            foreach (var g in groupedResult)
            {
                Console.WriteLine($"Letter: {g.Key} Number of Occurences: {g.Count()}");
            }
            Console.WriteLine("\n");
        }

        public static void FindAndCountLettersMethodSyntax(List<char> letters)
        {
            Console.WriteLine("LINQ Method Syntax - Find letters and count the number of occurence of that letter in a list");

            var groupedResult = letters.GroupBy(l => l);

            foreach (var g in groupedResult)
            {
                Console.WriteLine($"Letter: {g.Key} Number of Occurences: {g.Count()}");
            }
            Console.WriteLine("\n");
        }

        public static void FindWordsThatStartWithNAndEndWithIQuerySyntax(List<string> cities)
        {
            Console.WriteLine("LINQ Query Syntax - Find all words that start with N and end with I in a list");

            var result = from c in cities
                         where c[0] == 'N' && c[c.Length - 1] == 'I'
                         select c;

            foreach (var c in result)
            {
                Console.Write($"{c}, ");
            }
            Console.WriteLine("\n");
        }

        public static void FindWordsThatStartWithNAndEndWithIMethodSyntax(List<string> cities)
        {
            Console.WriteLine("LINQ Method Syntax - Find all words that start with N and end with I in a list");

            var result = cities.Where(c => c[0] == 'N' && c[c.Length - 1] == 'I');

            foreach (var c in result)
            {
                Console.Write($"{c}, ");
            }
            Console.WriteLine("\n");
        }

        public static void FindWordsThatAreUpperCaseQuerySyntax(string sentence)
        {
            Console.WriteLine("LINQ Query Syntax - Find all words in a sentence that are upper case");

            string[] wordArray = sentence.Split(' ');

            var result = from w in wordArray
                         where w == w.ToUpper()
                         select w;

            foreach (var w in result)
            {
                Console.Write($"{w} ");
            }
            Console.WriteLine($"\n");
        }

        public static void FindWordsThatAreUpperCaseMethodSyntax(string sentence)
        {
            Console.WriteLine("LINQ Method Syntax - Find all words in a sentence that are upper case");

            string[] wordArray = sentence.Split(' ');

            var result = wordArray.Where(w => w.All(c => char.IsUpper(c)));

            foreach (var w in result)
            {
                Console.Write($"{w} ");
            }
            Console.WriteLine($"\n");
        }
        
        public static void RemoveAllSpecificOccurencesMethodSyntax(List<int> numbers)
        {
            Console.WriteLine("LINQ Method Syntax - Find and remove all occurences of specific numbers in a list");

            numbers.RemoveAll(n => n % 2 == 1 || n % 2 == -1);

            foreach (var n in numbers)
            {
                Console.Write($"{n} ");
            }
            Console.WriteLine($"\n");
        }

        public static void RemoveAllSpecificOccurencesQuerySyntax(List<int> numbers)
        {
            Console.WriteLine("LINQ Query Syntax - Find and remove all occurences of specific numbers in a list");

            var toRemove = from n in numbers
                           where n % 2 == 1 || n % 2 == -1
                           select n;

            numbers.RemoveAll(n => toRemove.Contains(n));

            foreach (var n in numbers)
            {
                Console.Write($"{n} ");
            }
            Console.WriteLine($"\n");
        }

        public static void CreateListWithBirdNamesQuerySyntax(List<Bird> birds)
        {
            Console.WriteLine("LINQ Query Syntax - Create list of all bird names");

            var birdNames = from b in birds
                            select b.Name;

            foreach (var b in birdNames)
            {
                Console.Write($"{b} ");
            }
            Console.WriteLine($"\n");
        }

        public static void CreateListWithBirdsNamesMethodSyntax(List<Bird> birds)
        {
            Console.WriteLine("LINQ Method Syntax - Create list of all bird names");

            var birdNames = birds.Select(b => b.Name);

            foreach (var b in birdNames)
            {
                Console.Write($"{b} ");
            }
            Console.WriteLine($"\n");
        }

        public static void CreateListWithDistinctBirdNamesQuerySyntax(List<Bird> birds)
        {
            Console.WriteLine("LINQ Query Syntax - Create list of all distinct bird names");

            var birdNames = (from b in birds
                             select b.Name).Distinct();

            foreach (var b in birdNames)
            {
                Console.Write($"{b} ");
            }
            Console.WriteLine($"\n");
        }

        public static void CreateListWithDistinctBirdNamesMethodSyntax(List<Bird> birds)
        {
            Console.WriteLine("LINQ Method Syntax - Create list of all distinct bird names");

            var birdNames = birds.Select(b => b.Name).Distinct();

            foreach (var b in birdNames)
            {
                Console.Write($"{b} ");
            }
            Console.WriteLine($"\n");
        }

        public static void FindAllBlackBirdsMethodSyntax(List<Bird> birds)
        {
            Console.WriteLine("LINQ Method Syntax - Find all black birds in a list");

            var blackBirds = birds.Where(b => b.Color == "Sort");

            foreach (var bird in blackBirds)
            {
                Console.WriteLine($"Navn: {bird.Name}, Farve: {bird.Color}, Antal gange set: {bird.Sightings}");
            }
            Console.WriteLine($"\n");
        }

        public static void FindAllBlackBirdsQuerySyntax(List<Bird> birds)
        {
            Console.WriteLine("LINQ Query Syntax - Find all black birds in a list");

            var blackBirds = from b in birds
                             where b.Color == "Sort"
                             select b;

            foreach (var bird in blackBirds)
            {
                Console.WriteLine($"Navn: {bird.Name}, Farve: {bird.Color}, Antal gange set: {bird.Sightings}");
            }
            Console.WriteLine($"\n");
        }

        public static void FindBlackBirdWithMostSightingsMethodSyntax(List<Bird> birds)
        {
            Console.WriteLine("LINQ Method Syntax - Find black bird with most sightings in a list");

            var bird = birds.Where(b => b.Color == "Sort").OrderByDescending(b => b.Sightings).FirstOrDefault();

            Console.WriteLine($"Navn: {bird.Name}, Farve: {bird.Color}, Antal gange set: {bird.Sightings}");
            Console.WriteLine($"\n");
        }

        public static void FindBlackBirdWithMostSightingsQuerySyntax(List<Bird> birds)
        {
            Console.WriteLine("LINQ Query Syntax - Find black bird with most sightings in a list");

            var bird = (from b in birds
                        where b.Color == "Sort"
                        orderby b.Sightings descending
                        select b).First();

            Console.WriteLine($"Navn: {bird.Name}, Farve: {bird.Color}, Antal gange set: {bird.Sightings}");
            Console.WriteLine($"\n");
        }

        public static void FindAllBlackAndRedBirdsMethodSyntax(List<Bird> birds)
        {
            Console.WriteLine("LINQ Method Syntax - Find all black and red birds in a list");

            var blackAndRedBirds = birds.Where(b => b.Color == "Sort" || b.Color == "Rød");

            foreach (var bird in blackAndRedBirds)
            {
                Console.WriteLine($"Navn: {bird.Name}, Farve: {bird.Color}, Antal gange set: {bird.Sightings}");
            }
            Console.WriteLine($"\n");
        }

        public static void FindAllBlackAndRedBirdsQuerySyntax(List<Bird> birds)
        {
            Console.WriteLine("LINQ Query Syntax - Find all black and red birds in a list");

            var blackAndRedBirds = from b in birds
                                   where b.Color == "Sort" || b.Color == "Rød"
                                   select b;

            foreach (var bird in blackAndRedBirds)
            {
                Console.WriteLine($"Navn: {bird.Name}, Farve: {bird.Color}, Antal gange set: {bird.Sightings}");
            }
            Console.WriteLine($"\n");
        }

        public static void FindBirdWithMostSightingsMethodSyntax(List<Bird> birds)
        {
            Console.WriteLine("LINQ Method Syntax - Find the bird with most sightings in a list");

            var bird = birds.OrderByDescending(b => b.Sightings).First();

            Console.WriteLine($"Navn: {bird.Name}, Farve: {bird.Color}, Antal gange set: {bird.Sightings}");
            Console.WriteLine($"\n");
        }

        public static void FindBirdWithMostSightingsQuerySyntax(List<Bird> birds)
        {
            Console.WriteLine("LINQ Query Syntax - Find the bird with most sightings in a list");

            var bird = (from b in birds
                        orderby b.Sightings descending
                        select b).First();

            Console.WriteLine($"Navn: {bird.Name}, Farve: {bird.Color}, Antal gange set: {bird.Sightings}");
            Console.WriteLine($"\n");
        }

        public static void CreateListOfAllBirdsExceptTheTwoBirdsWithMostSightingsMethodSyntax(List<Bird> birds)
        {
            Console.WriteLine("LINQ Method Syntax - Create a new list with all of the birds in a list, except the two birds with the most sightings");

            var result = birds.OrderByDescending(b => b.Sightings).Skip(2);

            foreach (var bird in result)
            {
                Console.WriteLine($"Navn: {bird.Name}, Farve: {bird.Color}, Antal gange set: {bird.Sightings}");
            }
            Console.WriteLine($"\n");
        }

        public static void CreateListOfAllBirdsExceptTheTwoBirdsWithMostSightingsQuerySyntax(List<Bird> birds)
        {
            Console.WriteLine("LINQ Query Syntax - Create a new list with all of the birds in a list, except the two birds with the most sightings");

            var result = (from b in birds
                          orderby b.Sightings descending
                          select b).Skip(2);

            foreach (var bird in result)
            {
                Console.WriteLine($"Navn: {bird.Name}, Farve: {bird.Color}, Antal gange set: {bird.Sightings}");
            }
            Console.WriteLine($"\n");
        }

        public static void CreateListOfAnonymousTypesQuerySyntax(List<Bird> birds)
        {
            Console.WriteLine("LINQ Query Syntax - Create list of anonymous types from list of birds");

            var result = from b in birds
                         select new
                         {
                             birdName = b.Name,
                             birdColor = b.Color
                         };

            foreach (var b in result)
            {
                Console.WriteLine($"Navn: {b.birdName}, Farve: {b.birdColor}");
            }
            Console.WriteLine($"\n");
        }

        public static void CreateListOfAnonymousTypesMethodSyntax(List<Bird> birds)
        {
            Console.WriteLine("LINQ Method Syntax - Create list of anonymous types from list of birds");

            var result = birds.Select(b => new { birdName = b.Name, birdColor = b.Color });

            foreach (var b in result)
            {
                Console.WriteLine($"Navn: {b.birdName}, Farve: {b.birdColor}");
            }
            Console.WriteLine($"\n");
        }

        public static void CheckIfAllBirdsAreBlackMethodSyntax(List<Bird> birds)
        {
            Console.WriteLine("LINQ Method Syntax - Check if all birds in a list are black");

            var result = birds.All(b => b.Color == "Sort");

            Console.WriteLine(result);
            Console.WriteLine($"\n");
        }

        public static void CheckIfAnyBirdIsWhiteMethodSyntax(List<Bird> birds)
        {
            Console.WriteLine("LINQ Method Syntax - Check if any bird in a list is white");

            var result = birds.Any(b => b.Color == "Hvid");

            Console.WriteLine(result);
            Console.WriteLine($"\n");
        }

        public static void SortBirdsByNameColorAndSightingsMethodSyntax(List<Bird> birds)
        {
            Console.WriteLine("LINQ Method Syntax - Sort birds by name, color, and sightings");

            var sortedBirds = birds.OrderBy(b => b.Name).ThenBy(b => b.Color).ThenBy(b => b.Sightings);

            foreach (var bird in sortedBirds)
            {
                Console.WriteLine($"Navn: {bird.Name}, Farve: {bird.Color}, Antal gange set: {bird.Sightings}");
            }
            Console.WriteLine($"\n");
        }

        public static void SortBirdsByNameColorAndSightingsQuerySyntax(List<Bird> birds)
        {
            Console.WriteLine("LINQ Query Syntax - Sort birds by name, color, and sightings");

            var sortedBirds = from b in birds
                              orderby b.Sightings
                              orderby b.Color
                              orderby b.Name
                              select b;

            foreach (var bird in sortedBirds)
            {
                Console.WriteLine($"Navn: {bird.Name}, Farve: {bird.Color}, Antal gange set: {bird.Sightings}");
            }
            Console.WriteLine($"\n");
        }

        public static void SelectBirdsInAListByNameFromAnotherListMethodSyntax(List<Bird> birds)
        {
            Console.WriteLine("LINQ Method Syntax - Select birds from a list by the names from another list");

            List<string> names = new List<string>() { "Solsort", "Krage", "Måge" };

            var result = birds.Join(names, b => b.Name, n => n, (b, n) => b);

            foreach (var bird in result)
            {
                Console.WriteLine($"Navn: {bird.Name}, Farve: {bird.Color}, Antal gange set: {bird.Sightings}");
            }
            Console.WriteLine($"\n");
        }

        public static void SelectBirdsInAListByNameFromAnotherListQuerySyntax(List<Bird> birds)
        {
            Console.WriteLine("LINQ Query Syntax - Select birds from a list by the names from another list");

            List<string> names = new List<string>() { "Solsort", "Krage", "Måge" };

            var result = from b in birds
                         join n in names
                         on b.Name equals n
                         select b;

            foreach (var bird in result)
            {
                Console.WriteLine($"Navn: {bird.Name}, Farve: {bird.Color}, Antal gange set: {bird.Sightings}");
            }
            Console.WriteLine($"\n");
        }
    }
}
