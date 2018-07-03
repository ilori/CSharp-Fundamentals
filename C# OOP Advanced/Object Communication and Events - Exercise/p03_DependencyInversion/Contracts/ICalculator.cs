namespace p03_DependencyInversion.Contracts
{
    public interface ICalculator
    {
        int PerformCalculation(int leftOperand, int rightOperand);

        void ChangeStrategy(ICalculationStrategy calculationStrategy);
    }
}