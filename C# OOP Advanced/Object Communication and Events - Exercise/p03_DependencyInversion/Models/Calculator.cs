namespace p03_DependencyInversion.Models
{
    using Contracts;

    public class Calculator : ICalculator
    {
        private ICalculationStrategy calculationStrategy;

        public Calculator(ICalculationStrategy calculationStrategy)
        {
            this.calculationStrategy = calculationStrategy;
        }

        public int PerformCalculation(int leftOperand, int rightOperand)
        {
            return calculationStrategy.Calculate(leftOperand, rightOperand);
        }

        public void ChangeStrategy(ICalculationStrategy calculationStrategy)
        {
            this.calculationStrategy = calculationStrategy;
        }
    }
}