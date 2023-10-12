using System;

class Person
{
    public string name;
    public int age;

    public void Greet()
    {
        Console.WriteLine($"Hello, I'm {name}");
    }

    public void SetAge(int age)
    {
        this.age = age;
    }
}

class Student : Person
{
    public void Study()
    {
        Console.WriteLine("I'm studying\n");
    }

    public void ShowAge()
    {
        Console.WriteLine("My age is: " + age + " years old");
    }
}

class Professor : Person
{
    public void Explain()
    {
        Console.WriteLine("I'm explaining\n");
    }

    public void ShowAge()
    {
        Console.WriteLine("My age is: " + age + " years old");
    }
}

class StudentProfessorTest
{
    static void Main(string[] args)
    {
        Person person = new Person();
        person.name = "Vitya\n";
        person.Greet();
        
        
        Student student = new Student();
        student.name = "John";
        student.SetAge(20);
        student.Greet();
        student.ShowAge();
        student.Study();

        Professor professor = new Professor();
        professor.name = "Dr. Smith";
        professor.SetAge(45);
        professor.Greet();
        professor.ShowAge();
        professor.Explain();
    }
}

