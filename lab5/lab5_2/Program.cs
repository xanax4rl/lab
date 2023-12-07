using System;

// Інтерфейс Інструмент
public interface IInstrument
{
    string KEY { get; } // Змінна інтерфейсу
    void Play(); // Метод Play()
}

// Клас Гітара, що реалізує інтерфейс Інструмент
public class Guitar : IInstrument
{
    public string KEY { get; } = "До мажор"; // Реалізація змінної інтерфейсу

    public int NumberOfStrings { get; private set; } // Змінна класу Гітара - кількість струн

    public Guitar(int numberOfStrings)
    {
        NumberOfStrings = numberOfStrings;
    }

    public void Play()
    {
        Console.WriteLine($"Playing guitar with {NumberOfStrings} strings");
    }
}

// Клас Барабан, що реалізує інтерфейс Інструмент
public class Drum : IInstrument
{
    public string KEY { get; } = "До мажор"; // Реалізація змінної інтерфейсу

    public int Size { get; private set; } // Змінна класу Барабан - розмір

    public Drum(int size)
    {
        Size = size;
    }

    public void Play()
    {
        Console.WriteLine($"Playing drum with size {Size}");
    }
}

// Клас Труба, що реалізує інтерфейс Інструмент
public class Trumpet : IInstrument
{
    public string KEY { get; } = "До мажор"; // Реалізація змінної інтерфейсу

    public int Diameter { get; private set; } // Змінна класу Труба - діаметр

    public Trumpet(int diameter)
    {
        Diameter = diameter;
    }

    public void Play()
    {
        Console.WriteLine($"Playing trumpet with diameter {Diameter}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення масиву типу Інструмент
        IInstrument[] instruments = {
            new Guitar(6),
            new Drum(20),
            new Trumpet(10)
        };

        // Виклик методу Play() для кожного інструменту у циклі
        foreach (var instrument in instruments)
        {
            instrument.Play();
        }
    }
}
