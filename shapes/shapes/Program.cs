namespace ShapesHierarchy;

public abstract class Shape
{
    protected string Color { get; set; }
    protected bool IsFilled { get; set; }

    protected Shape()
    {
        Color = "red";
        IsFilled = true;
    }

    protected Shape(string color, bool isFilled)
    {
        Color = color;
        IsFilled = isFilled;
    }

    public abstract double Area();
    public abstract double Perimeter();

    public override string ToString()
    {
        var filledStatus = IsFilled ? "filled" : "not filled";
        
        return $"A shape with color of {Color} and {filledStatus}";
    }
}

public class Circle : Shape
{
    private const double Pi = 3.14; 
    private double Radius { get; }

    public Circle()
    {
        Radius = 1.0;
    }
    
    public Circle(double radius)
    {
        Radius = radius;
    }

    public Circle(double radius, string color, bool isFilled)
    {
        Radius = radius;
        Color = color;
        IsFilled = isFilled;
    }
    
    public override double Area()
    {
        return Pi * Radius * Radius;
    }

    public override double Perimeter()
    {
        return 2 * Pi * Radius;
    }

    public override string ToString()
    {
        return $"A Circle with radius = {Radius}, which is a derived class of {base.ToString()}";
    }
}

public class Rectangle : Shape
{
    private double Width { get; set; }
    private double Length { get; set; }

    public Rectangle()
    {
        Width = 1.0;
        Length = 1.0;
    }

    public Rectangle(double width, double length)
    {
        Width = width;
        Length = length;
    }

    public Rectangle(double width, double length, string color, bool isFilled)
    {
        Width = width;
        Length = length;
        Color = color;
        IsFilled = isFilled;
    }

    static Rectangle() => Console.WriteLine("Rectangle Class initialized");
    
    public override double Area()
    {
        return Width * Length;
    }

    public override double Perimeter()
    {
        return 2 * (Width + Length);
    }

    public override string ToString()
    {
        return $"A Rectangle with width = {Width} and length = {Length}, which derived class of {base.ToString()}";
    }
}

public class ComplexShape
{
    private List<Shape> ShapesList = new List<Shape>();

    public void Add(Shape shape)
    {
        ShapesList.Add(shape);
    }

    public double Area()
    {
        double totalArea = 0;

        foreach (var shape in ShapesList)
        {
            totalArea += shape.Area();
        }

        return totalArea;
    }

    public double Perimeter()
    {
        double totalPerimeter = 0;

        foreach (var shape in ShapesList)
        {
            totalPerimeter += shape.Perimeter();
        }

        return totalPerimeter;
    }
}

public class Test
{
    private static void Main()
    {
        var circle1 = new Circle(10, "green", true);
        Console.WriteLine(circle1.ToString());
        var circle2 = new Circle(12);
        Console.WriteLine(circle2.ToString());
        var circle3 = new Circle();
        Console.WriteLine(circle3.ToString());

        var rec1 = new Rectangle(10, 3);
        Console.WriteLine(rec1.ToString());
        var rec2 = new Rectangle(4, 10, "green", true);
        Console.WriteLine(rec2.ToString());
        var rec3 = new Rectangle(4, 10, "white", false);
        Console.WriteLine(rec3.ToString());

        var complexShape = new ComplexShape();
        complexShape.Add(circle1);
        complexShape.Add(circle2);
        complexShape.Add(circle3);
        complexShape.Add(rec1);
        complexShape.Add(rec2);
        complexShape.Add(rec3);

        Console.WriteLine("the shapes total area is: " + complexShape.Area());
        Console.WriteLine("the shapes total perimeter is: " + complexShape.Perimeter());
    }
}

