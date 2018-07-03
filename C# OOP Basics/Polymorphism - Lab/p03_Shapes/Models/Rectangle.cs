using System;

public class Rectangle : Shape
{
    public Rectangle(double a, double b)
    {
        sideA = a;
        sideB = b;
    }

    private double sideA;
    private double sideB;

    public override double CalculateArea()
    {
        return this.sideA * this.sideB;
    }

    public override double CalculatePerimeter()
    {
        return sideA * 2 + sideB * 2;
    }

    public override string Draw()
    {
        return base.Draw() + "Rectangle";
    }
}