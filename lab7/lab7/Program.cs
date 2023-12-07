using System;
using System.Collections.Generic;
using System.Linq;

// Клас Винятку KilkistException
class KilkistException : Exception
{
    public KilkistException(string message) : base(message) { }
}

// Клас Винятку VkladException
class VkladException : Exception
{
    public VkladException(string message) : base(message) { }
}

// Клас Вклад
class Vklad
{
    public string PIBVkladnyka { get; set; }
    private decimal sumaVkladu;

    public decimal SumaVkladu
    {
        get => sumaVkladu;
        set
        {
            if (value < 0)
            {
                throw new VkladException($"Неможливо створити внесок – вказана негативна сума вкладу: {value}");
            }
            sumaVkladu = value;
        }
    }

    public virtual decimal RozrahuvatySumuVkladu(int kilkistMisjatsiv)
    {
        return SumaVkladu * kilkistMisjatsiv;
    }
}

// Довгостроковий вклад
class DovgostrokovyiVklad : Vklad
{
    public override decimal RozrahuvatySumuVkladu(int kilkistMisjatsiv)
    {
        try
        {
            if (kilkistMisjatsiv < 0)
            {
                throw new KilkistException("Кількість місяців не може бути від'ємною.");
            }
            return base.RozrahuvatySumuVkladu(kilkistMisjatsiv);
        }
        catch (KilkistException ex)
        {
            Console.WriteLine($"Помилка при розрахунку суми довгострокового вкладу: {ex.Message}");
            return 0;
        }
    }
}

// Вклад на вимогу
class VkladNaVymogu : Vklad
{
    public override decimal RozrahuvatySumuVkladu(int kilkistMisjatsiv)
    {
        try
        {
            if (kilkistMisjatsiv < 0)
            {
                throw new KilkistException("Кількість місяців не може бути від'ємною.");
            }
            return base.RozrahuvatySumuVkladu(kilkistMisjatsiv);
        }
        catch (KilkistException ex)
        {
            Console.WriteLine($"Помилка при розрахунку суми вкладу на вимогу: {ex.Message}");
            return 0;
        }
    }
}

// Клас Банк
class Bank
{
    public string Name { get; set; }

    public List<Branch> Branches { get; set; } = new List<Branch>();
}

// Клас Філія
class Branch
{
    public string Name { get; set; }
    public decimal TotalDeposits { get; set; }

    public List<Vklad> Deposits { get; set; } = new List<Vklad>();
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Приклад створення банку та додавання філій та вкладів
            Bank myBank = new Bank { Name = "MyBank" };
            Branch branch1 = new Branch { Name = "Branch 1" };
            Branch branch2 = new Branch { Name = "Branch 2" };

            myBank.Branches.Add(branch1);
            myBank.Branches.Add(branch2);

            Vklad deposit1 = new DovgostrokovyiVklad { PIBVkladnyka = "Client A", SumaVkladu = 1000 };
            Vklad deposit2 = new VkladNaVymogu { PIBVkladnyka = "Client B", SumaVkladu = 1500 };

            branch1.Deposits.Add(deposit1);
            branch2.Deposits.Add(deposit2);

            // Приклад розрахунку суми вкладу для конкретного вкладу
            decimal calculatedAmount = deposit1.RozrahuvatySumuVkladu(12);
            Console.WriteLine($"Розрахована сума для вкладу клієнта A: {calculatedAmount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
