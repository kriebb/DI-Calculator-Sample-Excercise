using DI_Calculator.Bootstrap;
using DI_Calculator.CalculationManagement;
using DI_Calculator.DisplayManagement;
using NSubstitute;
using NUnit.Framework;

namespace DI_Calculator.Tests.Bootstrap
{
    [TestFixture]
    public class GivenTheStartUpClass
    {
        private ICalculator _calculator;
        private int _fakeCalculatedResult;
        private string _operation;
        private int _x;
        private int _y;
        private IDisplayer _displayer;

        [SetUp]
        public void ArrangeForEachTestMethod()
        {
            //Arrange
            _calculator = Substitute.For<ICalculator>();

            _fakeCalculatedResult = 0;
            _operation = "+";
            _x = 0;
            _y = 0;

            _displayer = Substitute.For<IDisplayer>();

        }

        [Test]
        public void WhenWeStartTheApplication_TheCalculateMethodShouldBeCalled()
        {
            //how to know if this really works?
            //make sure the test goes red => e.g change Received(1) to Received(2);

            //Arrange
            _calculator.Calculate(_operation, _x, _y).Returns(_fakeCalculatedResult);

            //Act
            var startup = new Startup(_calculator,_displayer);
            
            startup.Start("+",_x,_y);

            //Assert
            _calculator.Received(1).Calculate(_operation, _x, _y);

        }

        [Test]
        public void WhenWeStartTheApplication_TheResultShouldBeDisplayed()
        {
            //Arrange
            _displayer.Display(_operation, _fakeCalculatedResult);

            //Act
            var startup = new Startup(_calculator, _displayer);

            startup.Start("+", _x, _y);

            //Assert
            _displayer.Received(1).Display(_operation, _fakeCalculatedResult);

        }
    }
}