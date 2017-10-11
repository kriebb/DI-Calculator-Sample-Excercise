using DI_Calculator.DisplayManagement;
using DI_Calculator.DisplayManagement.Impl;
using DI_Calculator.Framework.SettingsManagement;
using NSubstitute;
using NUnit.Framework;
using ObscureWare.Console;

namespace DI_Calculator.Tests.DisplayManagement
{
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
            var settings = Substitute.For<ISettings>();
            var userName = "George";
            settings.UserName.Returns(userName);
            builder.Generate(userName,operation, calculatedResult).Returns(expectedFormat);
            //Act
            var resultDisplayer = new ResultDisplayer(console, builder, settings);
            resultDisplayer.Display(operation, calculatedResult);
            //Assert

            console.Received(1).WriteLine(expectedFormat);
        }
    }
}