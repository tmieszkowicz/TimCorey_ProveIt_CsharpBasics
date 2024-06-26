﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CalculationsLibrary
{
    public class TextDataAccess
    {
        public void SaveText(string filePath, List<string> lines, ITextWriter textWriter)
        {
            if (filePath.Length > 260)
            {
                throw new PathTooLongException("The path needs to be less than 261 characters long.");
            }

            string fileName = Path.GetFileName(filePath);
 
            textWriter.WriteLines(fileName, lines);
        }
    }

    public class TextWriter : ITextWriter
    {
        public void WriteLines(string filePath, List<string> lines)
       {
           File.WriteAllLines(filePath, lines);
       }
    } 

    public interface ITextWriter
    {
        void WriteLines(string filePath, List<string> lines);
    }
}
