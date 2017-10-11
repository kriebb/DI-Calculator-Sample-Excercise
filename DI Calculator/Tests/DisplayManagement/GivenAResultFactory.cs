using DI_Calculator.DisplayManagement.Impl;
using NUnit.Framework;

namespace DI_Calculator.Tests.DisplayManagement
{
    [TestFixture]
    public class GivenAResultFactory
    {
        [Test]
        [TestCase("+", 0, "George", "George | +: 0")]
        [TestCase("*", 7, "George", "George | *: 7")]
        [TestCase("*", 12, "George", "George | *: 12")]
        public void WhenWeDisplayTheResult_TheOutputShouldBeFormattedWithAnOrigin(string operation, int calculatedResult, string username, string expectedFormat)
        {

            //Act
            var resultDisplayer = new ResultFactory();
            var result = resultDisplayer.Generate(username,operation, calculatedResult);
            //Assert

            Assert.AreEqual(expectedFormat, result);
        }

    }
}