using System;

public class Scale<T> where T : struct, IComparable<T>
{
    private T leftSide;
    private T rightSide;

    public Scale(T leftSide, T rightSide)
    {
        this.leftSide = leftSide;
        this.rightSide = rightSide;
    }

    public T? GetHeavier()
    {
        if (this.leftSide.CompareTo(this.rightSide) > 0)
        {
            return this.leftSide;
        }
        else if (this.leftSide.CompareTo(this.rightSide) < 0)
        {
            return this.rightSide;
        }

        return null;
    }
}