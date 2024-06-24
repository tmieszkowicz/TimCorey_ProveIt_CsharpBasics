using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

//Create a Console app that will rename every text file
//in a folder to be standard casing (first letter of each
//word capitalized). Also replace any instance of Acme
//with TimCo in the names.
//Using the files in the advanced folder, rename the
//files based upon the first line of each file. So, if File1.txt
//has a first line of Testing, the new file name should be
//Testing.txt.Make sure to retain the extension type.

namespace bulk_file_renaming_challenge
{
    internal class Program
    {
        static void Main()
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string folderPath = Path.Combine(solutionDirectory, "PrimaryChallengeFiles");
            foreach (string file in Directory.EnumerateFiles(folderPath, "*.txt"))
            {
                //string contents = File.ReadAllText(file);

                string directory = Path.GetDirectoryName(file);
                string newFileName = textInfo.ToTitleCase(Path.GetFileName(file));

                newFileName = Regex.Replace(newFileName, "Acme", "TimCo", RegexOptions.IgnoreCase);

                string newFilePath = Path.Combine(directory, newFileName);
                File.Move(file, newFilePath);

            }
        }
    }
}
