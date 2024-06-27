using CalculationsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Create tests for the Calculator class. Make sure to test
//that the proper exceptions are thrown. Do not change
//the code in the Calculator class.
//Test the TextDataAccess class but do not permit the
//system to write to an actual file. This means you will
//need to rewrite the method to be more testable.
//Make sure you test for the PathTooLongException.
//Also, ensure that the filePath gets changed to just the
//file name (no path)

namespace unit_test_project_challenge.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(4, 3, 7)]
        [InlineData(20.3, 3.7, 24)]
        [InlineData(double.MaxValue, 5, double.MaxValue)]
        [InlineData(-309, -101, -410)]
        [InlineData(9, -9, 0)]
        public void Add_ShouldReturnExpectedValue(double firstValue, double secondValue, double expectedResult)
        {
            Assert.Equal(Calculator.Add(firstValue, secondValue), expectedResult);
        }

        [Theory]
        [InlineData(4, 4, 1)]
        [InlineData(-300, -100, 3)]
        [InlineData(9, -9, -1)]
        [InlineData(0, 3, 0)]
        public void Divide_ShouldReturnExpectedValue(double firstValue, double secondValue, double expectedResult)
        {
            Assert.Equal(Calculator.Divide(firstValue, secondValue), expectedResult);
        }

        [Fact]
        public void Divide_ShouldReturnArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Calculator.Divide(20.3, 0));
        }

        [Theory]
        [InlineData(4, 4, 2, 10, 8)]
        [InlineData(-300, -100, -1000, 1000, -400)]
        [InlineData(9, -9, -22, 22, 0)]
        [InlineData(0, 3, -2, 7, 3)]
        public void LimitedAdd_ShouldReturnExpectedValue(double x, double y, double minValue, double maxValue, double expectedResult)
        {
            Assert.Equal(Calculator.LimitedAdd(x, y, minValue, maxValue), expectedResult);
        }

        [Theory]
        [InlineData(4, 4, 6, 10, "x")]
        [InlineData(-300, -100, -400, -400, "x")]
        [InlineData(9, -9, -2, 22, "y")]
        [InlineData(0, 3, 0, 1, "y")]
        public void Divide_ShouldReturnArgumentOutOfRangeException(double x, double y, double minValue, double maxValue, string wrongVariable)
        {
            Assert.Throws<ArgumentOutOfRangeException>(wrongVariable,() => Calculator.LimitedAdd(x, y, minValue, maxValue));
        }
    }
}
