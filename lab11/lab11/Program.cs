using System;
using System.Globalization;
using System.Linq;

class Program
{
    static string ReplaceZerosAndOnes(string input, int startPosition)
    {
        char[] chars = input.ToCharArray();
        for (int i = startPosition; i < chars.Length; i++)
        {
            if (chars[i] == '0')
                chars[i] = '1';
            else if (chars[i] == '1')
                chars[i] = '0';
        }
        return new string(chars);
    }

    static void Main(string[] args)
    {
        // 1. Заміна нулів та одиниць у рядку
        string initialString = "101010101011111";
        int startPosition = 3; // Починаємо зміну символів з позиції 3
        string modifiedString = ReplaceZerosAndOnes(initialString, startPosition);
        Console.WriteLine($"Modified String: {modifiedString}");

        // 2. Підрахунок кількості днів до вказаної дати
        DateTime today = DateTime.Today;
        DateTime specifiedDate = new DateTime(2023, 12, 31); // Приклад вказаної дати

        if (specifiedDate > today)
        {
            TimeSpan daysRemaining = specifiedDate - today;
            Console.WriteLine($"Days remaining till {specifiedDate.ToShortDateString()}: {daysRemaining.Days}");
        }
        else
        {
            Console.WriteLine("This day has already passed.");
        }



            string datesString = "12, 04, 2022, 25, 04, 2023, 30, 09, 2021";
            string[] dateParts = datesString.Split(", ")
                .Select(part => part.Trim()).ToArray();
            // Створюэмо масив дат
            DateTime[] dates = new DateTime[dateParts.Length / 3]; int dateIndex = 0;
            //Заповнюємо наш масив даним із масиву стрінг
            for (int i = 0; i < dateParts.Length; i += 3)
            {
                string day = dateParts[i]; string month = dateParts[i + 1];
                string year = dateParts[i + 2]; string dateString = $"{day} {month} {year}";
                DateTime parsedDate = DateTime.ParseExact(dateString, "dd MM yyyy", CultureInfo.InvariantCulture); dates[dateIndex] = parsedDate;
                dateIndex++;
            }
            //a) Знайдемо рік з найменшим номером
            int minYear = dates.Select(date => date.Year).
                Min(); Console.WriteLine($"Year with the smallest number: {minYear}");
            // b) Знайдемо всі весняні дати
            var springDates = dates.Where(date => date.Month > 2 && date.Month < 5);
            Console.WriteLine("\nSpring dates : "); foreach (var springDate in springDates)
            {
                Console.WriteLine($"Date : {springDate.ToShortDateString()}");
            }
        // c) Знайдемо саму пізню дату
        var latestDate = dates.Max(); Console.WriteLine($"\nLatest Date: {latestDate.ToShortDateString()}");
        
    }
}

