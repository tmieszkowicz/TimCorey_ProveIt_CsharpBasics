//Create two extension methods. One called Print that
//prints a string to the console like so:
//“HelloWorld”.Print() and one called Excite that
//replaces all periods with exclamation points like so:
//“Hello World.”.Excite()
//Create this chain for a Person object:
//<person>.Fill().Print(); where Fill asks the user for each
//property’s value and print will print all properties to
//the console. Then create this chain on a double:
//<double>.Add(4).Subtract(2).MultiplyBy(8).DivideBy(3);

namespace extension_methods_challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            "HelloWorld".Print();
            "Hello World.".Excite().Print();

            PersonModel person = new PersonModel();
            person.Fill().Print();

            Console.WriteLine(2.00.Add(4).Subtract(2).MultiplyBy(8).DivideBy(3));

            Console.ReadLine();
        }
    }
    public class PersonModel()
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public static class ExtensionHelper
    {
        public static PersonModel Fill(this PersonModel person)
        {
            Console.WriteLine("Enter first name");
            person.FirstName = Console.ReadLine();

            Console.WriteLine("Enter last name");
            person.LastName = Console.ReadLine();

            return person;
        }
        public static void Print(this string message)
        {
            Console.WriteLine(message);
        }
        public static void Print(this PersonModel person)
        {
            Console.WriteLine($"This is {person.FirstName} {person.LastName}");
        }
        public static string Excite(this string message)
        {
            return message.Replace(".", "!");
        }
        public static double Add(this double originalValue, double value)
        {
            return originalValue + value;
        }
        public static double Subtract(this double originalValue, double value)
        {
            return originalValue - value;
        }
        public static double MultiplyBy(this double originalValue, double value)
        {
            return originalValue * value;
        }
        public static double DivideBy(this double originalValue, double value)
        {
            return originalValue / value;
        }
    }
}

