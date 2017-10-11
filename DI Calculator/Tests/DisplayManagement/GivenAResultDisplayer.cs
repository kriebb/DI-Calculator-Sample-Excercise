using DI_Calculator.DisplayManagement;
using DI_Calculator.DisplayManagement.Impl;
using NSubstitute;
using NUnit.Framework;
using ObscureWare.Console;

namespace DI_Calculator.Tests.DisplayManagement
{
    [TestFixture]
    public class GivenAResultFactory
    {
        [Test]
        [TestCase("+", 0, "+: 0")]
        [TestCase("*", 7, "*: 7")]
        [TestCase("*", 12, "*: 12")]
        public void WhenWeDisplayTheResult_TheOutputShouldBeFormattedWithAnOrigin(string operation, int calculatedResult, string expectedFormat)
        {

            //Act
            var resultDisplayer = new ResultFactory();
            var result = resultDisplayer.Generate(operation, calculatedResult);
            //Assert

            Assert.AreEqual(expectedFormat, result);
        }

    }

    public class GivenAResultDisplayer
    {
        [Test]
        [TestCase("+", 0, "+: 0")]
        [TestCase("*", 7, "*: 7")]
        [TestCase("*", 12, "*: 12")]
        public void WhenWeDisplayTheResult_TheOutputShouldBeFormattedWithAnOrigin(string operation, int calculatedResult, string expectedFormat)
        {
            //Arrange
            var console = Substitute.For<IConsole>();
            var builder = Substitute.For<IOutputBuilderResult>();

            builder.Generate(operation, calculatedResult).Returns(expectedFormat);
            //Act
            var resultDisplayer = new ResultDisplayer(console, builder);
            resultDisplayer.Display(operation, calculatedResult);
            //Assert

            console.Received(1).WriteLine(expectedFormat);
        }
    }
}