using System;

class ParentClass
{
    protected int day, month, year;

    // Конструктор за замовчуванням
    public ParentClass()
    {
        day = 1;
        month = 1;
        year = 2000;
    }

    // Функція-метод 1 обробки даних: збільшення року на 1
    public void ProcessData1()
    {
        year++;
    }

    // Функція-метод 2 обробки даних: зменшення дати на 2 дні
    public void ProcessData2()
    {
        day -= 2;
        if (day < 1)
        {
            month--;
            if (month < 1)
            {
                month = 12;
                year--;
            }
            day += DateTime.DaysInMonth(year, month);
        }
    }

    // Функція-метод формування рядка інформації про об'єкт
    public string GetInfo()
    {
        return $"{day:D2}/{month:D2}/{year:D4}";
    }
}

class ChildClass : ParentClass
{
    private string name;
    private DateTime hireDate;

    // Конструктор класу-нащадка
    public ChildClass(string name, DateTime hireDate)
    {
        this.name = name;
        this.hireDate = hireDate;
    }

    // Функція-метод 3 обробки даних: обчислення кількості років роботи на підприємстві
    public int CalculateYearsOfWork()
    {
        DateTime currentDate = DateTime.Now;
        int yearsOfWork = currentDate.Year - hireDate.Year;
        if (currentDate < hireDate.AddYears(yearsOfWork))
        {
            yearsOfWork--;
        }
        return yearsOfWork;
    }

    // Функція-метод формування рядка інформації про об'єкт
    public new string GetInfo()
    {
        return $"Працівник: {name}, дата приходу на підприємство: {hireDate:D}, кількість років роботи: {CalculateYearsOfWork()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        ParentClass parentObject = new ParentClass();
        Console.WriteLine("Дані класу-батька до обробки:");
        Console.WriteLine(parentObject.GetInfo());

        parentObject.ProcessData1();
        Console.WriteLine("Дані класу-батька після першої обробки:");
        Console.WriteLine(parentObject.GetInfo());

        parentObject.ProcessData2();
        Console.WriteLine("Дані класу-батька після другої обробки:");
        Console.WriteLine(parentObject.GetInfo());

        ChildClass childObject = new ChildClass("Іван", new DateTime(2010, 5, 15));
        Console.WriteLine("Дані класу-нащадка:");
        Console.WriteLine(childObject.GetInfo());
    }
}
