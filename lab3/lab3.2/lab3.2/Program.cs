using System;

class User
{
    protected string name;
    protected int age;

    public void SetName(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }

    public void SetAge(int age)
    {
        this.age = age;
    }

    public int GetAge()
    {
        return age;
    }
}

class Worker : User
{
    private int salary;

    public void SetSalary(int salary)
    {
        this.salary = salary;
    }

    public int GetSalary()
    {
        return salary;
    }
}

class Student : User
{
    private int scholarship;
    private int course;

    public void SetScholarship(int scholarship)
    {
        this.scholarship = scholarship;
    }

    public int GetScholarship()
    {
        return scholarship;
    }

    public void SetCourse(int course)
    {
        this.course = course;
    }

    public int GetCourse()
    {
        return course;
    }
}

class Driver : Worker
{
    private int drivingExperience;
    private string drivingCategory;

    public void SetDrivingExperience(int experience)
    {
        this.drivingExperience = experience;
    }

    public int GetDrivingExperience()
    {
        return drivingExperience;
    }

    public void SetDrivingCategory(string category)
    {
        this.drivingCategory = category;
    }

    public string GetDrivingCategory()
    {
        return drivingCategory;
    }

    public void PrintDriverInfo()
    {
        Console.WriteLine($" Ім'я: {name}\n Вік: {age}\n Заробітня плата: {GetSalary()}\n Водійський стаж: {drivingExperience}\n Категорія водіня: {drivingCategory}\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Worker ivan = new Worker();
        ivan.SetName("Іван");
        ivan.SetAge(25);
        ivan.SetSalary(1000);

        Worker vasya = new Worker();
        vasya.SetName("Вася");
        vasya.SetAge(26);
        vasya.SetSalary(2000);

        int totalSalary = ivan.GetSalary() + vasya.GetSalary();
        Console.WriteLine($"Загальна зарплата Івана і Васі: {totalSalary}");

        Student john = new Student();
        john.SetName("John");
        john.SetAge(20);
        john.SetScholarship(500);
        john.SetCourse(2);

        Driver driver = new Driver();
        driver.SetName("Майк");
        driver.SetAge(30);
        driver.SetSalary(1500);
        driver.SetDrivingExperience(5);
        driver.SetDrivingCategory("B");

        driver.PrintDriverInfo();
    }
}
