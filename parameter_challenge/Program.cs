using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Create and use both an out variable in a method and
//a tuple. They do not have to be in the same method.
//Create a variable in one method, pass it into another
//method, modify it in the method, and without
//returning it, use the updated value in the initial
//method. Use two different techniques to make this
//work

namespace parameter_challenge
{
    internal class Program
    {
        static bool HasCapitalCharacter(string input, out bool result)
        {
            result = false;
            if (input.Any(char.IsUpper))
            {
                return true;
            };

            return false;
        }
        static (string output, bool wasConverted) CanConvertToCapitals(string input)
        {
            Regex rgx = new Regex("^[a-zA-Z ]+$");  
            if (rgx.IsMatch(input))
            {
                return (input.ToUpper(), true);
            }
            return (input, false);
        }
        static void RemoveNonLetters(ref string input)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            input = rgx.Replace(input, "");
        }
        static void PopulatePersonModel(PersonModel personModel)
        {
            personModel.FirstName = "Tom";
            personModel.LastName = "Smith";
        }

        static void Main(string[] args)
        {
            string inputString = "Eat your vegetables!";
            bool hasCapital;

            if (HasCapitalCharacter(inputString,out hasCapital))
            {
                Console.WriteLine($"String contains capital letters: {inputString}");
            }
            else
            {
                Console.WriteLine("String does not contain capital letters.");
            }

            inputString = "Eat Your Vegetables";
            var result = CanConvertToCapitals(inputString);
            Console.WriteLine($"String before: {inputString}, String after: {result.output}, Was converted?: {result.wasConverted}");

            RemoveNonLetters(ref inputString);
            Console.WriteLine(inputString);

            PersonModel user = new PersonModel();
            PopulatePersonModel(user);
            Console.WriteLine($"User: {user.FirstName} {user.LastName}");

            Console.ReadLine();
        }
    }
}
