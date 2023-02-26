using System.Collections;

namespace UnitTestScenarios.Fundamentals.Tests
{
    //-------- SetUp -----------
    //SetUp attribute is used inside a TestFixture to provide a common set of functions that are performed just before each test method is called.
    //for this case, we created Calculator instance in SetUp method, since it's gonna used ın every test scenario.

    //-------- TestCase -----------
    //TestCase attribute serves 2 purpose:
    //* marking a method with parameters as a test method
    //* providing inline data to be used when invoking that method.

    //-------- TestCaseSource -----------
    //TestCaseSource attribute is used on a parameterized test method to identify the source from which the required arguments will be provided. The attribute additionally identifies the method as a test method. The data is kept separate from the test itself and may be used by multiple test methods.

    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(1, -1)]
        [TestCase(1.1, 1.2)]
        public void Add_SumOfTwoNumbers_ShouldAddTwoNumbers(double number1, double number2)
        {
            var result = _calculator.Add(number1, number2);
            Assert.That(_calculator.Add(number1, number2), Is.EqualTo(result));
        }

        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(1, -1)]
        [TestCase(1.1, 1.2)]
        public void Substract_SubtractionOfTwoNumbers_ShouldSubstractTwoNumbers(double number1, double number2)
        {
            var result = _calculator.Substract(number1, number2);
            Assert.That(_calculator.Substract(number1, number2), Is.EqualTo(result));
        }

        [TestCase(1, 0)]
        public void Divide_DivisionOfZero_ShouldThrowException(double number1, double number2)
        {
            Assert.That(() => _calculator.Divide(number1, number2), Throws.TypeOf<DivideByZeroException>());
        }

        [TestCaseSource(typeof(CalculatorSource))]
        public void Divide_DivisionOfTwoNumbers_ShouldDivideTwoNumbers(double number1, double number2)
        {
            var result = _calculator.Divide(number1, number2);
            Assert.That(_calculator.Divide(number1, number2), Is.EqualTo(result));
        }

        [TestCaseSource(typeof(CalculatorSource))]
        public void Multiply_MultipleOfTwoNumbers_ShouldMultipleTwoNumbers(double number1, double number2)
        {
            var result = _calculator.Multiply(number1, number2);
            Assert.That(_calculator.Multiply(number1, number2), Is.EqualTo(result));
        }
    }

    public class CalculatorSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new[] { 1, 1 };
            yield return new[] { 0, 1 };
            yield return new[] { 1, -1 };
            yield return new[] { 1.1, 1.2 };
        }
    }
}
