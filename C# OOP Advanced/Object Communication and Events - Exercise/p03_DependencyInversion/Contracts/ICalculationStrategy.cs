namespace p03_DependencyInversion.Contracts
{
    public interface ICalculationStrategy
    {
        int Calculate(int leftOperand, int rightOperand);
    }
}