using System;

// Делегат для підстановки функції, яку потрібно інтегрувати
delegate double FunctionDelegate(double x);

class IntegralCalculator
{
    // Метод для обчислення визначеного інтегралу за формулою лівих прямокутників
    public double CalculateLeftRectangles(double a, double b, int n, FunctionDelegate function)
    {
        double result = 0.0;
        double dx = (b - a) / n;

        for (int i = 0; i < n; i++)
        {
            double x = a + i * dx;
            result += function(x) * dx;
        }

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Приклад використання класу для обчислення інтегралу функції x^2 від 0 до 1 з 1000 прямокутниками
        IntegralCalculator calculator = new IntegralCalculator();
        double result = calculator.CalculateLeftRectangles(0, 1, 1000, x => x * x);

        Console.WriteLine("Результат обчислення інтегралу x^2 від 0 до 1: " + result);
    }
}
