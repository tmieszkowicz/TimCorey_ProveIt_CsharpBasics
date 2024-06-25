using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;

//Stop the errors! If an exception occurs in the MakePayment
//method, catch it and print “Payment skipped for payment
//with 4 items” (or whatever the number is). However, the
//method properly returns a null one time. Fix that error (don’t
//just catch it) and print “Null value for item 4” instead.
//Handle the different errors differently. If you get an
//IndexOutOfRangeexception, print “Skipped invalid record”. If
//it is a FormatExceptionand the number of items is not 5,
//print “Formatting Issue”. For everything else, print the
//standard error. If an exception has an InnerException, print
//the Messageof the InnerExceptionat the end of whatever
//message is being displayed.

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentProcessor paymentProcessor = new PaymentProcessor();
            for (int i = 0; i <= 10; i++)
            {
                TransactionModel result = null;

                try
                {
                     result = paymentProcessor.MakePayment($"Demo{i}", i);

                    if (result != null)
                    {
                        Console.WriteLine(result.TransactionAmount);
                    }
                    else
                    {
                        Console.WriteLine($"Null value for item {i}");
                    }
                }

                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine($"Skipped invalid record on item {i} {e.InnerException?.Message}");
                }

                catch (FormatException e) when (i != 5)
                {
                    Console.WriteLine($"Formatting issue on item {i} {e.InnerException?.Message}");
                }

                catch (Exception e)
                {
                    Console.WriteLine($"Payment skipped on item {i} {e.InnerException?.Message}");
                }
            }

            Console.ReadLine();
        }
    }
}
