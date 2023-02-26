namespace UnitTestScenarios.Fundamentals.Tests
{
    // Naming convention of class is {NameOfClassTested}Tests
    // Naming convention of method is {NameOfMethodTested}_{Scenario}_{ExpectedResult}

    [TestFixture]
    public class FizzBuzzTests
    {
        //For FizzBuzz class's GetOuput method, there are four possible scenario, which are:
        // * The input can be divisible by 3 and 5
        // * The input can be divisible by only 3
        // * The input can be divisible by only 5
        // * The input can not be divisible by 3 or 5

        [Test]
        public void GetOutput_InputIsDivisibleBy3And5_ReturnFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_InputIsDivisibleByOnly3_ReturnFizz()
        {
            var result = FizzBuzz.GetOutput(3);
            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutput_InputIsDivisibleByOnly5_ReturnBuzz()
        {
            var result = FizzBuzz.GetOutput(5);
            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutput_InputIsNotDivisibleBy3Or5_ReturnInput()
        {
            var result = FizzBuzz.GetOutput(1);
            Assert.That(result, Is.EqualTo("1"));
        }

    }
}