using System;

public interface IArea
{
    double GetArea();
}

public abstract class Shape : IArea
{
    public abstract double GetArea();
}

public class Circle : Shape
{
    private double radius;

    public Circle(double r)
    {
        radius = r;
    }

    public override double GetArea()
    {
        return Math.PI * radius * radius;
    }
}

public class Rectangle : Shape
{
    private double width;
    private double height;

    public Rectangle(double w, double h)
    {
        width = w;
        height = h;
    }

    public override double GetArea()
    {
        return width * height;
    }
}

public class Triangle : Shape
{
    private double baseVal;
    private double height;

    public Triangle(double b, double h)
    {
        baseVal = b;
        height = h;
    }

    public override double GetArea()
    {
        return 0.5 * baseVal * height;
    }
}

public class Solution
{
    public static double ComputeTotalArea(string[] shapes)
    {
        double total = 0;

        for (int i = 0; i < shapes.Length; i++)
        {
            string[] parts = shapes[i].Split(' ');

            Shape shape = null;

            if (parts[0] == "C")
            {
                double r = double.Parse(parts[1]);
                shape = new Circle(r);
            }
            else if (parts[0] == "R")
            {
                double w = double.Parse(parts[1]);
                double h = double.Parse(parts[2]);
                shape = new Rectangle(w, h);
            }
            else if (parts[0] == "T")
            {
                double b = double.Parse(parts[1]);
                double h = double.Parse(parts[2]);
                shape = new Triangle(b, h);
            }

            if (shape != null)
                total += shape.GetArea();
        }

        return Math.Round(total, 2, MidpointRounding.AwayFromZero);
    }
}
