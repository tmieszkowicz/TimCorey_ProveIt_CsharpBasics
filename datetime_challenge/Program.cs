using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace datetime_challenge
{
    internal class Program
    { 

        public static string CalculateAndPrintDateTimeDifference()
        {
            Console.WriteLine("Enter date [dd/MM/yyyy HH:mm]");
            string inputStringDate = Console.ReadLine();

            DateTime inputDate = DateTime.ParseExact(inputStringDate, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

            TimeSpan timeSpan = DateTime.Now - inputDate;


            if (inputDate.Ticks < 0) 
            {
                return $"That was {(int)timeSpan.TotalDays} days ago.\nAnd {(int)timeSpan.TotalMinutes} minutes ago.";
            }
            else 
            {
                return $"That is {-(int)timeSpan.TotalDays} days in the future.\nAnd {-(int)timeSpan.TotalMinutes} minutes in the future.";
            }
            
        }

        static void Main(string[] args)
        {
           Console.WriteLine(CalculateAndPrintDateTimeDifference());
        }
    }
}
