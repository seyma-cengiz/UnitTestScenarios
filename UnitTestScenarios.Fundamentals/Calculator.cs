namespace UnitTestScenarios.Fundamentals
{
    public class Calculator
    {
        public double Add(double number1, double number2) => number1 + number2;
        public double Substract(double number1, double number2) => number1 - number2;
        public double Divide(double number1, double number2) => number2 == 0 ? throw new DivideByZeroException() : number1 / number2;
        public double Multiply(double number1, double number2) => number1 * number2;
    }
}
