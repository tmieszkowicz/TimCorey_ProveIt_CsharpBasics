using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


//Identify how old a person is by using their date of
//birth.List how old they are in years (round down),
//months, and days.
//Calculate how long it will be until the person’s next
//birthday. Round months to the nearest whole
//number. Then calculate the number of weeks
//until their birthday

namespace birthday_calculation_challenge
{
    internal class Pogram
    {
        static public int GetYears(DateTime start)
        {
            int years = DateTime.Now.Year - start.Year;

            if (DateTime.Now.Month < start.Month || (DateTime.Now.Month == start.Month && DateTime.Now.Day < start.Day))
            {
                years--;
            }

            return years;
        }
        static public int GetMonths(DateTime start)
        {
            int years = DateTime.Now.Year - start.Year;
            int months = DateTime.Now.Month - start.Month;

            if (DateTime.Now.Day < start.Day)
            {
                months--;
            }

            return (years * 12) + months;
        }
        static public int GetDays(DateTime start)
        {
            return (DateTime.Now - start).Days;
        }

        static public int GetMonthsUntil(DateTime start)
        {
            int months = start.Month - DateTime.Now.Month;

            if(start.Month == DateTime.Now.Month && start.Day>DateTime.Now.Day)
            {
                return 0;
            }

            return (months > 0) ? months : months + 12;
        }
        static public int GetWeeksUntil(DateTime start)
        {
            DateTime today = DateTime.Today;
            DateTime nextBirthday = new DateTime(today.Year, start.Month, start.Day);

            if (nextBirthday < today)
            {
                nextBirthday = nextBirthday.AddYears(1);
            }

            return ((nextBirthday - today).Days)/7;
        }

        static public int GetDaysUntil(DateTime start)
        {
            DateTime today = DateTime.Today;
            DateTime nextBirthday = new DateTime(today.Year, start.Month, start.Day);

            if (nextBirthday < today)
            {
                nextBirthday = nextBirthday.AddYears(1);
            }

            return (nextBirthday - today).Days;
        }
        static void Main(string[] args)
        {
            DateTime birthDate = new DateTime(1997, 01, 14);

            Console.WriteLine($"Your birthday is in {birthDate.ToShortDateString()}.");

            Console.WriteLine($"You are {GetYears(birthDate)} years old.\nYou are {GetMonths(birthDate)} months old.\nYou are {GetDays(birthDate)} days old.");
            Console.WriteLine($"Your birthday is in {GetMonthsUntil(birthDate)} months or {GetWeeksUntil(birthDate)} weeks or {GetDaysUntil(birthDate)} days.");
        }
    }
}