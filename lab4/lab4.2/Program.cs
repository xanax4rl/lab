using System;

class TNumber
{
    protected string number;

    public TNumber(string number)
    {
        this.number = number;
    }

    public virtual int SumOfDigits()
    {
        int sum = 0;
        foreach (char digit in number)
        {
            if (char.IsDigit(digit))
            {
                sum += int.Parse(digit.ToString());
            }
        }
        return sum;
    }

    public virtual char FirstDigit()
    {
        foreach (char digit in number)
        {
            if (char.IsDigit(digit))
            {
                return digit;
            }
        }
        return '0';
    }

    public virtual char LastDigit()
    {
        char last = '0';
        foreach (char digit in number)
        {
            if (char.IsDigit(digit))
            {
                last = digit;
            }
        }
        return last;
    }
}

class TIntNumber : TNumber
{
    public TIntNumber(string number) : base(number)
    {
    }

    public override int SumOfDigits()
    {
        return base.SumOfDigits();
    }
}

class TRealNumber : TNumber
{
    public TRealNumber(string number) : base(number)
    {
    }

    public override char LastDigit()
    {
        char last = '0';
        foreach (char digit in number)
        {
            if (char.IsDigit(digit))
            {
                last = digit;
            }
        }
        return last;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int m = 5; 
        int n = 5; 
        int sumOfFirstDigits = 0;
        int sumOfLastDigits = 0;

        TIntNumber[] intNumbers = new TIntNumber[m];
        TRealNumber[] realNumbers = new TRealNumber[n];

        for (int i = 0; i < m; i++)
        {
            int randomInt = random.Next(1, 1000);
            intNumbers[i] = new TIntNumber(randomInt.ToString());
            sumOfFirstDigits += intNumbers[i].SumOfDigits();
        }

        for (int i = 0; i < n; i++)
        {
            double randomReal = random.NextDouble() * 1000;
            realNumbers[i] = new TRealNumber(randomReal.ToString("0.00"));
            sumOfLastDigits += int.Parse(realNumbers[i].LastDigit().ToString());
        }

        Console.WriteLine("Сума перших цифр цілих чисел: " + sumOfFirstDigits);
        Console.WriteLine("Сума останніх цифр дійсних чисел: " + sumOfLastDigits);
    }
}
