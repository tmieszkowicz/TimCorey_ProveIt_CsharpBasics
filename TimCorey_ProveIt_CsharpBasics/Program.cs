using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace foreach_challenge
{
    internal class Program
    {
        public static List<PersonModel> GetPeopleStrings()
        {
            List<PersonModel> strings = new List<PersonModel>();

            strings.Add(new PersonModel("Bob", "Smith"));
            strings.Add(new PersonModel("Tom", "Smith"));
            strings.Add(new PersonModel("Sue", "Smith"));

            return strings;
        }
        static void Main(string[] args)
        {
            List<PersonModel> people = GetPeopleStrings();

            foreach (PersonModel p in people)
            {
                Console.WriteLine($"Hello {p.FirstName} {p.LastName}!");
            }
        }
    }
}
