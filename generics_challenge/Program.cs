using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


//Create a method that takes in two List<T> lists, intermixes them, and then returns a new list.Alternate
//pulling items from each list starting with the bigger
//list. Make sure the method can take in any List<T>.
//Create another generics method that takes in two
//generic objects (of the same or different types). Make
//sure each object that is passed in has a Title property
//in it. Return the object with the longer title.

namespace generics_challenge
{
    internal class Program
    {
        private static List<T> MixLists<T>(List<T> firstList, List<T> secondList) 
        {
            List<T> output;

            output = (firstList.Count > secondList.Count)
                ? firstList.Concat(secondList).ToList()
                : secondList.Concat(firstList).ToList();

            return output;
        }

        private static IHaveTitle GetLongerTitle<T, U>(T firstList, U secondList) where T : IHaveTitle
                                                                              where U : IHaveTitle
        {
            return (firstList.Title.Length > secondList.Title.Length) ? firstList : secondList;
        }

        //more generic GetTitle method
        private static string GetTitle<T>(T item)
        {
            var property = item.GetType().GetProperty("Title");
            if (property == null)
            {
                return null;
            }
            return property.GetValue(item, null) as string;
        }


        static void Main(string[] args)
        {
            List<string> fruits = new List<string>
            {
                "Cherry",
                "Banana"
            };

            List<string> vegetables = new List<string>
            {
                "Potato",
                "Cucumber",
                "Carrot"
            };

            Console.WriteLine(String.Join(", ", MixLists(fruits, vegetables)));

            TitleClass1 firstList = new TitleClass1 { Title = "Short Title" };
            TitleClass2 secondList = new TitleClass2 { Title = "A Much Longer Title" };

            var result = GetLongerTitle(firstList, secondList);
            Console.WriteLine($"'{result.Title}' has longer title.");

            Console.ReadLine();
        }
    }
    public interface IHaveTitle
    {
        public string Title { get; set; }
    }
    class TitleClass1 : IHaveTitle 
    {
        public string Title { get; set; }
    }
    class TitleClass2 : IHaveTitle 
    {
        public string Title { get; set; }
    }
}
