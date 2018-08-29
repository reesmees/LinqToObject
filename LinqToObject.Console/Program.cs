using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 2, -2, 5, -1, 5, 2, 7, 2, -2, -1, 7, 2, 7, -1};
            List<char> letters = new List<char>() { 'A', 'C', 'G', 'H', 'J', 'A', 'G', 'A' };
            List<string> cities = new List<string>() { "ROME", "LONDON", "NAIROBI", "CALIFORNIA", "ZURICH", "NEW DELHI", "AMSTERDAM", "ABU DHABI", "PARIS" };
            string sentence = "DET her er et STYKKE TEKST med BLANDET casing";
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
        
        public static void RemoveAllSpecificOccurencesMethodSyntax(List<int> number)
        {
            Console.WriteLine("LINQ Method Syntax - Find and remove all occurences of specific numbers in a list");

            number.RemoveAll(n => n % 2 == 1);


        }
    }
}
