public class Rectangle
{
    public Rectangle(string id, double width, double height, double x, double y)
    {
        Id = id;
        Width = width;
        Height = height;
        X = x;
        Y = y;
    }

    public string Id { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public double X { get; set; }

    public double Y { get; set; }

    public bool DoesRectanglesIntersect(Rectangle r2)
    {
        if (this.X > r2.X + r2.Width || r2.X > this.X + this.Width)
        {
            return false;
        }

        if (this.Y < r2.Y - this.Height || r2.Y < this.Y - this.Height)
        {
            return false;
        }

        return true;
    }
}