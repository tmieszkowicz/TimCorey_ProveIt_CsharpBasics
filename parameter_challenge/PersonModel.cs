//Create and use both an out variable in a method and
//a tuple. They do not have to be in the same method.
//Create a variable in one method, pass it into another
//method, modify it in the method, and without
//returning it, use the updated value in the initial
//method. Use two different techniques to make this
//work

namespace parameter_challenge
{
    public class PersonModel
    {
        public string? FirstName { get; set; }  
        public string? LastName { get; set; }
    }
}
