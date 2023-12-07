using System;

// Інтерфейс IFigure
public interface IFigure
{
    void DisplayType(); // Метод для виведення типу фігури
    void DisplayArea(); // Метод для виведення площі фігури

    double FirstDimension { get; set; } // Перший лінійний розмір фігури
    double SecondDimension { get; set; } // Другий лінійний розмір фігури

    void DisplayDiagonalLength(); // Метод для виведення довжини діагоналі фігури
}

// Інтерфейс IColoredFigure успадковує IFigure та додає колір
public interface IColoredFigure : IFigure
{
    string Color { get; set; } // Властивість, що відповідає за колір фігури
    void DisplayColor(); // Метод для виведення коліру фігури
}

// Клас Rectangle, що реалізує інтерфейс IFigure
public class Rectangle : IFigure
{
    public double FirstDimension { get; set; }
    public double SecondDimension { get; set; }

    public void DisplayArea()
    {
        Console.WriteLine($"Area of Rectangle: {FirstDimension * SecondDimension}");
    }

    public void DisplayDiagonalLength()
    {
        double diagonal = Math.Sqrt(FirstDimension * FirstDimension + SecondDimension * SecondDimension);
        Console.WriteLine($"Diagonal length of Rectangle: {diagonal}");
    }

    public void DisplayType()
    {
        Console.WriteLine("Type: Rectangle");
    }
}

// Клас ColoredRectangle, що реалізує інтерфейс IColoredFigure
public class ColoredRectangle : IColoredFigure
{
    public double FirstDimension { get; set; }
    public double SecondDimension { get; set; }
    public string Color { get; set; }

    public void DisplayArea()
    {
        Console.WriteLine($"Area of ColoredRectangle: {FirstDimension * SecondDimension}");
    }

    public void DisplayDiagonalLength()
    {
        double diagonal = Math.Sqrt(FirstDimension * FirstDimension + SecondDimension * SecondDimension);
        Console.WriteLine($"Diagonal length of ColoredRectangle: {diagonal}");
    }

    public void DisplayType()
    {
        Console.WriteLine("Type: ColoredRectangle");
    }

    public void DisplayColor()
    {
        Console.WriteLine($"Color of ColoredRectangle: {Color}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення екземплярів класів Rectangle та ColoredRectangle
        Rectangle rect1 = new Rectangle { FirstDimension = 5, SecondDimension = 10 };
        Rectangle rect2 = new Rectangle { FirstDimension = 3, SecondDimension = 7 };
        Rectangle rect3 = new Rectangle { FirstDimension = 4, SecondDimension = 8 };

        ColoredRectangle coloredRect1 = new ColoredRectangle { FirstDimension = 6, SecondDimension = 12, Color = "Blue" };
        ColoredRectangle coloredRect2 = new ColoredRectangle { FirstDimension = 2, SecondDimension = 4, Color = "Red" };
        ColoredRectangle coloredRect3 = new ColoredRectangle { FirstDimension = 7, SecondDimension = 14, Color = "Green" };

        // Створення масиву з екземплярів
        IFigure[] figures = { rect1, rect2, rect3, coloredRect1, coloredRect2, coloredRect3 };

        // Метод для вибору лише елементів, що підтримують колір
        DisplayColoredFigures(figures);
    }

    static void DisplayColoredFigures(IFigure[] figures)
    {
        Console.WriteLine("Colored Figures:");
        foreach (var figure in figures)
        {
            if (figure is IColoredFigure coloredFigure)
            {
                coloredFigure.DisplayType();
                coloredFigure.DisplayColor();
            }
        }
    }
}
