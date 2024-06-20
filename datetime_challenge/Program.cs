using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Capture a date from the console and calculate how
//many days ago it was. Then capture a time from the
//console and calculate how many hours and minutes
//ago it was (assume less than now and not previous
//day).
//For times, allow the user to choose to specify 12-or 24-
//hourformat. For dates, allow the user to specify
//month/day/year or day/month/year format based
//upon their choice. Also, don’t assume times are not
//the previous day.

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
