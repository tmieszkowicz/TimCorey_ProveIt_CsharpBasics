using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculationsLibrary;

//Test the TextDataAccess class but do not permit the
//system to write to an actual file. This means you will
//need to rewrite the method to be more testable.
//Make sure you test for the PathTooLongException.
//Also, ensure that the filePath gets changed to just the
//file name (no path)

namespace unit_test_project_challenge.Tests
{
    public class TextDataAccessTests
    {
        [Fact]
        public void SaveText_Normal()
        {
            List<string> lines = new List<string>
            {
                "1st test",
                "2nd test",
                "3rd test"
            };

            string filePath = @"C:\temp\test.txt";
            string fileName = "test.txt";
            
            var mock = new Mock<ITextWriter>();
            mock.Setup(x => x.WriteLines(fileName, It.IsAny<List<string>>())).Verifiable();

            TextDataAccess dataAccess = new TextDataAccess();

            dataAccess.SaveText(filePath, lines,mock.Object);
            mock.Verify();
        }

        [Fact]
        public void SaveText_ShouldThrowPathTooLongException()
        {
            List<string> lines = new List<string>
            {
                "1st test",
                "2nd test",
                "3rd test"
            };

            string filePath = @"C:\temp\testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttest.txt";

            string fileName = "test.txt";

            var mock = new Mock<ITextWriter>();
            mock.Setup(x => x.WriteLines(fileName, It.IsAny<List<string>>())).Verifiable();

            TextDataAccess dataAccess = new TextDataAccess();

            Assert.Throws<PathTooLongException>(
                () => dataAccess.SaveText(filePath, lines, mock.Object));
        }
    }
}
