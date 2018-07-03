﻿namespace p03_DependencyInversion.Models
{
    using Contracts;

    public class SubtractionStrategy : ICalculationStrategy
    {
        public int Calculate(int leftOperand, int rightOperand)
        {
            return leftOperand - rightOperand;
        }
    }
}