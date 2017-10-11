using DI_Calculator.CalculationManagement.Impl.Simple;
using NUnit.Framework;

namespace DI_Calculator.Tests.CalculationManagement
{
    [TestFixture]
    public class GivenACalculator
    {
        [Test]
        [TestCase(4, "*", 3,12)]
        [TestCase(4, "+", 3, 7)]
        public void WhenWeCalculateWithAOperation_TheParametersShouldHaveAResultBasedOnThatOperation(int x, string operation,int y, int expectedResult)
        {
            var calculator = new SimpleCalculator();
            var calculatedResult = calculator.Calculate(operation, x, y);
            Assert.AreEqual(expectedResult,calculatedResult);
        }

        [Test]
        [TestCase(4, "*", 3, 7)]
        [TestCase(4, "+", 3, 12)]
        public void WhenWeMultiply_TheParametersShouldNotHaveASommationResult(int x, string operation, int y, int expectedResult)
        {
            var calculator = new SimpleCalculator();
            var calculatedResult = calculator.Calculate(operation, x, y);
            Assert.AreNotEqual(expectedResult, calculatedResult);
        }
    }
}