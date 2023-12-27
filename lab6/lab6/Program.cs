using System;
using System.Collections.Generic;
using System.Linq;

// Узагальнений клас CollectionType<T>
public class CollectionType<T>
{
    private List<T> collection;

    public CollectionType()
    {
        collection = new List<T>();
    }

    public void AddItem(T item)
    {
        collection.Add(item);
    }

    public bool RemoveItem(T item)
    {
        return collection.Remove(item);
    }

    public T this[int index]
    {
        get { return collection[index]; }
        set { collection[index] = value; }
    }

    // Приклад LINQ запиту
    public IEnumerable<T> Filter(Func<T, bool> predicate)
    {
        return collection.Where(predicate);
    }
}

// Приклад класу з лабораторної №1, що реалізує IComparable<T>
public class LabClass : IComparable<LabClass>
{
    // ваші поля та методи

    public int CompareTo(LabClass other)
    {
        if (other == null)
        {
            return 1; // Якщо переданий об'єкт other є null, поточний об'єкт більший
        }

        // Порівняння за критеріями вашого класу LabClass
        // Повернення значення, яке показує, чи цей об'єкт менший (-1), рівний (0) чи більший (1) за other
        // Наприклад, якщо порівнювати за числовим полем SomeNumber:
        // return this.SomeNumber.CompareTo(other.SomeNumber);

        // Реалізуйте логіку порівняння за власними критеріями вашого класу
        return 0; // Повертаємо 0 як приклад, оскільки логіка порівняння не визначена
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення колекцій та робота з ними

        CollectionType<int> intCollection = new CollectionType<int>();
        intCollection.AddItem(1);
        intCollection.AddItem(2);
        intCollection.AddItem(3);

        CollectionType<string> stringCollection = new CollectionType<string>();
        stringCollection.AddItem("apple");
        stringCollection.AddItem("banana");
        stringCollection.AddItem("orange");

        // Приклад складного LINQ-запиту
        var filteredStrings = stringCollection.Filter(s => s.Contains("a"));

        foreach (var item in filteredStrings)
        {
            Console.WriteLine(item);
        }

        // Створення стандартної колекції та операції з нею

        List<string> strings = new List<string>();
        strings.Add("Hello");
        strings.Add("World");

        var filtered = strings.Where(s => s.Contains("o"));
        int count = strings.Count(s => s.Length == 5);
        var sortedAscending = strings.OrderBy(s => s);
        var sortedDescending = strings.OrderByDescending(s => s);

        // Робота з масивом об'єктів CollectionType та Dictionary

        CollectionType<int>[] arrayOfCollections = new CollectionType<int>[5];

        // Шукати колекції з негативними елементами, знаходження максимуму та мінімуму тощо.
        // Можливо, знадобиться переглянути логіку класу CollectionType та зробити відповідні операції.

        Dictionary<int, string> dictionary = new Dictionary<int, string>();
        dictionary.Add(1, "one");
        dictionary.Add(2, "two");
        dictionary.Add(3, "three");

        foreach (var pair in dictionary)
        {
            Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
        }

    }
}

