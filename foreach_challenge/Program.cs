using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;

//Create a Console app that has a List<string>populated
//with a set of names. Loop through the names using
//the foreach.For every name, print it to the console.
//Instead of strings, make a class and create a set of
//instances of that class instead. The class should store
//first and last names. Use those properties when
//printing out the message on the console.

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
