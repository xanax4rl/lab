using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "E:\\f.txt"; 

        // Зчитування чисел з файлу
        string[] lines = File.ReadAllLines(filePath);

        if (lines.Length > 0)
        {
            double[] numbers = lines.Select(double.Parse).ToArray();

            // 1) Найбільше значення компонент
            double maxNumber = numbers.Max();
            Console.WriteLine($"Найбільше значення компонент: {maxNumber}");

            // 2) Найменше значення компонент з парними номерами
            double minEvenNumber = numbers.Where((num, index) => index % 2 == 0).Min();
            Console.WriteLine($"Найменше значення компонент з парними номерами: {minEvenNumber}");

            // 3) Найбільше значення модулів компонент з непарними номерами
            double maxAbsOddNumber = numbers.Where((num, index) => index % 2 != 0).Select(Math.Abs).Max();
            Console.WriteLine($"Найбільше значення модулів компонент з непарними номерами: {maxAbsOddNumber}");

            // 4) Сума найбільшого і найменшого значень компонент
            double sumMinMax = numbers.Min() + numbers.Max();
            Console.WriteLine($"Сума найбільшого і найменшого значень компонент: {sumMinMax}");

            // 5) Різниця першої і останньої компонент файлу
            double firstNumber = numbers.FirstOrDefault();
            double lastNumber = numbers.LastOrDefault();
            double difference = lastNumber - firstNumber;
            Console.WriteLine($"Різниця першої і останньої компонент файлу: {difference}");
        }
        else
        {
            Console.WriteLine("Файл порожній або не існує.");
        }
    }
}
